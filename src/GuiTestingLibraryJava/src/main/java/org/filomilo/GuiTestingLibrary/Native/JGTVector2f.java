package org.filomilo.GuiTestingLibrary.Native;

public class JGTVector2f implements AutoCloseable {
    static {
        NativeDllLoader.LoadDll();
    }
    JGTVector2f(long ptr){
        nativePtr=ptr;
    }
    private long nativePtr;
    private native void  setup(float x, float y);
    public JGTVector2f(float x, float y) {
        setup(x, y);

    }
    public long getNativePtr() {
        return nativePtr;
    }

    public native void dispose();

    @Override
    public void close() throws Exception {
        dispose();
    }
    public native float length();
    public native float getX();
    public native float getY();

    public native JGTVector2f subtract(JGTVector2f other);
    public JGTVector2f plus(JGTVector2f other) {
        return new JGTVector2f(getX() + other.getX(), getY() + other.getY());
    }

    public JGTVector2f add(JGTVector2f jgtVector2f) {
        return  new JGTVector2f(this.getX() + jgtVector2f.getX(), getY() + jgtVector2f.getY());
    }
}
