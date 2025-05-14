package org.filomilo.GuiTestingLibrary.Native;

public class JGTProcess implements AutoCloseable {

    JGTProcess(long ptr){
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
    public native String getName();

    public native boolean isAlive();

    public native JGTWindow[] getWindowsOfProcess();

    public native long getRamUsage();

    public native void kill();
}
