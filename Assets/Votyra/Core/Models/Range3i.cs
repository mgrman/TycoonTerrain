using System;

namespace Votyra.Core.Models
{
    /// <summary>
    ///     Max is exclusive
    /// </summary>
    public struct Range3i : IEquatable<Range3i>
    {
        public static readonly Range3i All = new Range3i(Vector3i.FromSame(int.MinValue / 2), Vector3i.FromSame(int.MaxValue) / 2);

        public static readonly Range3i Zero = new Range3i();

        public readonly Vector3i Min;

        public readonly Vector3i Max;

        private Range3i(Vector3i min, Vector3i max)
        {
            Min = min;
            Max = max;
            if (Size.AnyNegative)
                throw new InvalidOperationException($"{nameof(Range3i)} '{this}' cannot have a size be zero or negative!");
            if (Size.AnyZero)
                Max = Min;
        }

        public Vector3i Size => Max - Min;

        public static Range3i FromCenterAndExtents(Vector3i center, Vector3i extents)
        {
            if (extents.AnyNegative)
                throw new InvalidOperationException($"When creating {nameof(Range3i)} from center '{center}' and extents '{extents}', extents cannot have a negative coordinate!");
            return new Range3i(center - extents + 1, center + extents);
        }

        public static Range3i FromMinAndSize(Vector3i min, Vector3i size)
        {
            if (size.AnyNegative)
                throw new InvalidOperationException($"When creating {nameof(Range3i)} using min '{min}' and size '{size}', size cannot have a negative coordinate!");
            return new Range3i(min, min + size);
        }

        public static Range3i FromMinAndMax(Vector3i min, Vector3i max) => new Range3i(min, max);

        public static bool operator ==(Range3i a, Range3i b) => a.Min == b.Min && a.Max == b.Max;

        public static bool operator !=(Range3i a, Range3i b) => a.Min != b.Min || a.Max != b.Max;

        public bool Contains(Vector3i point) => point >= Min && point < Max;

        public bool Overlaps(Range3i that)
        {
            if (Size == Vector3i.Zero || that.Size == Vector3i.Zero)
                return false;

            return Min <= that.Max && that.Min <= Max;
        }

        public Range3i CombineWith(Range3i that)
        {
            if (Size == Vector3i.Zero)
                return that;

            if (that.Size == Vector3i.Zero)
                return this;

            var min = Vector3i.Min(Min, that.Min);
            var max = Vector3i.Max(Max, that.Max);
            return FromMinAndMax(min, max);
        }

        public Range3i CombineWith(Vector3i point)
        {
            if (Size == Vector3i.Zero)
                return new Range3i(point, Vector3i.One);

            if (Contains(point))
                return this;

            var min = Vector3i.Min(Min, point);
            var max = Vector3i.Max(Max, point);

            return FromMinAndMax(min, max);
        }

        public Area3f ToRange3f() => Area3f.FromMinAndMax(Min.ToVector3f(), Max.ToVector3f());

        public Range3i IntersectWith(Range3i that)
        {
            if (Size == Vector3i.Zero || that.Size == Vector3i.Zero)
                return Zero;

            var min = Vector3i.Max(Min, that.Min);
            var max = Vector3i.Max(Vector3i.Min(Max, that.Max), min);

            return FromMinAndMax(min, max);
        }

        public bool Equals(Range3i other) => this == other;

        public override bool Equals(object obj)
        {
            if (!(obj is Range3i))
                return false;

            return Equals((Range3i) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Min.GetHashCode() + 7 * Max.GetHashCode();
            }
        }

        public override string ToString() => $"min:{Min} max:{Max} size:{Size}";
    }
}