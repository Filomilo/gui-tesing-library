using System.Collections.Generic;
using System.Linq;
using gui_tesing_library.Components;
using gui_tesing_library.Models;

namespace gui_tesing_library.Controllers;

public class SystemController : IGTSystem
{
    public static SystemController _Instance;
    private static GTSystemControler_CS SystemControler_CS;

    private SystemController()
    {
        SystemControler_CS = GTSystemControler_CS.Instance();
    }

    public static SystemController Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new SystemController();

            return _Instance;
        }
    }

    public GTSystemVersion OsVersion => new(SystemControler_CS.GetOsVersion());

    public Vector2i MaximizedWindowSize => new(SystemControler_CS.GetMaximizedWindowSize());

    public GTSystemVersion GetSystemVersion()
    {
        return new GTSystemVersion(SystemControler_CS.GetOsVersion());
    }

    public IGTProcess StartProcess(string commandString)
    {
        return new GTProcess(GTSystemControler_CS.Instance().StartProcess(commandString));
    }

    public string GetClipBoardContent()
    {
        return SystemControler_CS.GetClipBoardContent();
    }

    public IEnumerable<IGTWindow> GetActiveWindows()
    {
        return SystemControler_CS.GetActiveWindows().Select(w => new GTWindow(w));
    }

    public IEnumerable<IGTWindow> FindWindowByName(string name)
    {
        return SystemControler_CS.FindWindowByName(name).Select(w => new GTWindow(w));
    }

    public IEnumerable<IGTProcess> FindProcessByName(string name)
    {
        return SystemControler_CS.FindProcessByName(name).Select(p => new GTProcess(p));
    }

    public IEnumerable<IGTProcess> GetActiveProcesses()
    {
        return SystemControler_CS.GetActiveProcesses().Select(p => new GTProcess(p));
    }

    public IGTWindow FindTopWindowByName(string name)
    {
        var win = SystemControler_CS.FindTopWindowByName(name);
        return win == null ? null : new GTWindow(win);
    }

    public IGTSystem WindowOfNameShouldExist(string name)
    {
        SystemControler_CS.WindowOfNameShouldExist(name);
        return this;
    }

    public int GetWindowTitleBarHeight()
    {
        return SystemControler_CS.GetWindowTitleBarHeight();
    }

    public int GetWindowBorderWidth()
    {
        return SystemControler_CS.GetWindowBorderWidth();
    }

    public int GetWindowBorderHeight()
    {
        return SystemControler_CS.GetWindowBorderHeight();
    }

    public int GetWindowPadding()
    {
        return SystemControler_CS.GetWindowPadding();
    }

    public Vector2i GetScreenSize()
    {
        return new Vector2i(SystemControler_CS.GetScreenSize());
    }

    public GTSystemVersion GetOsVersion()
    {
        return new GTSystemVersion(SystemControler_CS.GetOsVersion());
    }

    public Vector2i GetMaximizedWindowSize()
    {
        return new Vector2i(SystemControler_CS.GetMaximizedWindowSize());
    }
}
