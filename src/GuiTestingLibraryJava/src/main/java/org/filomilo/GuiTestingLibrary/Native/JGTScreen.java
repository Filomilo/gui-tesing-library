package org.filomilo.GuiTestingLibrary.Native;


public class JGTScreen {
    static {
        NativeDllLoader.LoadDll();
    }
    public native JGTVector2i GetSize();

    public native JGTVector2i GetMaximizedWindowSize();

    public native JGTScreenshot GetScreenshot();

    public native JGTScreenshot GetScreenshotRect(JGTVector2i position, JGTVector2i size);

    public native JGTColor GetPixelColorAt(JGTVector2i position);

    public native void PixelAtShouldBeColor(JGTVector2i position, JGTColor color);

}
