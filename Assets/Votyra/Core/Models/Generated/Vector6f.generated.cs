using System;
using Newtonsoft.Json;
using Votyra.Core.Utils;

namespace Votyra.Core.Models
{
    
    
    
    
        
        
    
    
    
    
    
    
    
    
    
    
    
    

    
    public partial struct Vector6f : IEquatable<Vector6f>
    {
        public static readonly Vector6f One = new Vector6f(1, 1, 1, 1, 1, 1);
        public static readonly Vector6f Zero = new Vector6f(0, 0, 0, 0, 0, 0);

        
        public readonly float X0;
        
        public readonly float X1;
        
        public readonly float X2;
        
        public readonly float X3;
        
        public readonly float X4;
        
        public readonly float X5;
        

        [JsonConstructor]
        public Vector6f(float x0, float x1, float x2, float x3, float x4, float x5)
        {
            
            X0 = x0;
            
            X1 = x1;
            
            X2 = x2;
            
            X3 = x3;
            
            X4 = x4;
            
            X5 = x5;
            
        }

        
            public static Vector6f operator -(Vector6f a) => new Vector6f(-a.X0, -a.X1, -a.X2, -a.X3, -a.X4, -a.X5);
        
        

        


            public static Vector6f operator *(Vector6f a, Vector6f b) =>  new Vector6f(a.X0 *  b.X0 , a.X1 *  b.X1 , a.X2 *  b.X2 , a.X3 *  b.X3 , a.X4 *  b.X4 , a.X5 *  b.X5 );

            public static Vector6f operator *(Vector6f a, float b) =>  new Vector6f(a.X0 *  b , a.X1 *  b , a.X2 *  b , a.X3 *  b , a.X4 *  b , a.X5 *  b );

            public static Vector6f operator *(float a, Vector6f b) =>  new Vector6f(a *  b.X0 , a *  b.X1 , a *  b.X2 , a *  b.X3 , a *  b.X4 , a *  b.X5 );
            

            public static Vector6f operator *(Vector6f a, int b) =>  new Vector6f(a.X0 *  b , a.X1 *  b , a.X2 *  b , a.X3 *  b , a.X4 *  b , a.X5 *  b );

            public static Vector6f operator *(int a, Vector6f b) =>  new Vector6f(a *  b.X0 , a *  b.X1 , a *  b.X2 , a *  b.X3 , a *  b.X4 , a *  b.X5 );
        

        


            public static Vector6f operator +(Vector6f a, Vector6f b) =>  new Vector6f(a.X0 +  b.X0 , a.X1 +  b.X1 , a.X2 +  b.X2 , a.X3 +  b.X3 , a.X4 +  b.X4 , a.X5 +  b.X5 );

            public static Vector6f operator +(Vector6f a, float b) =>  new Vector6f(a.X0 +  b , a.X1 +  b , a.X2 +  b , a.X3 +  b , a.X4 +  b , a.X5 +  b );

            public static Vector6f operator +(float a, Vector6f b) =>  new Vector6f(a +  b.X0 , a +  b.X1 , a +  b.X2 , a +  b.X3 , a +  b.X4 , a +  b.X5 );
            

            public static Vector6f operator +(Vector6f a, int b) =>  new Vector6f(a.X0 +  b , a.X1 +  b , a.X2 +  b , a.X3 +  b , a.X4 +  b , a.X5 +  b );

            public static Vector6f operator +(int a, Vector6f b) =>  new Vector6f(a +  b.X0 , a +  b.X1 , a +  b.X2 , a +  b.X3 , a +  b.X4 , a +  b.X5 );
        

        


            public static Vector6f operator -(Vector6f a, Vector6f b) =>  new Vector6f(a.X0 -  b.X0 , a.X1 -  b.X1 , a.X2 -  b.X2 , a.X3 -  b.X3 , a.X4 -  b.X4 , a.X5 -  b.X5 );

            public static Vector6f operator -(Vector6f a, float b) =>  new Vector6f(a.X0 -  b , a.X1 -  b , a.X2 -  b , a.X3 -  b , a.X4 -  b , a.X5 -  b );

            public static Vector6f operator -(float a, Vector6f b) =>  new Vector6f(a -  b.X0 , a -  b.X1 , a -  b.X2 , a -  b.X3 , a -  b.X4 , a -  b.X5 );
            

            public static Vector6f operator -(Vector6f a, int b) =>  new Vector6f(a.X0 -  b , a.X1 -  b , a.X2 -  b , a.X3 -  b , a.X4 -  b , a.X5 -  b );

            public static Vector6f operator -(int a, Vector6f b) =>  new Vector6f(a -  b.X0 , a -  b.X1 , a -  b.X2 , a -  b.X3 , a -  b.X4 , a -  b.X5 );
        

        


            public static Vector6f operator /(Vector6f a, Vector6f b) =>  new Vector6f(a.X0 /  b.X0 , a.X1 /  b.X1 , a.X2 /  b.X2 , a.X3 /  b.X3 , a.X4 /  b.X4 , a.X5 /  b.X5 );

            public static Vector6f operator /(Vector6f a, float b) =>  new Vector6f(a.X0 /  b , a.X1 /  b , a.X2 /  b , a.X3 /  b , a.X4 /  b , a.X5 /  b );

            public static Vector6f operator /(float a, Vector6f b) =>  new Vector6f(a /  b.X0 , a /  b.X1 , a /  b.X2 , a /  b.X3 , a /  b.X4 , a /  b.X5 );
            

            public static Vector6f operator /(Vector6f a, int b) =>  new Vector6f(a.X0 /  b , a.X1 /  b , a.X2 /  b , a.X3 /  b , a.X4 /  b , a.X5 /  b );

            public static Vector6f operator /(int a, Vector6f b) =>  new Vector6f(a /  b.X0 , a /  b.X1 , a /  b.X2 , a /  b.X3 , a /  b.X4 , a /  b.X5 );
        

        


            public static Vector6f operator %(Vector6f a, Vector6f b) =>  new Vector6f(a.X0 %  b.X0 , a.X1 %  b.X1 , a.X2 %  b.X2 , a.X3 %  b.X3 , a.X4 %  b.X4 , a.X5 %  b.X5 );

            public static Vector6f operator %(Vector6f a, float b) =>  new Vector6f(a.X0 %  b , a.X1 %  b , a.X2 %  b , a.X3 %  b , a.X4 %  b , a.X5 %  b );

            public static Vector6f operator %(float a, Vector6f b) =>  new Vector6f(a %  b.X0 , a %  b.X1 , a %  b.X2 , a %  b.X3 , a %  b.X4 , a %  b.X5 );
            

            public static Vector6f operator %(Vector6f a, int b) =>  new Vector6f(a.X0 %  b , a.X1 %  b , a.X2 %  b , a.X3 %  b , a.X4 %  b , a.X5 %  b );

            public static Vector6f operator %(int a, Vector6f b) =>  new Vector6f(a %  b.X0 , a %  b.X1 , a %  b.X2 , a %  b.X3 , a %  b.X4 , a %  b.X5 );
        

        


            public static bool operator <(Vector6f a, Vector6f b) =>  a.X0 <  b.X0  && a.X1 <  b.X1  && a.X2 <  b.X2  && a.X3 <  b.X3  && a.X4 <  b.X4  && a.X5 <  b.X5 ;

            public static bool operator <(Vector6f a, float b) =>  a.X0 <  b  && a.X1 <  b  && a.X2 <  b  && a.X3 <  b  && a.X4 <  b  && a.X5 <  b ;

            public static bool operator <(float a, Vector6f b) =>  a <  b.X0  && a <  b.X1  && a <  b.X2  && a <  b.X3  && a <  b.X4  && a <  b.X5 ;
            

            public static bool operator <(Vector6f a, int b) =>  a.X0 <  b  && a.X1 <  b  && a.X2 <  b  && a.X3 <  b  && a.X4 <  b  && a.X5 <  b ;

            public static bool operator <(int a, Vector6f b) =>  a <  b.X0  && a <  b.X1  && a <  b.X2  && a <  b.X3  && a <  b.X4  && a <  b.X5 ;
        

        


            public static bool operator >(Vector6f a, Vector6f b) =>  a.X0 >  b.X0  && a.X1 >  b.X1  && a.X2 >  b.X2  && a.X3 >  b.X3  && a.X4 >  b.X4  && a.X5 >  b.X5 ;

            public static bool operator >(Vector6f a, float b) =>  a.X0 >  b  && a.X1 >  b  && a.X2 >  b  && a.X3 >  b  && a.X4 >  b  && a.X5 >  b ;

            public static bool operator >(float a, Vector6f b) =>  a >  b.X0  && a >  b.X1  && a >  b.X2  && a >  b.X3  && a >  b.X4  && a >  b.X5 ;
            

            public static bool operator >(Vector6f a, int b) =>  a.X0 >  b  && a.X1 >  b  && a.X2 >  b  && a.X3 >  b  && a.X4 >  b  && a.X5 >  b ;

            public static bool operator >(int a, Vector6f b) =>  a >  b.X0  && a >  b.X1  && a >  b.X2  && a >  b.X3  && a >  b.X4  && a >  b.X5 ;
        

        


            public static bool operator <=(Vector6f a, Vector6f b) =>  a.X0 <=  b.X0  && a.X1 <=  b.X1  && a.X2 <=  b.X2  && a.X3 <=  b.X3  && a.X4 <=  b.X4  && a.X5 <=  b.X5 ;

            public static bool operator <=(Vector6f a, float b) =>  a.X0 <=  b  && a.X1 <=  b  && a.X2 <=  b  && a.X3 <=  b  && a.X4 <=  b  && a.X5 <=  b ;

            public static bool operator <=(float a, Vector6f b) =>  a <=  b.X0  && a <=  b.X1  && a <=  b.X2  && a <=  b.X3  && a <=  b.X4  && a <=  b.X5 ;
            

            public static bool operator <=(Vector6f a, int b) =>  a.X0 <=  b  && a.X1 <=  b  && a.X2 <=  b  && a.X3 <=  b  && a.X4 <=  b  && a.X5 <=  b ;

            public static bool operator <=(int a, Vector6f b) =>  a <=  b.X0  && a <=  b.X1  && a <=  b.X2  && a <=  b.X3  && a <=  b.X4  && a <=  b.X5 ;
        

        


            public static bool operator >=(Vector6f a, Vector6f b) =>  a.X0 >=  b.X0  && a.X1 >=  b.X1  && a.X2 >=  b.X2  && a.X3 >=  b.X3  && a.X4 >=  b.X4  && a.X5 >=  b.X5 ;

            public static bool operator >=(Vector6f a, float b) =>  a.X0 >=  b  && a.X1 >=  b  && a.X2 >=  b  && a.X3 >=  b  && a.X4 >=  b  && a.X5 >=  b ;

            public static bool operator >=(float a, Vector6f b) =>  a >=  b.X0  && a >=  b.X1  && a >=  b.X2  && a >=  b.X3  && a >=  b.X4  && a >=  b.X5 ;
            

            public static bool operator >=(Vector6f a, int b) =>  a.X0 >=  b  && a.X1 >=  b  && a.X2 >=  b  && a.X3 >=  b  && a.X4 >=  b  && a.X5 >=  b ;

            public static bool operator >=(int a, Vector6f b) =>  a >=  b.X0  && a >=  b.X1  && a >=  b.X2  && a >=  b.X3  && a >=  b.X4  && a >=  b.X5 ;
        

        


            public static bool operator ==(Vector6f a, Vector6f b) =>  a.X0 ==  b.X0  && a.X1 ==  b.X1  && a.X2 ==  b.X2  && a.X3 ==  b.X3  && a.X4 ==  b.X4  && a.X5 ==  b.X5 ;

            public static bool operator ==(Vector6f a, float b) =>  a.X0 ==  b  && a.X1 ==  b  && a.X2 ==  b  && a.X3 ==  b  && a.X4 ==  b  && a.X5 ==  b ;

            public static bool operator ==(float a, Vector6f b) =>  a ==  b.X0  && a ==  b.X1  && a ==  b.X2  && a ==  b.X3  && a ==  b.X4  && a ==  b.X5 ;
            

            public static bool operator ==(Vector6f a, int b) =>  a.X0 ==  b  && a.X1 ==  b  && a.X2 ==  b  && a.X3 ==  b  && a.X4 ==  b  && a.X5 ==  b ;

            public static bool operator ==(int a, Vector6f b) =>  a ==  b.X0  && a ==  b.X1  && a ==  b.X2  && a ==  b.X3  && a ==  b.X4  && a ==  b.X5 ;
        

        


            public static bool operator !=(Vector6f a, Vector6f b) =>  a.X0 !=  b.X0  || a.X1 !=  b.X1  || a.X2 !=  b.X2  || a.X3 !=  b.X3  || a.X4 !=  b.X4  || a.X5 !=  b.X5 ;

            public static bool operator !=(Vector6f a, float b) =>  a.X0 !=  b  || a.X1 !=  b  || a.X2 !=  b  || a.X3 !=  b  || a.X4 !=  b  || a.X5 !=  b ;

            public static bool operator !=(float a, Vector6f b) =>  a !=  b.X0  || a !=  b.X1  || a !=  b.X2  || a !=  b.X3  || a !=  b.X4  || a !=  b.X5 ;
            

            public static bool operator !=(Vector6f a, int b) =>  a.X0 !=  b  || a.X1 !=  b  || a.X2 !=  b  || a.X3 !=  b  || a.X4 !=  b  || a.X5 !=  b ;

            public static bool operator !=(int a, Vector6f b) =>  a !=  b.X0  || a !=  b.X1  || a !=  b.X2  || a !=  b.X3  || a !=  b.X4  || a !=  b.X5 ;
        

        public bool Equals(Vector6f other) => this == other;

        public override bool Equals(object obj)
        {
            if (!(obj is Vector6f))
                return false;

            return Equals((Vector6f) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X0.GetHashCode() * 397) ^ (X1.GetHashCode() * 397) ^ (X2.GetHashCode() * 397) ^ (X3.GetHashCode() * 397) ^ (X4.GetHashCode() * 397) ^ (X5.GetHashCode() * 397);
            }
        }

        public override string ToString() => "("+ X0 + "," +  X1 + "," +  X2 + "," +  X3 + "," +  X4 + "," +  X5 +")";
    }
    


    public static class Vector6fUtils
    {
        
            
                
                public static Vector2f X0X0(this Vector6f @this) => new Vector2f(@this.X0, @this.X0);
                
                public static Vector2f X0X1(this Vector6f @this) => new Vector2f(@this.X0, @this.X1);
                
                public static Vector2f X0X2(this Vector6f @this) => new Vector2f(@this.X0, @this.X2);
                
                public static Vector2f X0X3(this Vector6f @this) => new Vector2f(@this.X0, @this.X3);
                
                public static Vector2f X0X4(this Vector6f @this) => new Vector2f(@this.X0, @this.X4);
                
                public static Vector2f X0X5(this Vector6f @this) => new Vector2f(@this.X0, @this.X5);
                
            
                
                public static Vector2f X1X0(this Vector6f @this) => new Vector2f(@this.X1, @this.X0);
                
                public static Vector2f X1X1(this Vector6f @this) => new Vector2f(@this.X1, @this.X1);
                
                public static Vector2f X1X2(this Vector6f @this) => new Vector2f(@this.X1, @this.X2);
                
                public static Vector2f X1X3(this Vector6f @this) => new Vector2f(@this.X1, @this.X3);
                
                public static Vector2f X1X4(this Vector6f @this) => new Vector2f(@this.X1, @this.X4);
                
                public static Vector2f X1X5(this Vector6f @this) => new Vector2f(@this.X1, @this.X5);
                
            
                
                public static Vector2f X2X0(this Vector6f @this) => new Vector2f(@this.X2, @this.X0);
                
                public static Vector2f X2X1(this Vector6f @this) => new Vector2f(@this.X2, @this.X1);
                
                public static Vector2f X2X2(this Vector6f @this) => new Vector2f(@this.X2, @this.X2);
                
                public static Vector2f X2X3(this Vector6f @this) => new Vector2f(@this.X2, @this.X3);
                
                public static Vector2f X2X4(this Vector6f @this) => new Vector2f(@this.X2, @this.X4);
                
                public static Vector2f X2X5(this Vector6f @this) => new Vector2f(@this.X2, @this.X5);
                
            
                
                public static Vector2f X3X0(this Vector6f @this) => new Vector2f(@this.X3, @this.X0);
                
                public static Vector2f X3X1(this Vector6f @this) => new Vector2f(@this.X3, @this.X1);
                
                public static Vector2f X3X2(this Vector6f @this) => new Vector2f(@this.X3, @this.X2);
                
                public static Vector2f X3X3(this Vector6f @this) => new Vector2f(@this.X3, @this.X3);
                
                public static Vector2f X3X4(this Vector6f @this) => new Vector2f(@this.X3, @this.X4);
                
                public static Vector2f X3X5(this Vector6f @this) => new Vector2f(@this.X3, @this.X5);
                
            
                
                public static Vector2f X4X0(this Vector6f @this) => new Vector2f(@this.X4, @this.X0);
                
                public static Vector2f X4X1(this Vector6f @this) => new Vector2f(@this.X4, @this.X1);
                
                public static Vector2f X4X2(this Vector6f @this) => new Vector2f(@this.X4, @this.X2);
                
                public static Vector2f X4X3(this Vector6f @this) => new Vector2f(@this.X4, @this.X3);
                
                public static Vector2f X4X4(this Vector6f @this) => new Vector2f(@this.X4, @this.X4);
                
                public static Vector2f X4X5(this Vector6f @this) => new Vector2f(@this.X4, @this.X5);
                
            
                
                public static Vector2f X5X0(this Vector6f @this) => new Vector2f(@this.X5, @this.X0);
                
                public static Vector2f X5X1(this Vector6f @this) => new Vector2f(@this.X5, @this.X1);
                
                public static Vector2f X5X2(this Vector6f @this) => new Vector2f(@this.X5, @this.X2);
                
                public static Vector2f X5X3(this Vector6f @this) => new Vector2f(@this.X5, @this.X3);
                
                public static Vector2f X5X4(this Vector6f @this) => new Vector2f(@this.X5, @this.X4);
                
                public static Vector2f X5X5(this Vector6f @this) => new Vector2f(@this.X5, @this.X5);
                
            
        

        public static bool AnyNegative(this Vector6f @this) => @this.X0<0 || @this.X1<0 || @this.X2<0 || @this.X3<0 || @this.X4<0 || @this.X5<0;

        public static float AreaSum(this Vector6f @this) => @this.X0 * @this.X1 * @this.X2 * @this.X3 * @this.X4 * @this.X5;

        public static float Magnitude(this Vector6f @this) => (float) Math.Sqrt(@this.SqrMagnitude());

        public static Vector6f Normalized(this Vector6f @this)
        {
            var magnitude=@this.Magnitude();
            return magnitude<= float.Epsilon ? @this : @this / magnitude;
        } 

        public static float SqrMagnitude(this Vector6f @this) => @this.X0*@this.X0 +  @this.X1*@this.X1 +  @this.X2*@this.X2 +  @this.X3*@this.X3 +  @this.X4*@this.X4 +  @this.X5*@this.X5 ;

        

        public static Vector6f FromSame(float value) => new Vector6f(value,  value,  value,  value,  value,  value );

        public static float Dot(Vector6f a, Vector6f b) => (float)((double)a.X0*b.X0 +  (double)a.X1*b.X1 +  (double)a.X2*b.X2 +  (double)a.X3*b.X3 +  (double)a.X4*b.X4 +  (double)a.X5*b.X5 );

        

        
            public static Vector6f Ceil(this Vector6f @this) => new Vector6f(MathUtils.CeilToInt(@this.X0), MathUtils.CeilToInt(@this.X1), MathUtils.CeilToInt(@this.X2), MathUtils.CeilToInt(@this.X3), MathUtils.CeilToInt(@this.X4), MathUtils.CeilToInt(@this.X5));
            
                public static Vector6i CeilToVector6i(this Vector6f @this) => new Vector6i(MathUtils.CeilToInt(@this.X0), MathUtils.CeilToInt(@this.X1), MathUtils.CeilToInt(@this.X2), MathUtils.CeilToInt(@this.X3), MathUtils.CeilToInt(@this.X4), MathUtils.CeilToInt(@this.X5));
            
        
            public static Vector6f Abs(this Vector6f @this) => new Vector6f(Math.Abs(@this.X0), Math.Abs(@this.X1), Math.Abs(@this.X2), Math.Abs(@this.X3), Math.Abs(@this.X4), Math.Abs(@this.X5));
            
        
            public static Vector6f Floor(this Vector6f @this) => new Vector6f(MathUtils.FloorToInt(@this.X0), MathUtils.FloorToInt(@this.X1), MathUtils.FloorToInt(@this.X2), MathUtils.FloorToInt(@this.X3), MathUtils.FloorToInt(@this.X4), MathUtils.FloorToInt(@this.X5));
            
                public static Vector6i FloorToVector6i(this Vector6f @this) => new Vector6i(MathUtils.FloorToInt(@this.X0), MathUtils.FloorToInt(@this.X1), MathUtils.FloorToInt(@this.X2), MathUtils.FloorToInt(@this.X3), MathUtils.FloorToInt(@this.X4), MathUtils.FloorToInt(@this.X5));
            
        
            public static Vector6f Round(this Vector6f @this) => new Vector6f(MathUtils.RoundToInt(@this.X0), MathUtils.RoundToInt(@this.X1), MathUtils.RoundToInt(@this.X2), MathUtils.RoundToInt(@this.X3), MathUtils.RoundToInt(@this.X4), MathUtils.RoundToInt(@this.X5));
            
                public static Vector6i RoundToVector6i(this Vector6f @this) => new Vector6i(MathUtils.RoundToInt(@this.X0), MathUtils.RoundToInt(@this.X1), MathUtils.RoundToInt(@this.X2), MathUtils.RoundToInt(@this.X3), MathUtils.RoundToInt(@this.X4), MathUtils.RoundToInt(@this.X5));
            
        

        
        

        public static Area6f ToArea6f(this Vector6f @this) =>  Area6f.FromMinAndSize(Vector6f.Zero, @this);

        

        

        

        public static Vector6f Max(Vector6f a, Vector6f b) => new Vector6f(Math.Max(a.X0,  b.X0) , Math.Max(a.X1,  b.X1) , Math.Max(a.X2,  b.X2) , Math.Max(a.X3,  b.X3) , Math.Max(a.X4,  b.X4) , Math.Max(a.X5,  b.X5) );

        

        public static Vector6f Max(Vector6f a, float b) => new Vector6f(Math.Max(a.X0,  b) , Math.Max(a.X1,  b) , Math.Max(a.X2,  b) , Math.Max(a.X3,  b) , Math.Max(a.X4,  b) , Math.Max(a.X5,  b) );

        public static Vector6f Max(float a, Vector6f b) => new Vector6f(Math.Max(a,  b.X0) , Math.Max(a,  b.X1) , Math.Max(a,  b.X2) , Math.Max(a,  b.X3) , Math.Max(a,  b.X4) , Math.Max(a,  b.X5) );
        

        public static Vector6f Max(Vector6f a, int b) => new Vector6f(Math.Max(a.X0,  b) , Math.Max(a.X1,  b) , Math.Max(a.X2,  b) , Math.Max(a.X3,  b) , Math.Max(a.X4,  b) , Math.Max(a.X5,  b) );

        public static Vector6f Max(int a, Vector6f b) => new Vector6f(Math.Max(a,  b.X0) , Math.Max(a,  b.X1) , Math.Max(a,  b.X2) , Math.Max(a,  b.X3) , Math.Max(a,  b.X4) , Math.Max(a,  b.X5) );
    

        

        public static Vector6f Min(Vector6f a, Vector6f b) => new Vector6f(Math.Min(a.X0,  b.X0) , Math.Min(a.X1,  b.X1) , Math.Min(a.X2,  b.X2) , Math.Min(a.X3,  b.X3) , Math.Min(a.X4,  b.X4) , Math.Min(a.X5,  b.X5) );

        

        public static Vector6f Min(Vector6f a, float b) => new Vector6f(Math.Min(a.X0,  b) , Math.Min(a.X1,  b) , Math.Min(a.X2,  b) , Math.Min(a.X3,  b) , Math.Min(a.X4,  b) , Math.Min(a.X5,  b) );

        public static Vector6f Min(float a, Vector6f b) => new Vector6f(Math.Min(a,  b.X0) , Math.Min(a,  b.X1) , Math.Min(a,  b.X2) , Math.Min(a,  b.X3) , Math.Min(a,  b.X4) , Math.Min(a,  b.X5) );
        

        public static Vector6f Min(Vector6f a, int b) => new Vector6f(Math.Min(a.X0,  b) , Math.Min(a.X1,  b) , Math.Min(a.X2,  b) , Math.Min(a.X3,  b) , Math.Min(a.X4,  b) , Math.Min(a.X5,  b) );

        public static Vector6f Min(int a, Vector6f b) => new Vector6f(Math.Min(a,  b.X0) , Math.Min(a,  b.X1) , Math.Min(a,  b.X2) , Math.Min(a,  b.X3) , Math.Min(a,  b.X4) , Math.Min(a,  b.X5) );
    
    }
}