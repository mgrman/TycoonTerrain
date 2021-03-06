using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using File = UnityEngine.Windows.File;

namespace Votyra.Core.Editor
{
    public static class BuildTools
    {
#if UNITY_EDITOR_WIN
        private static string AssetsFolderPath => Application.dataPath.Replace('/', '\\');
#else
        private static string AssetsFolderPath => Application.dataPath;
#endif
        private static readonly string RootFolder = Path.GetFullPath(Path.Combine(AssetsFolderPath, "..", "Build", "Release"));
        private static readonly string Win64Directory = Path.Combine(RootFolder, "Win64");
        private static readonly string Win64Path = Path.Combine(Win64Directory, "Votyra.exe");
        private static readonly string WebGlDirectory = Path.Combine(RootFolder, "WebGL");
        private static readonly string WebGlBuildDirectory = "Build";
        private static readonly string WebGLWasmDirectory = Path.Combine(WebGlDirectory, WebGlBuildDirectory);
        private static readonly string DocsFolder = Path.GetFullPath(Path.Combine(AssetsFolderPath, "..", "docs"));
        private static readonly string Win64DocsFile = Path.Combine(DocsFolder, "Votyra-Win.zip");
        private static readonly string WebGLDocsWasmDirectory = Path.Combine(DocsFolder, WebGlBuildDirectory);

        [MenuItem("Build/Votyra/Build All (Release)")]
        public static void BuildAllRelease()
        {
            BuildWin64();
            BuildWebGl();
            OpenFolderInExplorer();
        }

        [MenuItem("Build/Votyra/Build and Update Docs")]
        public static void BuildAllAndUpdateDocs()
        {
            BuildWin64();
            Win64DocsFile.TryDeleteFile();
            UnityZip.Zip(Win64DocsFile, Win64Directory);

            BuildWebGl();
            WebGLDocsWasmDirectory.TryDeleteDirectory();
            DirectoryCopy(WebGLWasmDirectory, WebGLDocsWasmDirectory, true);
        }

        [MenuItem("Build/Votyra/Build Win64 (Release)")]
        public static void BuildWin64()
        {
            Win64Directory.TryDeleteDirectory();
            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, Win64Path, BuildTarget.StandaloneWindows, BuildOptions.None);

            var cleanupDir = Path.Combine(Win64Directory, "Votyra_BackUpThisFolder_ButDontShipItWithYourGame");
            cleanupDir.TryDeleteDirectory();
        }

        [MenuItem("Build/Votyra/Build WebGL (Release)")]
        public static void BuildWebGl()
        {
            var webGlPath = Path.Combine(WebGlDirectory, "Votyra");
            var webGlTempDirectory = Path.Combine(RootFolder, "WebGL-" + Guid.NewGuid());
            try
            {
                WebGlDirectory.TryDeleteDirectory();

                BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, webGlPath, BuildTarget.WebGL, BuildOptions.None);
                Directory.Move(webGlPath, webGlTempDirectory);
                Directory.Delete(WebGlDirectory, true);
                Directory.Move(webGlTempDirectory, WebGlDirectory);
            }
            finally
            {
                webGlTempDirectory.TryDeleteDirectory();
            }
        }

        [MenuItem("Build/Votyra/Open Release folder")]
        public static void OpenFolderInExplorer()
        {
            var proc = new Process {StartInfo = {FileName = RootFolder}};
            proc.Start();
        }

        private static void TryDeleteDirectory(this string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                Directory.Delete(dirPath, true);
            }
        }

        private static void TryDeleteFile(this string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}