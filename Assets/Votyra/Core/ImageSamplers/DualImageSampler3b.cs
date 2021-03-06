using Votyra.Core.Models;
using Votyra.Core.Utils;

namespace Votyra.Core.ImageSamplers
{
    public class DualImageSampler3b : IImageSampler3
    {
        public Vector3i WorldToImage(Vector3f pos) => new Vector3i((pos.X * 2).FloorToInt(), (pos.Y * 2).FloorToInt(), (pos.Z * 2).FloorToInt());

        public Vector3f ImageToWorld(Vector3i pos) => new Vector3f(pos.X / 2f, pos.Y / 2f, pos.Z / 2f);

        public Vector3i CellToX0Y0Z0(Vector3i pos) => new Vector3i(pos.X * 2 + 0, pos.Y * 2 + 0, pos.Z * 2 + 0);

        public Vector3i CellToX0Y0Z1(Vector3i pos) => new Vector3i(pos.X * 2 + 0, pos.Y * 2 + 0, pos.Z * 2 + 1);

        public Vector3i CellToX0Y1Z0(Vector3i pos) => new Vector3i(pos.X * 2 + 0, pos.Y * 2 + 1, pos.Z * 2 + 0);

        public Vector3i CellToX0Y1Z1(Vector3i pos) => new Vector3i(pos.X * 2 + 0, pos.Y * 2 + 1, pos.Z * 2 + 1);

        public Vector3i CellToX1Y0Z0(Vector3i pos) => new Vector3i(pos.X * 2 + 1, pos.Y * 2 + 0, pos.Z * 2 + 0);

        public Vector3i CellToX1Y0Z1(Vector3i pos) => new Vector3i(pos.X * 2 + 1, pos.Y * 2 + 0, pos.Z * 2 + 1);

        public Vector3i CellToX1Y1Z0(Vector3i pos) => new Vector3i(pos.X * 2 + 1, pos.Y * 2 + 1, pos.Z * 2 + 0);

        public Vector3i CellToX1Y1Z1(Vector3i pos) => new Vector3i(pos.X * 2 + 1, pos.Y * 2 + 1, pos.Z * 2 + 1);
    }
}