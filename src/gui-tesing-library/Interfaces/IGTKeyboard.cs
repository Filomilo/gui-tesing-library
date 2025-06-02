using gui_tesing_library.Models;

namespace gui_tesing_library;

public interface IGTKeyboard
{
    IGTKeyboard PressKey(Key key);
    IGTKeyboard ReleaseKey(Key key);
    IGTKeyboard ClickKey(Key key);
    IGTKeyboard Type(string text);
}