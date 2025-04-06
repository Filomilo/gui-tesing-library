using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;

namespace gui_tesing_library
{
    public interface IGTScreen
    {
        Vector2i Size { get; }

        Vector2i MaximizedWindowSize { get; }

        ScreenShot GetScreenshot();
        ScreenShot GetScreenshotRect(Vector2i position, Vector2i size);
        Color GetPixelColorAt(Vector2i postion);

        IGTScreen PixelAtShouldBeColor(Vector2i position, Color colorColor);
    }
}
