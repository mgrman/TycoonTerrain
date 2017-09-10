﻿using UnityEngine;
using Votyra.Models;

namespace Votyra.Images
{
    public interface IImage2f
    {
        Range2 RangeZ { get; }

        float Sample(Vector2i point);
    }
}