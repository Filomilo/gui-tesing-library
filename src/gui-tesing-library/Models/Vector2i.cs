using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library.Controllers
{
    public class Vector2i
    {
        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }

        public float Length
        {
            get { return (float)Math.Sqrt(Math.Pow((double)x, 2) + Math.Pow((double)y, 2)); }
        }

        protected bool Equals(Vector2i other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Vector2i)obj);
        }

        public override string ToString()
        {
            return $"[{x};{y}]";
        }

        internal int Area()
        {
            return x * y;
        }

        public static Vector2i operator +(Vector2i a, Vector2i b) =>
            new Vector2i(a.x + b.x, a.y + b.y);

        public static Vector2i operator -(Vector2i a, Vector2i b) =>
            new Vector2i(a.x - b.x, a.y - b.y);

        public static Vector2i operator /(Vector2i a, int b) => new Vector2i(a.x / b, a.y / 2);

        public static Vector2i operator /(Vector2i a, Vector2i b) =>
            new Vector2i(a.x / b.x, a.y / b.y);

        public static explicit operator Vector2i(Vector2f v)
        {
            return new Vector2i((int)v.x, (int)v.y);
        }
    }

    public class Vector2f
    {
        public Vector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float x { get; set; }
        public float y { get; set; }

        protected bool Equals(Vector2f other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Vector2f)obj);
        }

        public override string ToString()
        {
            return $"[{x};{y}]";
        }

        internal float Area()
        {
            return x * y;
        }

        public float DistanceFrom(Vector2f pos)
        {
            Vector2f distance = new Vector2f(this.x - pos.x, this.y - pos.y);
            return (float)Math.Sqrt(Math.Pow((double)distance.x, 2) + Math.Pow((double)distance.y, 2));
        }

        public static Vector2f operator +(Vector2f a, Vector2f b) =>
            new Vector2f(a.x + b.x, a.y + b.y);

        public static Vector2f operator -(Vector2f a, Vector2f b) =>
            new Vector2f(a.x - b.x, a.y - b.y);

        public static Vector2f operator /(Vector2f a, int b) => new Vector2f(a.x / b, a.y / b);

        public static Vector2f operator /(Vector2f a, Vector2f b) =>
            new Vector2f(a.x / b.x, a.y / b.y);

        public static explicit operator Vector2f(Vector2i v)
        {
            return new Vector2f((int)v.x, (int)v.y);
        }
    }
}
