using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library.Models
{
    public class Color
    {
        private int r { get; set; }
        private int g { get; set; }
        private int b { get; set; }

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public Color(float r, float g, float b)
        {
            this.r = (int)(r * 255);
            this.g = (int)(g * 255);
            this.b = (int)(b * 255);
        }

        public override string ToString()
        {
            return $"[{r},{g},{b}]";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (this is null)
                return false;
            if (obj is null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            return this.r == ((Color)obj).r && this.g == ((Color)obj).g && this.b == ((Color)obj).b;
        }

        public override int GetHashCode()
        {
            return (r << 16) | (g << 8) | b;
        }
    }
}
