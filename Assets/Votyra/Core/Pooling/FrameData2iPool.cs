using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Votyra.Core.ImageSamplers;
using Votyra.Core.Models;
using Votyra.Core.Models.ObjectPool;
using Votyra.Core.TerrainGenerators.TerrainMeshers;
using Votyra.Core.TerrainMeshes;

namespace Votyra.Core.Pooling
{
    public class FrameData2iPool : ArcPool<IFrameData2i>, IFrameData2iPool
    {
        public FrameData2iPool()
            : base(Create)
        {
        }

        private static IFrameData2i Create()
        {
            return new FrameData2i();
        }
    }
}