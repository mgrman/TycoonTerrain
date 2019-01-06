using System;

namespace Votyra.Core.Models
{
    /// <summary>
    /// Max is exclusive
    /// </summary>
    public struct Range2i : IEquatable<Range2i>
    {
        public static readonly Vector2i MinValue = Vector2i.FromSame(int.MinValue / 2);
        public static readonly Vector2i MaxValue = Vector2i.FromSame(int.MaxValue / 2);
        
        public static readonly Range2i All = new Range2i(MinValue, MaxValue);

        public static readonly Range2i Zero = new Range2i();

        public readonly Vector2i Min;

        public readonly Vector2i Max;

        public bool IsEmpty => Size == Vector2i.Zero;

        private Range2i(Vector2i min, Vector2i max)
        {
            this.Min = Vector2i.Max(min, MinValue);
            this.Max = Vector2i.Min(max, MaxValue);
            if (this.Size.AnyNegative)
            {
                throw new InvalidOperationException($"{nameof(Range2i)} '{this}' cannot have a size be zero or negative!");
            }
            if (this.Size.AnyZero)
            {
                this.Max = this.Min;
            }
        }

        public Range2i ExtendBothDirections(int distance)
        {
            if (IsEmpty)
            {
                return this;
            }
            return Range2i.FromMinAndMax(Min - distance, Max + distance);
        }

        public Vector2i Size => Max - Min;

        public static Range2i FromMinAndSize(Vector2i min, Vector2i size)
        {
            if (size.AnyNegative)
            {
                throw new InvalidOperationException($"When creating {nameof(Range2i)} using min '{min}' and size '{size}', size cannot have a negative coordinate!");
            }
            return new Range2i(min, min + size);
        }

        public static Range2i FromMinAndMax(Vector2i min, Vector2i max)
        {
            return new Range2i(min, max);
        }

        public Area2i? ToArea2i()
        {
            if (Size == Vector2i.Zero)
            {
                return null;
            }
            return Area2i.FromMinAndMax(Min, Max - Vector2i.One);
        }

        public static bool operator ==(Range2i a, Range2i b)
        {
            return a.Min == b.Min && a.Max == b.Max;
        }

        public static bool operator !=(Range2i a, Range2i b)
        {
            return a.Min != b.Min || a.Max != b.Max;
        }

        public void ForeachPointExlusive(Action<Vector2i> action)
        {
            var min = Min;
            Size.ForeachPointExlusive(i => action(i + min));
        }

        public bool Contains(Vector2i point)
        {
            return point >= Min && point < Max;
        }

        public bool Overlaps(Range2i that)
        {
            if (this.Size == Vector2i.Zero || that.Size == Vector2i.Zero)
                return false;

            return this.Min < that.Max && that.Min < this.Max;
        }

        public Range2i CombineWith(Range2i that)
        {
            if (this.Size == Vector2i.Zero)
                return that;

            if (that.Size == Vector2i.Zero)
                return this;

            var min = Vector2i.Min(this.Min, that.Min);
            var max = Vector2i.Max(this.Max, that.Max);
            return Range2i.FromMinAndMax(min, max);
        }

        public Range2i CombineWith(Vector2i point)
        {
            if (Contains(point))
                return this;

            var min = Vector2i.Min(this.Min, point);
            var max = Vector2i.Max(this.Max, point);

            return Range2i.FromMinAndMax(min, max);
        }

        public Range2i IntersectWith(Range2i that)
        {
            if (this.Size == Vector2i.Zero || that.Size == Vector2i.Zero)
                return Range2i.Zero;

            var min = Vector2i.Max(this.Min, that.Min);
            var max = Vector2i.Max(Vector2i.Min(this.Max, that.Max), min);

            return Range2i.FromMinAndMax(min, max);
        }

        public Range2i UnionWith(Range2i? that)
        {
            if (that == null)
                return this;
            else
                return UnionWith(that.Value);
        }

        public Range2i UnionWith(Range2i that)
        {
            if (this.Size == Vector2i.Zero || that.Size == Vector2i.Zero)
                return Range2i.Zero;

            var min = Vector2i.Min(this.Min, that.Min);
            var max = Vector2i.Max(this.Max, that.Max);

            return Range2i.FromMinAndMax(min, max);
        }

        public Area3f ToArea3fFromMinMax(float minZ, float maxZ)
        {
            return Area3f.FromMinAndMax(Min.ToVector3f(minZ), Max.ToVector3f(maxZ));
        }

        public bool Equals(Range2i other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Range2i))
                return false;

            return this.Equals((Range2i)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Min.GetHashCode() + 7 * Max.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"Range2i: min={Min} max={Max} size={Size}";
        }
    }
}