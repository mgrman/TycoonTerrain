using System;
using UnityEngine;
using Votyra.Core.Images;
using Votyra.Core.ImageSamplers;
using Votyra.Core.Models;
using Zenject;

namespace Votyra.Core.Painting.Commands
{
    public interface IPaintCommand
    {
        void Selected();

        void Unselected();

        void StopInvocation();

        void StartInvocation(Vector2i cell, int strength);
    }
}