using gui_tesing_library.Directives;
using gui_tesing_library.SystemCalls;
using System;

namespace gui_tesing_library.Controllers
{
    public partial class MouseController : IGTMouse
    {
        static IGTMouse _MouseController = null;

        public static IGTMouse Instance
        {
            get
            {
                if (_MouseController == null)
                {
                    _MouseController = new MouseController();
                }

                return _MouseController;
            }
        }

        public Vector2i Position
        {
            get { return SystemCallsFactory.GetSystemCalls().GetMousePosition(); }
        }

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
            Vector2i currPostion = this.Position;
            Vector2i FinalPos = currPostion + offset;

            Vector2i diff = FinalPos - this.Position;
            //diff /= 2;
            //int i = 0;
            Vector2f currPosF = (Vector2f)currPostion;
            Vector2f finalPosF = (Vector2f)FinalPos;
            int length = (int)(FinalPos - currPostion).Length;
            Vector2f step = (finalPosF - currPosF) / length;
            for (int j = 0; j < length; j++)
            {
                currPosF += step;
                Vector2i newPos = (Vector2i)currPosF;
                Vector2i off = newPos - this.Position;
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
            Vector2i windowPositon = window.GetWindowContentPosition();
            this.SetPosition(positon + windowPositon);
            return this;
        }

        public IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2f positon)
        {
            Vector2i size = window.GetWindowContentSize();
            this.SetPositionRelativeToWindow(
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
                    Vector2i diff = this.Position - pos;
                    diff.x = Math.Abs(diff.x);
                    diff.y = Math.Abs(diff.y);
                    if (diff.x > errorDistance || diff.y > errorDistance)
                    {
                        return false;
                    }
                    return true;
                },
                $"Mouse postion was not {pos} withing maximum time but {this.Position}"
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
            Vector2i windowPositon = window.GetWindowContentPosition();
            this.MoveMouseTo(positon + windowPositon);
            return this;
        }

        IGTMouse IGTMouse.MoveMouseRelativeToWindowTo(IGTWindow window, Vector2f vector2f)
        {
            Vector2i size = window.GetWindowContentSize();
            MoveMouseRelativeToWindowTo(window, new Vector2i((int)(size.x * vector2f.x), (int)(size.y * vector2f.y)));
            return this;
        }

        public Vector2f GetPostionRelativeToWinodw(IGTWindow window)
        {

            Vector2i mousePositon = this.Position;
            Vector2i contentPositon = window.GetWindowContentPosition();
            Vector2i contentSize = window.GetWindowContentSize();

            Vector2i mousePosiotnAdjustedForContentPostion = mousePositon - contentPositon;
            Vector2f postionRelativeToContentSize =
                ((Vector2f)(mousePosiotnAdjustedForContentPostion)) / ((Vector2f)(contentSize));

            return postionRelativeToContentSize;
        }

        public IGTMouse PositionRelativeToWindowShouldBe(IGTWindow window, Vector2f realitvePos, float errorDistance)
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return GetPostionRelativeToWinodw(window).DistanceFrom(realitvePos) < errorDistance;

                },
                $"Mouse postion realtive to window was not {realitvePos} withing maximum time but {GetPostionRelativeToWinodw(window)} which is distance of [[{GetPostionRelativeToWinodw(window).DistanceFrom(realitvePos)}]]] and allowed is [[{errorDistance}]]"
            );
            return this;
        }

        public IGTMouse MoveMouseRelativeToWindowTo(IGTWindow window, Vector2f realitvePos)
        {
            Vector2i size = window.GetWindowContentSize();
            Vector2i windowPostion = window.Position;
            Vector2i newPos = new Vector2i((int)(size.x * realitvePos.x), (int)(size.y * realitvePos.y));
            Vector2i absolutePostion = windowPostion + newPos;
            this.MoveMouseTo(absolutePostion);
            return this;
        }
    }
}
