package org.filomilo.GuiTestingLibrary.Native;


public class JGTWindow {
    public native JGTVector2i GetPosition();

    public native JGTVector2i GetSize();

    public native boolean DoesExist();

    public native String GetName();

    public native boolean IsMinimized();

    public native void MoveWindow(JGTVector2i offset);

    public native void Minimize();

    public native void Maximize();

    public native JGTProcess GetProcessOfWindow();

    public native void Close();

    public native void SetWindowSize(int x, int y);

    public native void SetPosition(int x, int y);

    public native void BringUpFront();

    public native void SizeShouldBe(JGTVector2i vector2I);

    public native void ShouldWindowExist(boolean v);

    public native void KillProcess();

    public native void ShouldBeMinimized(boolean state);

    public native String GetWindowName();

    public native JGTVector2i GetWindowContentPosition();

    public native JGTVector2i GetWindowContentSize();

    public native JGTColor GetContentPixelColorAt(JGTVector2i position);

    public native JGTColor GetContentPixelColorAt(JGTVector2f relativePosition);

    public native void ContentPixelAtShouldBeColor(JGTVector2i position, JGTColor color);

    public native void CenterWindow();

    public native void WindowNameShouldBe(String title);

    public native void ContentPixelAtShouldBeColor(JGTVector2f sliderColorCheckPosition, JGTColor colorShouldBe, int errorPass);

    public native JGTScreenshot GetScreenshot();

    public native JGTScreenshot GetScreenshotRect(JGTVector2i position, JGTVector2i size);

    public native JGTColor GetPixelColorAt(JGTVector2i position);

    public native void PixelAtShouldBeColor(JGTVector2i position, JGTColor color);
}
