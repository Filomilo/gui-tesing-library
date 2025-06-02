using gui_tesing_library.Models;
using Lombok.NET;

namespace gui_tesing_library.Controllers;

[Singleton]
public partial class KeyboardController : IGTKeyboard
{
    private static readonly GTKeyboard_CS keyboardCS = new();

    public IGTKeyboard ClickKey(Key key)
    {
        keyboardCS.ClickKey(Helpers.keyToKeyCs(key));
        return this;
    }

    public IGTKeyboard PressKey(Key key)
    {
        keyboardCS.PressKey(Helpers.keyToKeyCs(key));
        return this;
    }

    public IGTKeyboard ReleaseKey(Key key)
    {
        keyboardCS.ReleaseKey(Helpers.keyToKeyCs(key));
        return this;
    }

    public IGTKeyboard Type(string text)
    {
        keyboardCS.Type(text);
        return this;
    }
}