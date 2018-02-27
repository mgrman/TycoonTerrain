using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Votyra.Core.Images;
using Votyra.Core.Models;
using Votyra.Core.Utils;
using Votyra.Plannar.Images.Constraints;
using Votyra.Plannar.ImageSamplers;

namespace Votyra.Plannar.Images
{
    public class EditableMatrixImage2f : IImage2fProvider, IEditableImage2f
    {
        private Matrix<float> _editableMatrix;

        private Rect2i? _invalidatedArea;

        private readonly List<LockableMatrix<float>> _readonlyMatrices = new List<LockableMatrix<float>>();

        private MatrixImage2f _image = null;

        private IImageConstraint2i _constraint;

        private IImageSampler2i _sampler;

        public EditableMatrixImage2f(Vector2i size, IImageSampler2i sampler, IImageConstraint2i constraint)
        {
            _constraint = constraint;
            _sampler = sampler;

            _editableMatrix = new Matrix<float>(size);
            FixImage(new Rect2i(0, 0, size.x, size.y), Direction.Unknown);
        }

        public EditableMatrixImage2f(Texture2D texture, float scale, IImageSampler2i sampler, IImageConstraint2i constraint)
        {
            _constraint = constraint;
            _sampler = sampler;

            int width = texture.width;
            int height = texture.height;

            var size = new Vector2i(width, height);
            _editableMatrix = new Matrix<float>(size);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _editableMatrix[x, y] = texture.GetPixel(x, y).grayscale * scale;
                }
            }
            FixImage(new Rect2i(0, 0, size.x, size.y), Direction.Unknown);
        }

        public IImage2f CreateImage()
        {
            if (_invalidatedArea == Rect2i.zero)
            {
                _image?.Dispose();
                _image = new MatrixImage2f(_image.Image, Rect2i.zero);
            }
            else if (_invalidatedArea.HasValue)
            {
                // Debug.LogFormat("Update readonlyCount:{0}", _readonlyMatrices.Count);

                var readonlyMatrix = _readonlyMatrices.FirstOrDefault(o => !o.IsLocked);
                if (readonlyMatrix == null)
                {
                    readonlyMatrix = new LockableMatrix<float>(_editableMatrix.size);
                    _readonlyMatrices.Add(readonlyMatrix);
                }

                //sync
                for (int x = 0; x < _editableMatrix.size.x; x++)
                {
                    for (int y = 0; y < _editableMatrix.size.y; y++)
                    {
                        readonlyMatrix[x, y] = _editableMatrix[x, y];
                    }
                }

                // Debug.LogError($"_readonlyMatrices: {_readonlyMatrices.Count}");

                _image?.Dispose();
                _image = new MatrixImage2f(readonlyMatrix, _invalidatedArea.Value);
                _invalidatedArea = Rect2i.zero;
            }
            return _image;
        }

        public IEditableImageAccessor2f RequestAccess(Rect2i area)
        {
            return new MatrixImageAccessor(this, area);
        }

        private void FixImage(Rect2i invalidatedImageArea, Direction direction)
        {
            _invalidatedArea = _invalidatedArea?.CombineWith(invalidatedImageArea) ?? invalidatedImageArea;

            if (_sampler == null || _constraint == null)
            {
                return;
            }

            var invalidatedCellArea = _sampler.ImageToWorld(invalidatedImageArea)
                .RoundToContain();

            var newInvalidatedCellArea = _constraint.Constrain(direction, invalidatedCellArea, _sampler, _editableMatrix);

            var newInvalidatedImageArea = _sampler.WorldToImage(newInvalidatedCellArea);

            _invalidatedArea = _invalidatedArea?.CombineWith(newInvalidatedImageArea) ?? newInvalidatedImageArea;
        }

        private class EditableImageWrapper : IImage2f
        {
            private readonly Matrix<float> _editableMatrix;

            public EditableImageWrapper(Matrix<float> editableMatrix)
            {
                _editableMatrix = editableMatrix;
            }

            public Rect2i InvalidatedArea => Rect2i.zero;

            public Range2 RangeZ => new Range2(0, 0);

            public float Sample(Vector2i point)
            {
                if (point.IsAsIndexContained(_editableMatrix.size))
                {
                    return _editableMatrix[point];
                }
                else
                {
                    return 0;
                }
            }
        }

        private class MatrixImageAccessor : IEditableImageAccessor2f
        {
            float _changeCounter = 0;
            public Rect2i Area { get; }

            public float this [Vector2i pos]
            {
                get { return _editableImage._editableMatrix[pos]; }
                set
                {
                    _changeCounter += value - _editableImage._editableMatrix[pos];
                    _editableImage._editableMatrix[pos] = value;
                }
            }

            private readonly EditableMatrixImage2f _editableImage;

            public MatrixImageAccessor(EditableMatrixImage2f editableImage, Rect2i area)
            {
                _editableImage = editableImage;
                Area = area;
            }

            public void Dispose()
            {
                this._editableImage.FixImage(Area, _changeCounter > 0 ? Direction.Up : Direction.Down);
            }
        }
    }
}