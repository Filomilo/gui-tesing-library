using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using gui_tesing_library_CS.Services;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.Controllers;

namespace gui_tesing_library_CS.Models
{
    public class ScreenShotCS : IScreenShot
    {
        gui_tesing_library.Models.Color[,] pixels;

        public int Width
        {
            get { return pixels.GetLength(0); }
        }
        public int Height
        {
            get { return pixels.GetLength(1); }
        }

        public ScreenShotCS(Bitmap bmp)
        {
            this.pixels = new gui_tesing_library.Models.Color[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    pixels[x, y] = new gui_tesing_library.Models.Color(bmp.GetPixel(x, y));
                }
            }
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

        public double CompareToImage(string filePathToComparingImage)
        {
            IImageComparer comparer = ImageComparerFactory.GetComparer();
            string tmpPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".bmp";
            this.SaveAsBitmap(tmpPath);
            double simmilarity = 0;
            using (FileStream stram1 = File.OpenRead(tmpPath))
            {
                using (FileStream stram2 = File.OpenRead(filePathToComparingImage))
                {
                    simmilarity = comparer.CompareImages(stram1, stram2);
                }
            }
            File.Delete(tmpPath);
            return simmilarity;
        }

        public IScreenShot SimmilarityBetweenImagesShouldBe(string ImagePath, double simmilarity)
        {
            double simmilarityOfImage = this.CompareToImage(ImagePath);
            if (simmilarityOfImage > simmilarity)
            {
                return this;
            }
            else
            {
                throw new Exception(
                    $"Simmilarity of images is {simmilarityOfImage} but should be {simmilarity}"
                );
            }
        }
    }
}
