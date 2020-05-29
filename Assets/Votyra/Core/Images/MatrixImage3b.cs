using Votyra.Core.Models;

namespace Votyra.Core.Images
{
    public class MatrixImage3b : BaseMatrix3<bool>, IImage3b
    {
        public MatrixImage3b(Vector3i size)
            : base(size)
        {
        }

        public bool AnyData(Range3i range)
        {
            var allFalse = true;
            var allTrue = true;
            range = range.IntersectWith(this._image.Range());
            var min = range.Min;
            for (var ix = 0; ix < range.Size.X; ix++)
            {
                for (var iy = 0; iy < range.Size.Y; iy++)
                {
                    for (var iz = 0; iz < range.Size.Z; iz++)
                    {
                        var value = this._image[ix + min.X, iy + min.Y, iz + min.Z];
                        allFalse = allFalse && !value;
                        allTrue = allTrue && value;
                    }
                }
            }

            return !allFalse && !allTrue;
        }
    }
}
