package org.filomilo.GuiTestingLibrary.Native;

public class JGTSystem {
    static {
        NativeDllLoader.LoadDll();
    }
    public native JGTWindow[] FindWindowByName(String name);
    public native JGTProcess[] FindProcessByName(String name);
    public native JGTWindow FindTopWindowByName(String name); // Could return null if not found
    public native void WindowOfNameShouldExist(String name);
    public native JGTProcess[] GetActiveProcesses();
    public native JGTWindow[] GetActiveWindows();
    public native String GetClipBoardContent();
    public native JGTProcess StartProcess(String commandString);
    public native JGTSystemVersion GetOsVersion();

    public native int GetWindowTitleBarHeight();
    public native int GetWindowBorderWidth();
    public native int GetWindowBorderHeight();
    public native int GetWindowPadding();
    public native JGTVector2i GetScreenSize();
    public native JGTVector2i GetMaximizedWindowSize();

}
