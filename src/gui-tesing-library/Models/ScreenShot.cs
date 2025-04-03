using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;

namespace gui_tesing_library.Models
{
    public class ScreenShot
    {
        Color[,] pixels;

        public int Width
        {
            get { return pixels.GetLength(0); }
        }
        public int Height
        {
            get { return pixels.GetLength(1); }
        }

        public ScreenShot(Bitmap bmp)
        {
            this.pixels = new Color[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    pixels[x, y] = new Color(bmp.GetPixel(x, y));
                }
            }
        }

        public ScreenShot(byte[] bitmapData)
        {
            throw new NotImplementedException();
        }

        public gui_tesing_library.Models.Color GetPixelColorAt(Vector2i pos)
        {
            return pixels[pos.x, pos.y];
        }

        public void SaveAsBitmap(string file)
        {
            Bitmap bmp = new Bitmap(pixels.GetLength(0), pixels.GetLength(1));
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    bmp.SetPixel(
                        x,
                        y,
                        System.Drawing.Color.FromArgb(
                            this.GetPixelColorAt(new Vector2i(x, y)).r,
                            this.GetPixelColorAt(new Vector2i(x, y)).g,
                            this.GetPixelColorAt(new Vector2i(x, y)).b
                        )
                    );
                }
            }
            bmp.Save(file, ImageFormat.Bmp);
        }
    }
}
