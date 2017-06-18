﻿using Votyra.Models;
using Votyra.Images;
using UnityEngine;

namespace Votyra.ImageSamplers
{
    public static class ImageSamplerUtils
    {
        public static Rect ImageToWorld(this IImageSampler2i sampler, Rect2i rect)
        {
            var min = sampler.ImageToWorld(rect.min);
            var max = sampler.ImageToWorld(rect.max);
            return Rect.MinMaxRect(min.x, min.y, max.x, max.y);
        }
        public static Bounds ImageToWorld(this IImageSampler3b sampler, Rect3i rect)
        {
            var min = sampler.ImageToWorld(rect.min);
            var max = sampler.ImageToWorld(rect.max);
            return new Bounds((max + min) / 2, max - min);
        }
    }
}