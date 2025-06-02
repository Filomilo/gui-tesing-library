using gui_tesing_library_CS.Directives;
using gui_tesing_library_CS.SystemCalls;
using gui_tesing_library;
using gui_tesing_library.Models;
using Lombok.NET;

namespace gui_tesing_library_CS.Controllers;

[Singleton]
public partial class KeyboardControllerCS : IGTKeyboard
{
    private static IGTKeyboard _MouseController = null;

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