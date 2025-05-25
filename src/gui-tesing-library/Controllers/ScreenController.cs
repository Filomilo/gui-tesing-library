using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using Lombok.NET;

namespace gui_tesing_library.Controllers;

[Singleton]
public partial class ScreenController : IGTScreen
{
    private static readonly GTScreen_CS gtScreen_Cs = new();

    public Vector2i MaximizedWindowSize => new(gtScreen_Cs.GetMaximizedWindowSize());

    public Vector2i Size => new(gtScreen_Cs.GetSize());

    public IScreenShot GetScreenshot()
    {
        return new ScreenShot(gtScreen_Cs.GetScreenshot());
    }

    public IScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
    {
        return new ScreenShot(gtScreen_Cs.GetScreenshotRect(position.Native(), size.Native()));
    }

    public Color GetPixelColorAt(Vector2i postion)
    {
        return new Color(gtScreen_Cs.GetPixelColorAt(postion.Native()));
    }

    public IGTScreen PixelAtShouldBeColor(Vector2i position, Color colorColor)
    {
        gtScreen_Cs.PixelAtShouldBeColor(position.Native(), colorColor.Native());
        return this;
    }
}