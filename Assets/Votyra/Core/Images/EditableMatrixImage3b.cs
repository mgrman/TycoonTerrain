using System;
using System.Collections.Generic;
using System.Linq;
using Votyra.Core.Images.Constraints;
using Votyra.Core.Logging;
using Votyra.Core.Models;

namespace Votyra.Core.Images
{
    public class EditableMatrixImage3b : IImage3bProvider, IEditableImage3b
    {
        private readonly IImageConstraint3b _constraint;
        private readonly Matrix3<bool> _editableMatrix;
        private readonly IThreadSafeLogger _logger;

        private readonly List<LockableMatrix3<bool>> _readonlyMatrices = new List<LockableMatrix3<bool>>();
        private MatrixImage3b _image;
        private Range3i? _invalidatedArea;

        public EditableMatrixImage3b(IImageConfig imageConfig, IThreadSafeLogger logger, IImageConstraint3b constraint = null)
        {
            _constraint = constraint;
            _editableMatrix = new Matrix3<bool>(imageConfig.ImageSize);
            _logger = logger;
        }

        public IEditableImageAccessor3b RequestAccess(Range3i areaRequest) => new MatrixImageAccessor(this, areaRequest);

        public IImage3b CreateImage()
        {
            if (_invalidatedArea == Range3i.Zero)
            {
                _image?.Dispose();
                _image = new MatrixImage3b(_image.Image, Range3i.Zero);
            }
            else if (_invalidatedArea.HasValue || _image == null)
            {
                _invalidatedArea = _invalidatedArea ?? _editableMatrix.Size.ToRange3i();
                // Debug.LogFormat("Update readonlyCount:{0}", _readonlyMatrices.Count);

                var readonlyMatrix = _readonlyMatrices.FirstOrDefault(o => !o.IsLocked);
                if (readonlyMatrix == null)
                {
                    readonlyMatrix = new LockableMatrix3<bool>(_editableMatrix.Size);
                    _readonlyMatrices.Add(readonlyMatrix);
                }

                //sync
                for (var ix = 0; ix < _editableMatrix.Size.X; ix++)
                {
                    for (var iy = 0; iy < _editableMatrix.Size.Y; iy++)
                    {
                        for (var iz = 0; iz < _editableMatrix.Size.Z; iz++)
                        {
                            var i = new Vector3i(ix, iy, iz);
                            readonlyMatrix[i] = _editableMatrix[i];
                        }
                    }
                }

                // Debug.LogError($"_readonlyMatrices: {_readonlyMatrices.Count}");

                _image?.Dispose();
                _image = new MatrixImage3b(readonlyMatrix, _invalidatedArea.Value);
                _invalidatedArea = Range3i.Zero;
            }

            return _image;
        }

        private void FixImage(Range3i invalidatedImageArea, Direction direction)
        {
            _invalidatedArea = _invalidatedArea?.CombineWith(invalidatedImageArea) ?? invalidatedImageArea;

            if (_constraint == null)
                return;

            var newInvalidatedImageArea = _constraint.FixImage(_editableMatrix, invalidatedImageArea, direction);
            _logger.LogMessage("newInvalidatedImageArea:" + newInvalidatedImageArea);

            _invalidatedArea = _invalidatedArea?.CombineWith(newInvalidatedImageArea) ?? newInvalidatedImageArea;
            _logger.LogMessage("_invalidatedArea:" + _invalidatedArea);
        }

        private class MatrixImageAccessor : IEditableImageAccessor3b
        {
            private readonly EditableMatrixImage3b _editableImage;
            private readonly bool[,,] _editableMatrix;
            private int _changeCounter;
            private bool _changed;

            public MatrixImageAccessor(EditableMatrixImage3b editableImage, Range3i area)
            {
                _editableMatrix = editableImage._editableMatrix.NativeMatrix;
                _editableImage = editableImage;
                Area = area.IntersectWith(editableImage._editableMatrix.Size.ToRange3i());
            }

            public Range3i Area { get; }

            public bool this[Vector3i pos]
            {
                get => _editableMatrix[pos.X, pos.Y, pos.Z];
                set
                {
                    if (value && !_editableMatrix[pos.X, pos.Y, pos.Z])
                    {
                        _changeCounter += 1;
                        _changed = true;
                    }

                    if (!value && _editableMatrix[pos.X, pos.Y, pos.Z])
                    {
                        _changeCounter -= 1;
                        _changed = true;
                    }

                    _editableMatrix[pos.X, pos.Y, pos.Z] = value;
                }
            }

            public void Dispose()
            {
                if (!_changed)
                    return;

                _editableImage.FixImage(Area, _changeCounter > 0 ? Direction.Up : _changeCounter < 0 ? Direction.Down : Direction.Unknown);
            }
        }
    }
}