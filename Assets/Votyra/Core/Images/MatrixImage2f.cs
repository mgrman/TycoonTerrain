using System;
using Votyra.Core.Models;

namespace Votyra.Core.Images
{
    public class MatrixImage2f : IImage2f, IInitializableImage, IImageInvalidatableImage2
    {
        private readonly float[,] _image;
        private readonly Range2i _imageRange;
        
        private int _usingCounter;

        public MatrixImage2f(Vector2i size)
        {
            _image = new float[size.X, size.Y];
            _imageRange=Range2i.FromMinAndSize(Vector2i.Zero, size);
        }

        public void UpdateImage(Matrix2<float> template, Area1f rangeZ)
        {
            Array.Copy(template.NativeMatrix,_image,_image.Length);

            RangeZ = rangeZ;
        }

        public void UpdateInvalidatedArea(Range2i invalidatedArea)
        {
            InvalidatedArea = invalidatedArea;
        }

        public Area1f RangeZ { get; private set; }
        
        public float Sample(Vector2i point) => _imageRange.Contains(point) ? _image[point.X, point.Y] : 0f;

        public IPoolableMatrix2<float> SampleArea(Range2i area)
        {
            var min = area.Min;
            var matrix = PoolableMatrix<float>.CreateDirty(area.Size);
            matrix.Size.ForeachPointExlusive(matPoint =>
            {
                matrix[matPoint] = Sample(matPoint + min);
            });
            return matrix;
        }

        public Range2i InvalidatedArea { get; private set; }

        public bool IsBeingUsed => _usingCounter > 0;

        public void StartUsing()
        {
            _usingCounter++;
        }

        public void FinishUsing()
        {
            _usingCounter--;
        }
    }
}