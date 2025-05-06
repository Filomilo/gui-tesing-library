using System;

namespace gui_tesing_library.Models
{
    public class Color
    {
        public static readonly Color Red = new Color(1f, 0f, 0f);
        public static readonly object Black = new Color(0f, 0f, 0f);
        public static readonly object Pink = new Color(55, 192, 103);
        public static readonly object Yellow = new Color(1f, 1f, 0f);
        public static readonly object Aqua = new Color(207, 157, 150);
        public static readonly object Orange = new Color(131, 117, 127);
        public static readonly object Green = new Color(0, 128, 0);
        public static readonly object Blue = new Color(0f, 0f, 1f);
        public static readonly object White = new Color(1f, 1f, 1f);
        public static readonly object Lime = new Color(0f, 1f, 0f);

        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }

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

        public Color(System.Drawing.Color color)
        {
            this.r = color.R;
            this.g = color.G;
            this.b = color.B;
        }

        public Color(Color_CS color_CS)
        {
            this.r = color_CS.r;
            this.g = color_CS.g;
            this.b = color_CS.b;
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

        public Double getDiffrence(Color color)
        {
            int rdiff = this.r - color.r;
            int gdiff = this.g - color.g;
            int bdiff = this.b - color.b;
            return Math.Sqrt(
                Math.Pow(Math.Sqrt(Math.Pow(rdiff, 2) + Math.Pow(bdiff, 2)), 2) + Math.Pow(gdiff, 2)
            );
        }

        internal Color_CS Native()
        {
            return Color_CS.create(this.r, this.g, this.b);
        }
    }
}
