package org.filomilo.GuiTestingLibrary.Native;

public class JGTSystemVersion implements AutoCloseable {
    static {
        NativeDllLoader.LoadDll();
    }
    JGTSystemVersion(long ptr){
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
    public native String GetVersionString();

}
