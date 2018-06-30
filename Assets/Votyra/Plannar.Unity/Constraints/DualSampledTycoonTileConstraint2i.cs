using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Votyra.Core.Images;
using Votyra.Core.Images.Constraints;
using Votyra.Core.ImageSamplers;
using Votyra.Core.Models;

namespace Votyra.Plannar.Images.Constraints
{
    public class DualSampledTycoonTileConstraint2i : IImageConstraint2i
    {
        private readonly static SampledData2i[] ExpandedTemplates = Templates
            .SelectMany(template =>
            {
                return new[]
                {
                template,
                template.GetRotated(1),
                template.GetRotated(2),
                template.GetRotated(3),
                };
            })
            .Distinct()
            .ToArray();

        private readonly static SampledData2i[] Templates = new SampledData2i[]
        {
            //plane
            new SampledData2i(1, 1, 1, 1),

            //slope
            new SampledData2i(0, 1, 0, 1),

            //slopeDiagonal
            new SampledData2i(-1, 0, 0, 1),

            //partialUpSlope
            new SampledData2i(0, 0, 0, 1),

            //partialDownSlope
            new SampledData2i(0, 1, 1, 1),

            //slopeDiagonal
            new SampledData2i(1, 0, 0, 1),
        };

        private readonly static Dictionary<SampledData2i, SampledData2i> TileMap = SampledData2i.GenerateAllValues(new Range1i(-1, 1), true)
            .ToDictionary(inputValue => inputValue, inputValue =>
            {
                SampledData2i choosenTemplateTile = default(SampledData2i);
                float choosenTemplateTileDiff = float.MaxValue;
                for (int it = 0; it < ExpandedTemplates.Length; it++)
                {
                    SampledData2i tile = ExpandedTemplates[it];
                    var value = SampledData2i.Dif(tile, inputValue);
                    if (value < choosenTemplateTileDiff)
                    {
                        choosenTemplateTile = tile;
                        choosenTemplateTileDiff = value;
                    }
                }
                return choosenTemplateTile.SetHolesUsing(inputValue);
            });

        private IImageSampler2i _sampler;

        public DualSampledTycoonTileConstraint2i(IImageSampler2i sampler)
        {
            _sampler = sampler;
        }

        public Range2i Constrain(Direction direction, Range2i invalidatedCellArea, IImageSampler2i sampler, Matrix2<int?> editableMatrix)
        {
            if (direction != Direction.Up && direction != Direction.Down)
            {
                direction = Direction.Down;
            }
            invalidatedCellArea.ForeachPointExlusive(cell =>
            {
                var sample = sampler.Sample(editableMatrix, cell);

                var processedSample = Process(sample);

                Vector2i cell_x0y0 = sampler.CellToX0Y0(cell);
                Vector2i cell_x0y1 = sampler.CellToX0Y1(cell);
                Vector2i cell_x1y0 = sampler.CellToX1Y0(cell);
                Vector2i cell_x1y1 = sampler.CellToX1Y1(cell);

                if (editableMatrix.ContainsIndex(cell_x0y0))
                    editableMatrix[cell_x0y0] = processedSample.x0y0;
                if (editableMatrix.ContainsIndex(cell_x0y1))
                    editableMatrix[cell_x0y1] = processedSample.x0y1;
                if (editableMatrix.ContainsIndex(cell_x1y0))
                    editableMatrix[cell_x1y0] = processedSample.x1y0;
                if (editableMatrix.ContainsIndex(cell_x1y1))
                    editableMatrix[cell_x1y1] = processedSample.x1y1;
            });

            return invalidatedCellArea;
        }

        public Range2i FixImage(Matrix2<int?> editableMatrix, Range2i invalidatedImageArea, Direction direction)
        {
            if (_sampler == null)
            {
                return invalidatedImageArea;
            }

            var invalidatedCellArea = _sampler.ImageToWorld(invalidatedImageArea)
                .RoundToContain();

            var newInvalidatedCellArea = Constrain(direction, invalidatedCellArea, _sampler, editableMatrix);

            var newInvalidatedImageArea = _sampler.WorldToImage(newInvalidatedCellArea);

            return invalidatedImageArea.CombineWith(newInvalidatedImageArea);
        }

        private SampledData2i Process(SampledData2i sampleData)
        {
            var height = sampleData.Max - 1;

            SampledData2i normalizedHeightData = sampleData.NormalizeFromTop(Range1i.PlusMinusOne);
            if (!TileMap.ContainsKey(normalizedHeightData))
            {
                Debug.Log($"normalizedHeightData does not exing in TileMap: {normalizedHeightData} height:{height}");
                return sampleData;
            }

            SampledData2i choosenTemplateTile = TileMap[normalizedHeightData];

            return choosenTemplateTile + height;
        }

        private struct PositionWithValue
        {
            public readonly Vector2i Position;
            public readonly float Value;

            public PositionWithValue(Vector2i pos, float value)
            {
                Position = pos;
                Value = value;
            }
        };
    }
}