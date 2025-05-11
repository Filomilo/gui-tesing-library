package org.filomilo.GuiTestingLibrary.Native;


public class JGTKeyboard {
    public native void create();

    public native void destroy();

    public native void pressKey(JGTKey kry);

    public native void releaseKey(JGTKey kry);

    public native void clickKey(JGTKey kry);

    public native void type(String text);

}
