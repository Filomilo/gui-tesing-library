package org.filomilo.GuiTestingLibrary.Native;

public class NativeGtSystem {
    private static NativeGtSystem instance;

    static {
        System.load("F:/projects/gui-tesing-library/src/GuiTestingLibraryJava/src/main/resources/gui-testing-library-java.dll");
    }

    private NativeGtSystem() {
    }

    public static synchronized NativeGtSystem getInstance() {
        if (instance == null) {
            instance = new NativeGtSystem();
        }
        return instance;
    }

    public native String GetClipBoard();
}
