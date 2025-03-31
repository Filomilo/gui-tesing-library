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

        public static Vector2i operator +(Vector2i a, Vector2i b) =>
            new Vector2i(a.x + b.x, a.y + b.y);

        public static Vector2i operator -(Vector2i a, Vector2i b) =>
            new Vector2i(a.x - b.x, a.y - b.y);
    }
}
