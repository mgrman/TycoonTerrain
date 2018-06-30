﻿using Votyra.Core.Models;

namespace Votyra.Core.Images
{
    public class TerrainConfig : ITerrainConfig
    {
        public TerrainConfig(Vector3i cellInGroupCount, bool flipTriangles, bool drawBounds, bool async)
        {
            CellInGroupCount = cellInGroupCount;
            FlipTriangles = flipTriangles;
            DrawBounds = drawBounds;
            Async = async;
        }

        public bool Async { get; }
        public Vector3i CellInGroupCount { get; }
        public bool DrawBounds { get; }
        public bool FlipTriangles { get; }

        public static bool operator !=(TerrainConfig a, TerrainConfig b)
        {
            return !(a == b);
        }

        public static bool operator ==(TerrainConfig a, TerrainConfig b)
        {
            return a?.Equals(b) ?? b?.Equals(a) ?? true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var that = obj as TerrainConfig;

            return this.CellInGroupCount == that.CellInGroupCount
                && this.FlipTriangles == that.FlipTriangles
                && this.DrawBounds == that.DrawBounds
                && this.Async == that.Async;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return this.CellInGroupCount.GetHashCode()
                    + this.FlipTriangles.GetHashCode() * 3
                    + this.DrawBounds.GetHashCode() * 7
                    + this.Async.GetHashCode() * 13;
            }
        }
    }
}