package org.filomilo.GuiTestingLibrary.Native;

public class JGTConfiguration {


    public native long GetTimeout();

    public native void SetTimeout(long newTimeout);

    public native void SetDefaultTimeout();

    public native void DefaultSleep();


}
