﻿using gui_tesing_library.Directives;
using gui_tesing_library.Models;
using gui_tesing_library.SystemCalls;
using Lombok.NET;

namespace gui_tesing_library.Controllers
{
    [Singleton]
    public partial class KeyboardControllerCS : IGTKeyboard
    {
        static IGTKeyboard _MouseController = null;

        //public static IGTKeyboard Instance
        //{
        //    get
        //    {
        //        if (_MouseController == null)
        //        {
        //            _MouseController = new KeyboardController();
        //        }

        //        return _MouseController;
        //    }
        //}

        [Log]
        [Delay]
        public IGTKeyboard PressKey(Key key)
        {
            SystemCallsFactory.GetSystemCalls().PressKey(key);
            return this;
        }

        [Log]
        [Delay]
        public IGTKeyboard ReleaseKey(Key key)
        {
            SystemCallsFactory.GetSystemCalls().ReleaseKey(key);
            return this;
        }

        [Log]
        [Delay]
        public IGTKeyboard ClickKey(Key key)
        {
            SystemCallsFactory.GetSystemCalls().ClickKey(key);
            return this;
        }

        [Log]
        [Delay]
        public IGTKeyboard Type(string text)
        {
            SystemCallsFactory.GetSystemCalls().TypeText(text);
            return this;
        }
    }
}
