using System.Collections.Generic;
using gui_tesing_library.Models;

namespace gui_tesing_library;

public interface IGTSystem
{
    GTSystemVersion GetOsVersion();

    Vector2i GetMaximizedWindowSize();

    GTSystemVersion GetSystemVersion();
    IGTProcess StartProcess(string commandString);
    string GetClipBoardContent();

    IEnumerable<IGTWindow> GetActiveWindows();
    IEnumerable<IGTWindow> FindWindowByName(string name);
    IEnumerable<IGTProcess> FindProcessByName(string name);
    IEnumerable<IGTProcess> GetActiveProcesses();
    IGTWindow FindTopWindowByName(string name);

    IGTSystem WindowOfNameShouldExist(string name);

    int GetWindowTitleBarHeight();
    int GetWindowBorderWidth();
    int GetWindowBorderHeight();
    int GetWindowPadding();
    Vector2i GetScreenSize();
}
