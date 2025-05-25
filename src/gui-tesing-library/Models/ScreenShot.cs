using gui_tesing_library.Interfaces;

namespace gui_tesing_library.Models;

public class ScreenShot : IScreenShot
{
    private readonly ScreenShot_CS screenShot;

    public ScreenShot(ScreenShot_CS screenShot_CS)
    {
        screenShot = screenShot_CS;
    }

    public int Width => screenShot.GetWidth();

    public int Height => screenShot.GetHeight();

    public double CompareToImage(string filePathToComparingImage)
    {
        return screenShot.CompareToImage(filePathToComparingImage);
    }

    public Color GetPixelColorAt(Vector2i pos)
    {
        return new Color(screenShot.GetPixelColorAt(pos.Native()));
    }

    public void SaveAsBitmap(string file)
    {
        screenShot.SaveAsBitmap(file);
    }

    public IScreenShot SimmilarityBetweenImagesShouldBe(string ImagePath, double simmilarity)
    {
        screenShot.SimmilarityBetweenImagesShouldBe(ImagePath, simmilarity);
        return this;
    }
}