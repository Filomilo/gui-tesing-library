using System;
using System.Collections.Generic;
using gui_tesing_library;
using gui_tesing_library_CS.Components;
using gui_tesing_library_CS.Directives;
using gui_tesing_library_CS.SystemCalls;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;

namespace gui_tesing_library_CS;

public class SystemControllerCS : IGTSystem
{
    private static IGTSystem _gtSystem;
    private readonly ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

    public static IGTSystem Instance
    {
        get
        {
            if (_gtSystem == null)
                _gtSystem = new SystemControllerCS();

            return _gtSystem;
        }
    }

    public GTSystemVersion OsVersion => new GTSystemVersion(Environment.OSVersion);

    public Vector2i MaximizedWindowSize { get; }

    public IEnumerable<IGTWindow> FindWindowByName(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IGTProcess> FindProcessByName(string name)
    {
        throw new NotImplementedException();
    }

    [Log]
    public IGTWindow FindTopWindowByName(string name)
    {
        var handle = _SystemCalls.FindWindowByName(name);
        if (handle <= 0)
            return null;
        IGTWindow window = new GTWindowCS(handle);
        return window;
    }

    public IGTSystem WindowOfNameShouldExist(string name)
    {
        Helpers.AwaitTrue(
            () =>
            {
                return _SystemCalls.FindWindowByName(name) != 0;
            },
            $"No window of name [{name}]"
        );
        return this;
    }

    public IEnumerable<IGTProcess> GetActiveProcesses()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IGTWindow> GetActiveWindows()
    {
        throw new NotImplementedException();
    }

    public string GetClipBoardContent()
    {
        return _SystemCalls.GetClipBoardData();
    }

    [Log]
    public IGTProcess StartProcess(string commandString)
    {
        throw new NotImplementedException();
        //Thread.Sleep(gui_tesing_library.Configuration.ActionDelay);
        //IGTProcess gtProcess = new GTProcess_CS(_SystemCalls.CreateProcess(commandString));
        //return gtProcess;
    }

    public GTSystemVersion GetOsVersion()
    {
        throw new NotImplementedException();
    }

    public Vector2i GetMaximizedWindowSize()
    {
        throw new NotImplementedException();
    }

    GTSystemVersion IGTSystem.GetSystemVersion()
    {
        throw new NotImplementedException();
    }

    public int GetWindowTitleBarHeight()
    {
        return _SystemCalls.GetWindowTitleBarHeight();
    }

    public int GetWindowBorderWidth()
    {
        return _SystemCalls.GetWindowBorderWidth();
    }

    public int GetWindowBorderHeight()
    {
        return _SystemCalls.GetWindowBorderHeight();
    }

    public int GetWindowPadding()
    {
        return _SystemCalls.GetWindowPadding();
    }

    public Vector2i GetScreenSize()
    {
        return _SystemCalls.GetScreenSize();
    }
}
