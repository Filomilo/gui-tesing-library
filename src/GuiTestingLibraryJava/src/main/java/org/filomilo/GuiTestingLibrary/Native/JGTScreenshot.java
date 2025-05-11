package org.filomilo.GuiTestingLibrary.Native;

public class JGTScreenshot {
    public native int GetWidth();

    public native int GetHeight();

    public native String GetPixelColorAt(int x, int y);

    public native void SaveAsBitmap(String filePath);

    public native double CompareToImage(String filePathToComparingImage);

    public native void SimmilarityBetweenImagesShouldBe(String imagePath, double similarity);
}
