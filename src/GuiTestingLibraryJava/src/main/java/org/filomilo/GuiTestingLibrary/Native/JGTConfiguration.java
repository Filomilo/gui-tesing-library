package org.filomilo.GuiTestingLibrary.Native;

public class JGTConfiguration {

    public static enum IMageComparer{
        PIXELBYPIXEL
    }

    static {
        NativeDllLoader.LoadDll();
    }
    private static JGTConfiguration instance = new JGTConfiguration();
    private JGTConfiguration() {}
    public static JGTConfiguration getInstance() {
        if (instance == null) {
            instance = new JGTConfiguration();
        }
        return instance;

    }
    public native long GetTimeout();

    public native void SetTimeout(long newTimeout);

    public native void SetDefaultTimeout();

    public native void DefaultSleep();
    public native long GetActionDelay();
    public native void SetActionDelay(long newDelay);
    public native void SetDefaultActionDelay();
    public native IMageComparer GetImageComparer();
    public native void SetImageComparer(IMageComparer newComparer);


}
