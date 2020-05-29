using System.Collections.Generic;
using System.Linq;

namespace Votyra.Core.Models
{
    public struct Triangle2f
    {
        public static readonly IEqualityComparer<Triangle2f> OrderInvariantComparer = new TriangleInvariantComparer();
        public readonly Vector2f A;
        public readonly Vector2f B;
        public readonly Vector2f C;

        public Triangle2f(Vector2f a, Vector2f b, Vector2f c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public IEnumerable<Vector2f> Points
        {
            get
            {
                yield return this.A;
                yield return this.B;
                yield return this.C;
            }
        }

        public Triangle2f GetReversedOrder() => new Triangle2f(this.A, this.C, this.B);

        public override bool Equals(object obj)
        {
            if (obj is Triangle2f)
            {
                var that = (Triangle2f)obj;
                return (this.A == that.A) && (this.B == that.B) && (this.C == that.C);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return this.A.GetHashCode() + (this.B.GetHashCode() * 3) + (this.C.GetHashCode() * 7);
            }
        }

        public override string ToString() => $"{this.A},{this.B},{this.C}";

        private class TriangleInvariantComparer : IEqualityComparer<Triangle2f>
        {
            public bool Equals(Triangle2f x, Triangle2f y)
            {
                foreach (var xP in x.Points)
                {
                    if (!y.Points.Any(yP => (xP - yP).SqrMagnitude() < 0.1f))
                    {
                        return false;
                    }
                }

                return true;
            }

            public int GetHashCode(Triangle2f obj) => 0;
        }
    }

    public static class Triangle2fExtensions
    {
        public static IEnumerable<Triangle2f> ChangeOrderIfTrue(this IEnumerable<Triangle2f> triangles, bool value)
        {
            if (value)
            {
                return triangles.Select(o => o.GetReversedOrder());
            }

            return triangles;
        }
    }
}
