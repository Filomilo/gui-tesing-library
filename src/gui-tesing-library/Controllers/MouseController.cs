using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Directives;
using gui_tesing_library.SystemCalls;
using Lombok.NET;
using Microsoft.Win32.SafeHandles;

namespace gui_tesing_library.Controllers
{
    [Singleton]
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
            this.SetPosition(this.Position + offset);
            return this;
        }

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
            Vector2i windowPositon = window.Position;
            this.SetPosition(positon + windowPositon);
            return this;
        }

        [Delay]
        [Log]
        public IGTMouse PositionShouldBe(Vector2i pos)
        {
            Helpers.AwaitTrue(
                () =>
                {
                    return this.Position.Equals(pos);
                },
                $"Mouse postion was not {pos} withing maximum time but {this.Position}"
            );
            return this;
        }
    }
}
