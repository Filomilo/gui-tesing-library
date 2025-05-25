using gui_tesing_library.Models;

namespace gui_tesing_library.Interfaces;

public interface IScreenShot
{
    int Width { get; }
    int Height { get; }
    Color GetPixelColorAt(Vector2i pos);
    void SaveAsBitmap(string file);
    double CompareToImage(string filePathToComparingImage);
    IScreenShot SimmilarityBetweenImagesShouldBe(string ImagePath, double simmilarity);
}