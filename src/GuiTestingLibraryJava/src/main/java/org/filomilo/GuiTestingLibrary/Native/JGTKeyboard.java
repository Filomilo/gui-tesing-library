package org.filomilo.GuiTestingLibrary.Native;


public class JGTKeyboard {
    static {
        NativeDllLoader.LoadDll();
    }
    public native void pressKey(JGTKey kry);

    public native void releaseKey(JGTKey kry);

    public native void clickKey(JGTKey kry);

    public native void type(String text);

}
