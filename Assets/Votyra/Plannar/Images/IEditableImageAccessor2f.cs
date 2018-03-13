using System;
using Votyra.Core.Models;

namespace Votyra.Plannar.Images
{
    public interface IEditableImageAccessor2f : IDisposable
    {
        Rect2i Area { get; }

        float this[Vector2i pos] { get; set; }
    }
}