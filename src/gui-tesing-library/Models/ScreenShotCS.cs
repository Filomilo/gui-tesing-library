using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using gui_tesing_library_CS.Services;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using Color = gui_tesing_library.Models.Color;

namespace gui_tesing_library_CS.Models;

public class ScreenShotCS : IScreenShot
{
    private readonly Color[,] pixels;

    public ScreenShotCS(Bitmap bmp)
    {
        pixels = new Color[bmp.Width, bmp.Height];
        for (var x = 0; x < bmp.Width; x++)
        for (var y = 0; y < bmp.Height; y++)
            pixels[x, y] = new Color(bmp.GetPixel(x, y));
    }

    public int Width => pixels.GetLength(0);

    public int Height => pixels.GetLength(1);

    public Color GetPixelColorAt(Vector2i pos)
    {
        return pixels[pos.x, pos.y];
    }

    public void SaveAsBitmap(string file)
    {
        var bmp = new Bitmap(pixels.GetLength(0), pixels.GetLength(1));
        for (var x = 0; x < Width; x++)
        for (var y = 0; y < Height; y++)
            bmp.SetPixel(
                x,
                y,
                System.Drawing.Color.FromArgb(
                    GetPixelColorAt(new Vector2i(x, y)).r,
                    GetPixelColorAt(new Vector2i(x, y)).g,
                    GetPixelColorAt(new Vector2i(x, y)).b
                )
            );

        bmp.Save(file, ImageFormat.Bmp);
    }

    public double CompareToImage(string filePathToComparingImage)
    {
        var comparer = ImageComparerFactory.GetComparer();
        var tmpPath = Path.GetTempPath() + Guid.NewGuid() + ".bmp";
        SaveAsBitmap(tmpPath);
        double simmilarity = 0;
        using (var stram1 = File.OpenRead(tmpPath))
        {
            using (var stram2 = File.OpenRead(filePathToComparingImage))
            {
                simmilarity = comparer.CompareImages(stram1, stram2);
            }
        }

        File.Delete(tmpPath);
        return simmilarity;
    }

    public IScreenShot SimmilarityBetweenImagesShouldBe(string ImagePath, double simmilarity)
    {
        var simmilarityOfImage = CompareToImage(ImagePath);
        if (simmilarityOfImage > simmilarity)
            return this;

        throw new Exception(
            $"Simmilarity of images is {simmilarityOfImage} but should be {simmilarity}"
        );
    }
}