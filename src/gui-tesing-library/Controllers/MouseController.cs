using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Directives;
using gui_tesing_library.SystemCalls;
using Lombok.NET;

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
            get
            {
                return SystemCallsFactory.GetSystemCalls().GetMousePosition();
            }
        }

        public IGTMouse ClickLeft()
        {
            SystemCallsFactory.GetSystemCalls().ClickLeft();
            return this;
        }

        public IGTMouse ClickMiddle()
        {
            throw new NotImplementedException();
        }

        public IGTMouse ClickRight()
        {
            throw new NotImplementedException();
        }

        public IGTMouse MoveMouse(Vector2i offset)
        {
            throw new NotImplementedException();
        }

        public IGTMouse MoveRelativeToWindow(IGTWindow window, Vector2i offset)
        {
            throw new NotImplementedException();
        }

        public IGTMouse PressLeft()
        {
            throw new NotImplementedException();
        }

        public IGTMouse PressMiddle()
        {
            throw new NotImplementedException();
        }

        public IGTMouse PressRight()
        {
            throw new NotImplementedException();
        }

        public IGTMouse ReleaseLeft()
        {
            throw new NotImplementedException();
        }

        public IGTMouse ReleaseMiddle()
        {
            throw new NotImplementedException();
        }

        public IGTMouse ReleaseRight()
        {
            throw new NotImplementedException();
        }

        public IGTMouse ScrollDown(int scrollValue)
        {
            throw new NotImplementedException();
        }

        public IGTMouse ScrollUp(int scrollValue)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        [Delay]
        [Log]
        public IGTMouse PositionShouldBe(Vector2i pos)
        {
            Helpers.AwaitTrue(() =>
            {
                return this.Position.Equals(pos);
            },$"Mouse postion was not {pos} withing maximum time but {this.Position}");
            return this;
        }
    }
}
