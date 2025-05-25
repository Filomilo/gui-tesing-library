using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;

namespace gui_tesing_library;

public interface IGTScreen
{
    Vector2i Size { get; }

    IScreenShot GetScreenshot();
    IScreenShot GetScreenshotRect(Vector2i position, Vector2i size);
    Color GetPixelColorAt(Vector2i postion);

    IGTScreen PixelAtShouldBeColor(Vector2i position, Color colorColor);
}