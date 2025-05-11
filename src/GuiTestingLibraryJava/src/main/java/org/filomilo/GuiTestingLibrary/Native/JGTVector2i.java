package org.filomilo.GuiTestingLibrary.Native;

public class JGTVector2i {
    public native float getLength();

    public native boolean equals(JGTVector2i other);

    public native String toString();

    public native int getArea();

    public native JGTVector2i add(JGTVector2i other);

    public native JGTVector2i subtract(JGTVector2i other);

    public native JGTVector2i divide(int scalar);

    public native JGTVector2i divide(JGTVector2i other);

}
