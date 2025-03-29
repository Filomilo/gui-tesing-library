using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library.Controllers
{
    class MouseController : IGTMouse
    {
        public Vector2i Position => throw new NotImplementedException();

        public IGTMouse ClickLeft()
        {
            throw new NotImplementedException();
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

        public IGTMouse SetPosition(Vector2i position)
        {
            throw new NotImplementedException();
        }

        public IGTMouse SetPositionRelativeToWindow(IGTWindow window, Vector2i positon)
        {
            throw new NotImplementedException();
        }
    }
}
