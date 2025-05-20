package org.filomilo.GuiTestingLibrary.Native;


public class JGTMouse {
    static {
        NativeDllLoader.LoadDll();
    }

    private static  JGTMouse Instance = new JGTMouse();
    private JGTMouse() {

    }
    public static JGTMouse getInstance() {
        if(Instance == null)
        {
            Instance = new JGTMouse();
        }
        return Instance;
    }


    public native JGTVector2i GetPosition();

    public native void MoveMouse(JGTVector2i offset);

    public native void SetPosition(JGTVector2i position);

    public native void ClickLeft();

    public native void ClickRight();

    public native void ClickMiddle();

    public native void PressLeft();

    public native void PressMiddle();

    public native void PressRight();

    public native void ReleaseLeft();

    public native void ReleaseMiddle();

    public native void ReleaseRight();

    public native void Scroll(int scrollValue);

    public native void SetPositionRelativeToWindow(JGTWindow window, JGTVector2i position);

    public native void SetPositionRelativeToWindow(JGTWindow window, JGTVector2f position);

    public native void PositionShouldBe(JGTVector2i pos, int errorDistance);

    public native void MoveMouseTo(JGTVector2i newRedSliderPosition);

    public native void MoveMouseRelativeToWindowTo(JGTWindow window, JGTVector2i position);

    public native void MoveMouseRelativeToWindowTo(JGTWindow window, JGTVector2f vector2f);

    public native JGTVector2f GetPositionRelativeToWindow(JGTWindow window);

    public native void PositionRelativeToWindowShouldBe(JGTWindow window, JGTVector2f vector2f, float errorDistance);


}
