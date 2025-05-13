package org.filomilo.GuiTestingLibrary.Native;

public class JGTVector2f implements AutoCloseable {

    JGTVector2f(long ptr){
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
    public native float length();

    public native JGTVector2f subtract(JGTVector2f other);

}
