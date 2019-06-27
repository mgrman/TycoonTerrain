using System;
using System.Collections.Generic;
using Votyra.Core.Models;
using Votyra.Core.Pooling;
using Votyra.Core.TerrainMeshes;

namespace Votyra.Core
{
    public interface ITerrainRepository2i: ITerrainRepository<Vector2i, ITerrainMesh2f>
    {
    }
}