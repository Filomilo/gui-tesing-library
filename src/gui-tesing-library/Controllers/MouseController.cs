using gui_tesing_library.Components;
using gui_tesing_library.Models;
using Lombok.NET;

namespace gui_tesing_library.Controllers;

[Singleton]
public partial class MouseController : IGTMouse
{
    private static readonly GTMouse_CS gtMouse_Cs = new();

    public Vector2i Position => new(gtMouse_Cs.GetPosition());

    public IGTMouse MoveMouse(Vector2i offset)
    {
        gtMouse_Cs.MoveMouse(offset.Native());
        return this;
    }

    public IGTMouse SetPosition(Vector2i position)
    {
        gtMouse_Cs.SetPosition(position.Native());
        return this;
    }

    public IGTMouse ClickLeft()
    {
        gtMouse_Cs.ClickLeft();
        return this;
    }

    public IGTMouse ClickRight()
    {
        gtMouse_Cs.ClickRight();
        return this;
    }

    public IGTMouse ClickMiddle()
    {
        gtMouse_Cs.ClickMiddle();
        return this;
    }

    public IGTMouse PressLeft()
    {
        gtMouse_Cs.PressLeft();
        return this;
    }

    public IGTMouse PressMiddle()
    {
        gtMouse_Cs.PressMiddle();
        return this;
    }

    public IGTMouse PressRight()
    {
        gtMouse_Cs.PressRight();
        return this;
    }

    public IGTMouse ReleaseLeft()
    {
        gtMouse_Cs.ReleaseLeft();
        return this;
    }

    public IGTMouse ReleaseMiddle()
    {
        gtMouse_Cs.ReleaseMiddle();
        return this;
    }

    public IGTMouse ReleaseRight()
    {
        gtMouse_Cs.ReleaseRight();
        return this;
    }

    public IGTMouse Scroll(int scrollValue)
    {
        gtMouse_Cs.Scroll(scrollValue);
        return this;
    }

    public IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2i positon)
    {
        var gtWindow_Cs = window as GTWindow;
        gtMouse_Cs.SetPositionRelativeToWindow(gtWindow_Cs.native(), positon.Native());
        return this;
    }

    public IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2f positon)
    {
        var gtWindow_Cs = window as GTWindow;
        gtMouse_Cs.SetPositionRelativeToWindow(gtWindow_Cs.native(), positon.Native());
        return this;
    }

    public IGTMouse PositionShouldBe(Vector2i pos, int errorDistance = 0)
    {
        gtMouse_Cs.PositionShouldBe(pos.Native(), errorDistance);
        return this;
    }

    public IGTMouse MoveMouseTo(Vector2i newRedSliderPostion)
    {
        gtMouse_Cs.MoveMouseTo(newRedSliderPostion.Native());
        return this;
    }

    public IGTMouse MoveMouseRelativeToWindowTo(IGTWindow window, Vector2i position)
    {
        var gtWindow_Cs = window as GTWindow;
        gtMouse_Cs.MoveMouseRelativeToWindowTo(gtWindow_Cs.native(), position.Native());
        return this;
    }

    public IGTMouse MoveMouseRelativeToWindowTo(IGTWindow window, Vector2f vector2f)
    {
        var gtWindow_Cs = window as GTWindow;
        gtMouse_Cs.MoveMouseRelativeToWindowTo(gtWindow_Cs.native(), vector2f.Native());
        return this;
    }

    public Vector2f GetPostionRelativeToWinodw(IGTWindow window)
    {
        var gtWindow_Cs = window as GTWindow;
        return new Vector2f(gtMouse_Cs.GetPositionRelativeToWindow(gtWindow_Cs.native()));
    }

    public IGTMouse PositionRelativeToWindowShouldBe(
        IGTWindow window,
        Vector2f vector2f,
        float errorDistance = 0
    )
    {
        var gtWindow_Cs = window as GTWindow;
        gtMouse_Cs.PositionRelativeToWindowShouldBe(
            gtWindow_Cs.native(),
            vector2f.Native(),
            errorDistance
        );
        return this;
    }
}
