using System;

namespace Votyra.Core.Models
{
    public struct Ray6f : IEquatable<Ray6f>
    {
        public readonly Vector6f Origin;
        public readonly Vector6f Direction;

        public Ray2f X0X0() => new Ray2f(this.Origin.X0X0(), this.Direction.X0X0());

        public Ray2f X0X1() => new Ray2f(this.Origin.X0X1(), this.Direction.X0X1());

        public Ray2f X0X2() => new Ray2f(this.Origin.X0X2(), this.Direction.X0X2());

        public Ray2f X0X3() => new Ray2f(this.Origin.X0X3(), this.Direction.X0X3());

        public Ray2f X0X4() => new Ray2f(this.Origin.X0X4(), this.Direction.X0X4());

        public Ray2f X0X5() => new Ray2f(this.Origin.X0X5(), this.Direction.X0X5());

        public Ray2f X1X0() => new Ray2f(this.Origin.X1X0(), this.Direction.X1X0());

        public Ray2f X1X1() => new Ray2f(this.Origin.X1X1(), this.Direction.X1X1());

        public Ray2f X1X2() => new Ray2f(this.Origin.X1X2(), this.Direction.X1X2());

        public Ray2f X1X3() => new Ray2f(this.Origin.X1X3(), this.Direction.X1X3());

        public Ray2f X1X4() => new Ray2f(this.Origin.X1X4(), this.Direction.X1X4());

        public Ray2f X1X5() => new Ray2f(this.Origin.X1X5(), this.Direction.X1X5());

        public Ray2f X2X0() => new Ray2f(this.Origin.X2X0(), this.Direction.X2X0());

        public Ray2f X2X1() => new Ray2f(this.Origin.X2X1(), this.Direction.X2X1());

        public Ray2f X2X2() => new Ray2f(this.Origin.X2X2(), this.Direction.X2X2());

        public Ray2f X2X3() => new Ray2f(this.Origin.X2X3(), this.Direction.X2X3());

        public Ray2f X2X4() => new Ray2f(this.Origin.X2X4(), this.Direction.X2X4());

        public Ray2f X2X5() => new Ray2f(this.Origin.X2X5(), this.Direction.X2X5());

        public Ray2f X3X0() => new Ray2f(this.Origin.X3X0(), this.Direction.X3X0());

        public Ray2f X3X1() => new Ray2f(this.Origin.X3X1(), this.Direction.X3X1());

        public Ray2f X3X2() => new Ray2f(this.Origin.X3X2(), this.Direction.X3X2());

        public Ray2f X3X3() => new Ray2f(this.Origin.X3X3(), this.Direction.X3X3());

        public Ray2f X3X4() => new Ray2f(this.Origin.X3X4(), this.Direction.X3X4());

        public Ray2f X3X5() => new Ray2f(this.Origin.X3X5(), this.Direction.X3X5());

        public Ray2f X4X0() => new Ray2f(this.Origin.X4X0(), this.Direction.X4X0());

        public Ray2f X4X1() => new Ray2f(this.Origin.X4X1(), this.Direction.X4X1());

        public Ray2f X4X2() => new Ray2f(this.Origin.X4X2(), this.Direction.X4X2());

        public Ray2f X4X3() => new Ray2f(this.Origin.X4X3(), this.Direction.X4X3());

        public Ray2f X4X4() => new Ray2f(this.Origin.X4X4(), this.Direction.X4X4());

        public Ray2f X4X5() => new Ray2f(this.Origin.X4X5(), this.Direction.X4X5());

        public Ray2f X5X0() => new Ray2f(this.Origin.X5X0(), this.Direction.X5X0());

        public Ray2f X5X1() => new Ray2f(this.Origin.X5X1(), this.Direction.X5X1());

        public Ray2f X5X2() => new Ray2f(this.Origin.X5X2(), this.Direction.X5X2());

        public Ray2f X5X3() => new Ray2f(this.Origin.X5X3(), this.Direction.X5X3());

        public Ray2f X5X4() => new Ray2f(this.Origin.X5X4(), this.Direction.X5X4());

        public Ray2f X5X5() => new Ray2f(this.Origin.X5X5(), this.Direction.X5X5());

        public Vector6f ToAt1 => this.Origin + this.Direction;

        public Ray6f(Vector6f origin, Vector6f direction)
        {
            this.Origin = origin;
            this.Direction = direction.Normalized();
        }

        public Vector6f GetPoint(float distance) => this.Origin + (this.Direction * distance);

        public bool Equals(Ray6f other) => this.Origin.Equals(other.Origin) && this.Direction.Equals(other.Direction);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Ray6f other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Origin.GetHashCode() * 397) ^ this.Direction.GetHashCode();
            }
        }

        public override string ToString() => $"origin:{this.Origin} dir:{this.Direction}";
    }
}
