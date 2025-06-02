package org.filomilo.GuiTestingLibrary.Native;

public class JGTColor {

    static {
        NativeDllLoader.LoadDll();
    }

    public int r, g, b;

    public JGTColor() {
        r = 0;
        g = 0;
        b = 0;
    }

    public JGTColor(int r, int g, int b) {
        this.r = r;
        this.g = g;
        this.b = b;
    }
    public JGTColor(float r, float g, float b)
    {
        this.r = (int)(r * 255);
        this.g = (int)(g * 255);
        this.b = (int)(b * 255);
    }
    public static final JGTColor Red = new JGTColor(1f, 0f, 0f);
    public static final JGTColor Black = new JGTColor(0f, 0f, 0f);
    public static final JGTColor Pink = new JGTColor(55, 192, 103);
    public static final JGTColor Yellow = new JGTColor(1f, 1f, 0f);
    public static final JGTColor Aqua = new JGTColor(207, 157, 150);
    public static final JGTColor Orange = new JGTColor(131, 117, 127);
    public static final JGTColor Green = new JGTColor(0, 128, 0);
    public static final JGTColor Blue = new JGTColor(0f, 0f, 1f);
    public static final JGTColor White = new JGTColor(1f, 1f, 1f);
    public static final JGTColor Lime = new JGTColor(0f, 1f, 0f);


    public boolean equals(JGTColor black) {
        return  this.r == black.r && this.g == black.g && this.b == black.b;
    }

    public int getDiffrence(JGTColor colorshouldbe) {
        int rdiff = this.r - colorshouldbe.r;
        int gdiff = this.g - colorshouldbe.g;
        int bdiff = this.b - colorshouldbe.b;
        return (int) Math.sqrt (
                Math.pow(Math.sqrt(Math.pow(rdiff, 2) + Math.pow(bdiff, 2)), 2) + Math.pow(gdiff, 2)
        );
    }


    @Override
    public String toString() {
        return "JGTColor{" +
                "r=" + r +
                ", g=" + g +
                ", b=" + b +
                '}';
    }
}
