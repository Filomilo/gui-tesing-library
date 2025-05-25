using System;
using gui_tesing_library_CS.Directives;
using gui_tesing_library_CS.SystemCalls;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;

namespace gui_tesing_library_CS.Components;

public class GTWindowCS : IGTWindow
{
    private readonly int _handle;
    private readonly ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

    public GTWindowCS(int handle)
    {
        if (handle == 0)
            throw new ArgumentException("Window cannot have handle 0");
        _handle = handle;
    }

    public Vector2i MaximizedWindowSize { get; }

    public Vector2i Position => _SystemCalls.GetWindowPositon(_handle);

    public bool DoesExist => _SystemCalls.DoesWindowExist(_handle);

    public string Name => throw new NotImplementedException();
    public bool IsMinimized => _SystemCalls.IsWindowsMinimized(_handle);

    public Vector2i Size => _SystemCalls.GetWindowSize(_handle);

    [Delay]
    [Log]
    IGTWindow IGTWindow.Close()
    {
        _SystemCalls.CloseWindow(_handle);
        return this;
    }

    [Log]
    [Delay]
    public IGTWindow SetWindowSize(int x, int y)
    {
        _SystemCalls.SetWindowSize(_handle, new Vector2i(x, y));
        return this;
    }

    [Log]
    [Delay]
    public IGTWindow SetPostion(int x, int y)
    {
        _SystemCalls.SetWindowPostion(_handle, new Vector2i(x, y));
        return this;
    }

    [Log]
    [Delay]
    public IGTWindow BringUpFront()
    {
        _SystemCalls.BringWindowUpFront(_handle);
        return this;
    }

    [Log]
    public Color GetPixelColorAt(Vector2i postion)
    {
        return SystemCallsFactory.GetSystemCalls().GetPixelColorAt(postion, _handle);
    }

    [Log]
    public IGTScreen PixelAtShouldBeColor(Vector2i position, Color color)
    {
        Helpers.AwaitTrue(
            () => { return GetPixelColorAt(position).Equals(color); },
            $"Pixel color at {position} of window {GetWindowName()} was not {color} with in given time"
        );
        return this;
    }

    [Log]
    [Delay]
    IGTWindow IGTWindow.Maximize()
    {
        _SystemCalls.MaximizeWindow(_handle);
        return this;
    }

    [Log]
    public IGTProcess GetProcessOfWindow()
    {
        throw new NotImplementedException();
        //int processHandle = this._SystemCalls.GetProcessHandleFromId(
        //    this._SystemCalls.GetWindowThreadProcessId(this._handle)
        //);
        //return new GTProcess_CS(processHandle);
    }

    [Log]
    public IScreenShot GetScreenshot()
    {
        return SystemCallsFactory
            .GetSystemCalls()
            .GetScreenShotFromHandle(
                _handle,
                new Vector2i(0, 0),
                GetWindowContentSize()
            );
    }

    [Log]
    [Delay]
    public IScreenShot GetScreenshotRect(Vector2i position, Vector2i size)
    {
        throw new NotImplementedException();
    }

    [Log]
    [Delay]
    IGTWindow IGTWindow.Minimize()
    {
        _SystemCalls.MinimizeWindow(_handle);
        return this;
    }

    [Log]
    [Delay]
    IGTWindow IGTWindow.MoveWindow(Vector2i offset)
    {
        throw new NotImplementedException();
    }

    [Log]
    IGTWindow IGTWindow.SizeShouldBe(Vector2i vector2I)
    {
        Helpers.AwaitTrue(() => { return Size.Equals(vector2I); });
        return this;
    }

    [Log]
    IGTWindow IGTWindow.ShouldWindowExist(bool v)
    {
        Helpers.AwaitTrue(
            () => DoesExist == v,
            $"Window {GetWindowName()} is not {v} within max time"
        );
        return this;
    }

    [Log]
    IGTWindow IGTWindow.KillProcess()
    {
        GetProcessOfWindow().kill();
        return this;
    }

    [Log]
    public IGTWindow ShouldBeMinimized(bool state)
    {
        Helpers.AwaitTrue(() => { return IsMinimized == state; });
        return this;
    }

    [Log]
    public string GetWindowName()
    {
        return SystemCallsFactory.GetSystemCalls().GetWindowName(_handle);
    }

    public Vector2i GetWindowContentPosition()
    {
        var positon = Position;
        return new Vector2i(
            positon.x + SystemController.Instance.GetWindowBorderWidth(),
            positon.y
            + SystemController.Instance.GetWindowBorderHeight()
            + SystemController.Instance.GetWindowTitleBarHeight()
        );
    }

    public Vector2i GetWindowContentSize()
    {
        var size = Size;
        var borderWidth = SystemController.Instance.GetWindowBorderWidth();
        var windwopadding = SystemController.Instance.GetWindowPadding();
        var WindowBorderHeight = SystemController.Instance.GetWindowBorderHeight();
        var windowtielebarheight = SystemController.Instance.GetWindowTitleBarHeight();
        return new Vector2i(
            size.x - borderWidth * 2 - windwopadding * 2 - 1,
            size.y - WindowBorderHeight * 2 - windowtielebarheight - windwopadding * 2 - 5
        );
    }

    [Log]
    [Delay]
    public Color GetContentPixelColorAt(Vector2i postion)
    {
        //Vector2i WindowPOsiton = this.Position;
        //Vector2i ContnetPostion = this.GetWindowContentPosition();
        //Vector2i offset = ContnetPostion - WindowPOsiton;
        //Vector2i newPos = postion + offset;
        return GetPixelColorAt(postion);
    }

    public Color GetContentPixelColorAt(Vector2f realtivePostion)
    {
        var contentSize = GetWindowContentSize();
        return GetContentPixelColorAt(
            new Vector2i(
                (int)(contentSize.x * realtivePostion.x),
                (int)(contentSize.y * realtivePostion.y)
            )
        );
    }

    public IGTWindow ContentPixelAtShouldBeColor(Vector2i position, Color color)
    {
        Helpers.AwaitTrue(
            () => { return GetContentPixelColorAt(position).Equals(color); },
            $"Content Pixel color at {position} of window {GetWindowName()} was not {color} but {GetContentPixelColorAt(position)} with in given time"
        );
        return this;
    }

    public IGTWindow CenterWindow()
    {
        var screenSize = SystemController.Instance.GetScreenSize();
        var windowSize = Size;
        var diffrence = screenSize - windowSize;
        SetPostion(diffrence.x / 2, diffrence.y / 2);

        return this;
    }

    public IGTWindow WindowNameShouldBe(string title)
    {
        Helpers.AwaitTrue(
            () => { return GetWindowName() == title; },
            $"Window name was not [[{title}]] but [[{GetWindowName()}]] within {Configuration.ProcesAwaitTime} ms"
        );
        return this;
    }

    public IGTWindow ContentPixelAtShouldBeColor(
        Vector2f sliderColorCheckPostion,
        Color colorshouldbe,
        int errorPass
    )
    {
        Helpers.AwaitTrue(
            () =>
            {
                return GetContentPixelColorAt(sliderColorCheckPostion)
                    .getDiffrence(colorshouldbe) < errorPass;
            },
            $"Content Pixel color at {sliderColorCheckPostion} of window {GetWindowName()} was not {colorshouldbe} but {GetContentPixelColorAt(sliderColorCheckPostion)} with in given time, difreance: [[{GetContentPixelColorAt(sliderColorCheckPostion).getDiffrence(colorshouldbe)}]], with error pass [[{errorPass}]]"
        );
        return this;
    }

    [Log]
    [Delay]
    public IGTProcess Close()
    {
        throw new NotImplementedException();
    }

    [Log]
    [Delay]
    public IGTProcess Maximize()
    {
        throw new NotImplementedException();
    }

    [Log]
    [Delay]
    public IGTProcess Minimize()
    {
        throw new NotImplementedException();
    }

    [Log]
    [Delay]
    public IGTProcess MoveWindow(Vector2i offset)
    {
        throw new NotImplementedException();
    }
}