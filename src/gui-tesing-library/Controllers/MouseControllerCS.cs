using System;
using gui_tesing_library_CS.Directives;
using gui_tesing_library_CS.SystemCalls;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;

namespace gui_tesing_library_CS.Controllers;

public class MouseControllerCS : IGTMouse
{
    private static IGTMouse _MouseController;

    public static IGTMouse Instance
    {
        get
        {
            if (_MouseController == null) _MouseController = new MouseController();

            return _MouseController;
        }
    }

    public Vector2i Position => SystemCallsFactory.GetSystemCalls().GetMousePosition();

    [Log]
    [Delay]
    public IGTMouse ClickLeft()
    {
        SystemCallsFactory.GetSystemCalls().ClickLeft();
        return this;
    }

    public IGTMouse ClickMiddle()
    {
        SystemCallsFactory.GetSystemCalls().ClickMiddle();
        return this;
    }

    public IGTMouse ClickRight()
    {
        SystemCallsFactory.GetSystemCalls().ClickRight();
        return this;
    }

    public IGTMouse MoveMouse(Vector2i offset)
    {
        var currPostion = Position;
        var FinalPos = currPostion + offset;

        var diff = FinalPos - Position;
        //diff /= 2;
        //int i = 0;
        var currPosF = (Vector2f)currPostion;
        var finalPosF = (Vector2f)FinalPos;
        var length = (int)(FinalPos - currPostion).Length;
        var step = (finalPosF - currPosF) / length;
        for (var j = 0; j < length; j++)
        {
            currPosF += step;
            var newPos = (Vector2i)currPosF;
            var off = newPos - Position;
            SystemCallsFactory.GetSystemCalls().MoveMouse(off);
        }

        //while (!this.Position.Equals(FinalPos))
        //{
        //    i++;
        //    SystemCallsFactory.GetSystemCalls().MoveMouse(diff);
        //    diff = FinalPos - this.Position;
        //    //diff /= 2;
        //    Console.WriteLine($"Mouse position: {this.Position} after offset {diff}");
        //    if (i > moveLimit)
        //        break;
        //}

        return this;
    }

    [Log]
    [Delay]
    public IGTMouse PressLeft()
    {
        SystemCallsFactory.GetSystemCalls().PressLeft();
        return this;
    }

    public IGTMouse PressMiddle()
    {
        SystemCallsFactory.GetSystemCalls().PressMiddle();
        return this;
    }

    public IGTMouse PressRight()
    {
        SystemCallsFactory.GetSystemCalls().PressRight();
        return this;
    }

    public IGTMouse ReleaseLeft()
    {
        SystemCallsFactory.GetSystemCalls().ReleaseLeft();
        return this;
    }

    public IGTMouse ReleaseMiddle()
    {
        SystemCallsFactory.GetSystemCalls().ReleaseMiddle();
        return this;
    }

    public IGTMouse ReleaseRight()
    {
        SystemCallsFactory.GetSystemCalls().ReleaseRight();
        return this;
    }

    public IGTMouse Scroll(int scrollValue)
    {
        SystemCallsFactory.GetSystemCalls().Scroll(scrollValue);
        return this;
    }

    [Delay]
    [Log]
    public IGTMouse SetPosition(Vector2i position)
    {
        SystemCallsFactory.GetSystemCalls().SetMousePostion(position);
        return this;
    }

    [Delay]
    [Log]
    public IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2i positon)
    {
        var windowPositon = window.GetWindowContentPosition();
        SetPosition(positon + windowPositon);
        return this;
    }

    public IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2f positon)
    {
        var size = window.GetWindowContentSize();
        SetPositionRelativeToWindow(
            window,
            new Vector2i((int)(positon.x * size.x), (int)(positon.y * size.y))
        );
        return this;
    }

    [Delay]
    [Log]
    public IGTMouse PositionShouldBe(Vector2i pos, int errorDistance)
    {
        Helpers.AwaitTrue(
            () =>
            {
                var diff = Position - pos;
                diff.x = Math.Abs(diff.x);
                diff.y = Math.Abs(diff.y);
                if (diff.x > errorDistance || diff.y > errorDistance) return false;
                return true;
            },
            $"Mouse postion was not {pos} withing maximum time but {Position}"
        );
        return this;
    }

    [Delay]
    [Log]
    public IGTMouse MoveMouseTo(Vector2i newPos)
    {
        SystemCallsFactory.GetSystemCalls().MoveMouseTo(newPos);
        return this;
    }

    public IGTMouse MoveMouseRelativeToWindowTo(IGTWindow window, Vector2i positon)
    {
        var windowPositon = window.GetWindowContentPosition();
        MoveMouseTo(positon + windowPositon);
        return this;
    }

    IGTMouse IGTMouse.MoveMouseRelativeToWindowTo(IGTWindow window, Vector2f vector2f)
    {
        var size = window.GetWindowContentSize();
        MoveMouseRelativeToWindowTo(
            window,
            new Vector2i((int)(size.x * vector2f.x), (int)(size.y * vector2f.y))
        );
        return this;
    }

    public Vector2f GetPostionRelativeToWinodw(IGTWindow window)
    {
        var mousePositon = Position;
        var contentPositon = window.GetWindowContentPosition();
        var contentSize = window.GetWindowContentSize();

        var mousePosiotnAdjustedForContentPostion = mousePositon - contentPositon;
        var postionRelativeToContentSize =
            (Vector2f)mousePosiotnAdjustedForContentPostion / (Vector2f)contentSize;

        return postionRelativeToContentSize;
    }

    public IGTMouse PositionRelativeToWindowShouldBe(
        IGTWindow window,
        Vector2f realitvePos,
        float errorDistance
    )
    {
        Helpers.AwaitTrue(
            () =>
            {
                return GetPostionRelativeToWinodw(window).DistanceFrom(realitvePos)
                       < errorDistance;
            },
            $"Mouse postion realtive to window was not {realitvePos} withing maximum time but {GetPostionRelativeToWinodw(window)} which is distance of [[{GetPostionRelativeToWinodw(window).DistanceFrom(realitvePos)}]]] and allowed is [[{errorDistance}]]"
        );
        return this;
    }

    public IGTMouse MoveMouseRelativeToWindowTo(IGTWindow window, Vector2f realitvePos)
    {
        var size = window.GetWindowContentSize();
        var windowPostion = window.Position;
        var newPos = new Vector2i(
            (int)(size.x * realitvePos.x),
            (int)(size.y * realitvePos.y)
        );
        var absolutePostion = windowPostion + newPos;
        MoveMouseTo(absolutePostion);
        return this;
    }
}