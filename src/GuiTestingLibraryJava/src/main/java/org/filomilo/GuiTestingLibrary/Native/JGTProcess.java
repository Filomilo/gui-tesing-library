package org.filomilo.GuiTestingLibrary.Native;

public class JGTProcess {
    public native String getName();

    public native boolean isAlive();

    public native JGTWindow[] getWindowsOfProcess();

    public native long getRamUsage();

    public native void kill();
}
