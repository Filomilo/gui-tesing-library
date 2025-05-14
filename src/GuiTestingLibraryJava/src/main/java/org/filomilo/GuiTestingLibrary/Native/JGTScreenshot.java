package org.filomilo.GuiTestingLibrary.Native;

public class JGTScreenshot implements AutoCloseable {

    JGTScreenshot(long ptr){
        nativePtr=ptr;
    }
    private long nativePtr;

    public long getNativePtr() {
        return nativePtr;
    }

    public native void dispose();

    @Override
    public void close() throws Exception {
        dispose();
    }
    public native int GetWidth();

    public native int GetHeight();

    public native JGTColor GetPixelColorAt(int x, int y);

    public native void SaveAsBitmap(String filePath);

    public native double CompareToImage(String filePathToComparingImage);

    public native void SimmilarityBetweenImagesShouldBe(String imagePath, double similarity);
}
