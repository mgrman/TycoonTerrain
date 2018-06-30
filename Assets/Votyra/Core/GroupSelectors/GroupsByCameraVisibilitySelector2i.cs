using System.Collections.Generic;
using Votyra.Core.ImageSamplers;
using Votyra.Core.Models;
using Votyra.Core.Pooling;

namespace Votyra.Core.GroupSelectors
{
    public class GroupsByCameraVisibilitySelector2i : IGroupSelector<IFrameData2i, Vector2i>
    {
        private readonly Vector2i _cellInGroupCount;
        private readonly IImageSampler2i _imageSampler;
        private HashSet<Vector2i> _skippedAreas = new HashSet<Vector2i>();

        public GroupsByCameraVisibilitySelector2i(ITerrainConfig terrainConfig, IImageSampler2i imageSampler)
        {
            _imageSampler = imageSampler;
            _cellInGroupCount = terrainConfig.CellInGroupCount.XY;
        }

        public GroupActions<Vector2i> GetGroupsToUpdate(IFrameData2i options)
        {
            if (options == null)
            {
                return null;
            }
            // var logger = options.LoggerFactory(this.GetType().Name, this);

            var planes = options.CameraPlanes;
            var frustumCorners = options.CameraFrustumCorners;
            var cameraPosition = options.CameraPosition;
            var cameraLocalToWorldMatrix = options.CameraLocalToWorldMatrix;
            var parentContainerWorldToLocalMatrix = options.ParentContainerWorldToLocalMatrix;
            var invalidatedArea = _imageSampler
               .ImageToWorld(options.InvalidatedArea_imageSpace)
               .RoundToContain();

            var cameraPositionLocal = parentContainerWorldToLocalMatrix.MultiplyPoint(cameraPosition).XY;

            var localCameraBounds = Range2f.FromMinAndSize(cameraPositionLocal, new Vector2f());
            foreach (var frustumCorner in frustumCorners)
            {
                var vector = parentContainerWorldToLocalMatrix
                    .MultiplyPoint(cameraLocalToWorldMatrix.MultiplyVector(frustumCorner))
                    .XY;
                localCameraBounds = localCameraBounds.Encapsulate(cameraPositionLocal + vector);
            }
            var cameraBoundsGroups = (localCameraBounds / _cellInGroupCount.ToVector2f()).RoundToContain();

            var minZ = options.Image.RangeZ.Min;
            var bounds_size = new Vector3f(_cellInGroupCount.X, _cellInGroupCount.Y, options.Image.RangeZ.Size);

            var groupsToRecompute = PooledSet<Vector2i>.Create();
            var groupsToKeep = PooledSet<Vector2i>.Create();

            cameraBoundsGroups.ForeachPointExlusive(group =>
            {
                var groupBoundsMin = (group * _cellInGroupCount).ToVector2f().ToVector3f(minZ);
                var groupBounds = Range3f.FromMinAndSize(groupBoundsMin, bounds_size);

                bool isInside = planes.TestPlanesAABB(groupBounds);
                if (isInside)
                {
                    var groupArea = Range2i.FromMinAndSize(group * _cellInGroupCount, _cellInGroupCount);
                    bool isInvalidated = groupArea.Overlaps(invalidatedArea);
                    if (isInvalidated)
                    {
                        groupsToRecompute.Add(group);
                        _skippedAreas.Remove(group);
                    }
                    else
                    {
                        if (!options.ExistingGroups.Contains(group))
                        {
                            var groupBoundsXYMin = (group * _cellInGroupCount);
                            var groupBoundsXY = Range2i.FromMinAndSize(groupBoundsXYMin, _cellInGroupCount);
                            var groupBounds_image = _imageSampler.WorldToImage(groupBoundsXY);
                            var noData = _skippedAreas.Contains(group) || !options.Image.AnyData(groupBounds_image);
                            if (noData)
                            {
                                groupsToKeep.Add(group);
                                _skippedAreas.Add(group);
                            }
                            else
                            {
                                groupsToRecompute.Add(group);
                            }
                        }
                        else
                        {
                            groupsToKeep.Add(group);
                        }
                    }
                }
            });
            return new GroupActions<Vector2i>(groupsToRecompute, groupsToKeep);
        }
    }
}