using System;
using gui_tesing_library;
using gui_tesing_library_CS.Directives;
using gui_tesing_library_CS.SystemCalls;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;

namespace gui_tesing_library_CS.Controllers;

public class ScreenControllerCS : IGTScreen
{
    private static IGTScreen _gtScreen;
    private readonly ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

    public Vector2i MaximizedWindowSize => _SystemCalls.GetMaximizedWindowSize();

    public static IGTScreen Instance
    {
        get
        {
            if (_gtScreen == null)
                _gtScreen = new ScreenController();

            return _gtScreen;
        }
    }

    public Vector2i Size { get; }

    public IScreenShot GetScreenshot()
    {
        return SystemCallsFactory
            .GetSystemCalls()
            .GetScreenShotFromHandle(
                0,
                new Vector2i(0, 0),
                SystemController.Instance.GetScreenSize()
            );
    }

    public IScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
    {
        throw new NotImplementedException();
    }

    [Log]
    public Color GetPixelColorAt(Vector2i postion)
    {
        //return SystemCallsFactory.GetSystemCalls().GetPixelColorAt(postion, 0);
        return new Color(0, 0, 0);
    }

    [Log]
    public IGTScreen PixelAtShouldBeColor(Vector2i postion, Color color)
    {
        Helpers.AwaitTrue(
            () =>
            {
                return GetPixelColorAt(postion).Equals(color);
            },
            $"Pixel color at {postion} was not {color} with in given time"
        );
        return this;
    }
}
