using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Models;

namespace gui_tesing_library.Controllers
{
    class KeyboardController: IGTKeyboard
    {
        public IGTKeyboard PressKey(Key key)
        {
            throw new NotImplementedException();
        }

        public IGTKeyboard ReleaseKey(Key key)
        {
            throw new NotImplementedException();
        }

        public IGTKeyboard ClickKey(Key key)
        {
            throw new NotImplementedException();
        }

        public IGTKeyboard Type(string text)
        {
            throw new NotImplementedException();
        }
    }
}
