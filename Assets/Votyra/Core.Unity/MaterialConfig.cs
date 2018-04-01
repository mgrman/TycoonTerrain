﻿using UnityEngine;
using Votyra.Core.Models;

namespace Votyra.Core.Images
{
    public class MaterialConfig : IMaterialConfig
    {
        public MaterialConfig(Material material, Material materialWalls)
        {
            Material = material;
            MaterialWalls = materialWalls;
        }

        public Material Material { get; }
        public Material MaterialWalls { get; }


        public static bool operator ==(MaterialConfig a, MaterialConfig b)
        {
            return a?.Equals(b) ?? b?.Equals(a) ?? true;
        }

        public static bool operator !=(MaterialConfig a, MaterialConfig b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var that = obj as MaterialConfig;

            return this.Material == that.Material
                && this.MaterialWalls == that.MaterialWalls;
        }

        public override int GetHashCode()
        {
            return this.Material.GetHashCode() * 23
                + this.MaterialWalls.GetHashCode() - 3;
        }
    }
}