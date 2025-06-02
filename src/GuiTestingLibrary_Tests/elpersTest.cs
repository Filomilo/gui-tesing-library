using gui_tesing_library;
using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets;

[TestFixture]
internal class elpersTest
{
    [Test]
    public void keyTokeyCs()
    {
        Assert.That(Key_CS.RSHIFT == Helpers.keyToKeyCs(Key.RSHIFT));
        Assert.That(Key_CS.LCONTROL == Helpers.keyToKeyCs(Key.LCONTROL));
        Assert.That(Key_CS.RCONTROL == Helpers.keyToKeyCs(Key.RCONTROL));
        Assert.That(Key_CS.LSHIFT == Helpers.keyToKeyCs(Key.LSHIFT));
        Assert.That(Key_CS.NUMLOCK == Helpers.keyToKeyCs(Key.NUMLOCK));
        Assert.That(Key_CS.F24 == Helpers.keyToKeyCs(Key.F24));
        Assert.That(Key_CS.BACK == Helpers.keyToKeyCs(Key.BACK));
        Assert.That(Key_CS.F23 == Helpers.keyToKeyCs(Key.F23));
        Assert.That(Key_CS.F22 == Helpers.keyToKeyCs(Key.F22));
        Assert.That(Key_CS.F21 == Helpers.keyToKeyCs(Key.F21));
        Assert.That(Key_CS.F20 == Helpers.keyToKeyCs(Key.F20));
        Assert.That(Key_CS.F19 == Helpers.keyToKeyCs(Key.F19));
        Assert.That(Key_CS.F18 == Helpers.keyToKeyCs(Key.F18));
        Assert.That(Key_CS.F17 == Helpers.keyToKeyCs(Key.F17));
        Assert.That(Key_CS.F16 == Helpers.keyToKeyCs(Key.F16));
        Assert.That(Key_CS.F15 == Helpers.keyToKeyCs(Key.F15));
        Assert.That(Key_CS.F14 == Helpers.keyToKeyCs(Key.F14));
        Assert.That(Key_CS.F13 == Helpers.keyToKeyCs(Key.F13));
        Assert.That(Key_CS.F12 == Helpers.keyToKeyCs(Key.F12));
        Assert.That(Key_CS.F11 == Helpers.keyToKeyCs(Key.F11));
        Assert.That(Key_CS.F10 == Helpers.keyToKeyCs(Key.F10));
        Assert.That(Key_CS.F9 == Helpers.keyToKeyCs(Key.F9));
        Assert.That(Key_CS.F8 == Helpers.keyToKeyCs(Key.F8));
        Assert.That(Key_CS.F7 == Helpers.keyToKeyCs(Key.F7));
        Assert.That(Key_CS.F6 == Helpers.keyToKeyCs(Key.F6));
        Assert.That(Key_CS.F5 == Helpers.keyToKeyCs(Key.F5));
        Assert.That(Key_CS.F4 == Helpers.keyToKeyCs(Key.F4));
        Assert.That(Key_CS.F3 == Helpers.keyToKeyCs(Key.F3));
        Assert.That(Key_CS.F2 == Helpers.keyToKeyCs(Key.F2));
        Assert.That(Key_CS.F1 == Helpers.keyToKeyCs(Key.F1));
        Assert.That(Key_CS.DIVIDE == Helpers.keyToKeyCs(Key.DIVIDE));
        Assert.That(Key_CS.DECIMAL == Helpers.keyToKeyCs(Key.DECIMAL));
        Assert.That(Key_CS.SUBTRACT == Helpers.keyToKeyCs(Key.SUBTRACT));
        Assert.That(Key_CS.SEPARATOR == Helpers.keyToKeyCs(Key.SEPARATOR));
        Assert.That(Key_CS.ADD == Helpers.keyToKeyCs(Key.ADD));
        Assert.That(Key_CS.MULTIPLY == Helpers.keyToKeyCs(Key.MULTIPLY));
        Assert.That(Key_CS.NUMPAD_9 == Helpers.keyToKeyCs(Key.NUMPAD_9));
        Assert.That(Key_CS.NUMPAD_8 == Helpers.keyToKeyCs(Key.NUMPAD_8));
        Assert.That(Key_CS.NUMPAD_7 == Helpers.keyToKeyCs(Key.NUMPAD_7));
        Assert.That(Key_CS.NUMPAD_5 == Helpers.keyToKeyCs(Key.NUMPAD_5));
        Assert.That(Key_CS.NUMPAD_6 == Helpers.keyToKeyCs(Key.NUMPAD_6));
        Assert.That(Key_CS.NUMPAD_4 == Helpers.keyToKeyCs(Key.NUMPAD_4));
        Assert.That(Key_CS.NUMPAD_3 == Helpers.keyToKeyCs(Key.NUMPAD_3));
        Assert.That(Key_CS.NUMPAD_2 == Helpers.keyToKeyCs(Key.NUMPAD_2));
        Assert.That(Key_CS.NUMPAD_1 == Helpers.keyToKeyCs(Key.NUMPAD_1));
        Assert.That(Key_CS.NUMPAD_0 == Helpers.keyToKeyCs(Key.NUMPAD_0));
        Assert.That(Key_CS.KEY_Z == Helpers.keyToKeyCs(Key.KEY_Z));
        Assert.That(Key_CS.KEY_Y == Helpers.keyToKeyCs(Key.KEY_Y));
        Assert.That(Key_CS.KEY_X == Helpers.keyToKeyCs(Key.KEY_X));
        Assert.That(Key_CS.KEY_W == Helpers.keyToKeyCs(Key.KEY_W));
        Assert.That(Key_CS.KEY_V == Helpers.keyToKeyCs(Key.KEY_V));
        Assert.That(Key_CS.KEY_U == Helpers.keyToKeyCs(Key.KEY_U));
        Assert.That(Key_CS.KEY_T == Helpers.keyToKeyCs(Key.KEY_T));
        Assert.That(Key_CS.KEY_S == Helpers.keyToKeyCs(Key.KEY_S));
        Assert.That(Key_CS.KEY_R == Helpers.keyToKeyCs(Key.KEY_R));
        Assert.That(Key_CS.KEY_Q == Helpers.keyToKeyCs(Key.KEY_Q));
        Assert.That(Key_CS.KEY_O == Helpers.keyToKeyCs(Key.KEY_O));
        Assert.That(Key_CS.KEY_P == Helpers.keyToKeyCs(Key.KEY_P));
        Assert.That(Key_CS.KEY_N == Helpers.keyToKeyCs(Key.KEY_N));
        Assert.That(Key_CS.KEY_M == Helpers.keyToKeyCs(Key.KEY_M));
        Assert.That(Key_CS.KEY_L == Helpers.keyToKeyCs(Key.KEY_L));
        Assert.That(Key_CS.KEY_K == Helpers.keyToKeyCs(Key.KEY_K));
        Assert.That(Key_CS.KEY_J == Helpers.keyToKeyCs(Key.KEY_J));
        Assert.That(Key_CS.KEY_I == Helpers.keyToKeyCs(Key.KEY_I));
        Assert.That(Key_CS.KEY_H == Helpers.keyToKeyCs(Key.KEY_H));
        Assert.That(Key_CS.KEY_G == Helpers.keyToKeyCs(Key.KEY_G));
        Assert.That(Key_CS.KEY_F == Helpers.keyToKeyCs(Key.KEY_F));
        Assert.That(Key_CS.KEY_E == Helpers.keyToKeyCs(Key.KEY_E));
        Assert.That(Key_CS.KEY_D == Helpers.keyToKeyCs(Key.KEY_D));
        Assert.That(Key_CS.KEY_C == Helpers.keyToKeyCs(Key.KEY_C));
        Assert.That(Key_CS.KEY_B == Helpers.keyToKeyCs(Key.KEY_B));
        Assert.That(Key_CS.KEY_A == Helpers.keyToKeyCs(Key.KEY_A));
        Assert.That(Key_CS.KEY_9 == Helpers.keyToKeyCs(Key.KEY_9));
        Assert.That(Key_CS.KEY_8 == Helpers.keyToKeyCs(Key.KEY_8));
        Assert.That(Key_CS.KEY_7 == Helpers.keyToKeyCs(Key.KEY_7));
        Assert.That(Key_CS.KEY_6 == Helpers.keyToKeyCs(Key.KEY_6));
        Assert.That(Key_CS.KEY_5 == Helpers.keyToKeyCs(Key.KEY_5));
        Assert.That(Key_CS.KEY_4 == Helpers.keyToKeyCs(Key.KEY_4));
        Assert.That(Key_CS.KEY_3 == Helpers.keyToKeyCs(Key.KEY_3));
        Assert.That(Key_CS.KEY_2 == Helpers.keyToKeyCs(Key.KEY_2));
        Assert.That(Key_CS.KEY_1 == Helpers.keyToKeyCs(Key.KEY_1));
        Assert.That(Key_CS.KEY_0 == Helpers.keyToKeyCs(Key.KEY_0));
        Assert.That(Key_CS.KEY_DELETE == Helpers.keyToKeyCs(Key.DELETE));
        Assert.That(Key_CS.INSERT == Helpers.keyToKeyCs(Key.INSERT));
        Assert.That(Key_CS.PRINT == Helpers.keyToKeyCs(Key.PRINT));
        Assert.That(Key_CS.SELECT == Helpers.keyToKeyCs(Key.SELECT));
        Assert.That(Key_CS.DOWN == Helpers.keyToKeyCs(Key.DOWN));
        Assert.That(Key_CS.RIGHT == Helpers.keyToKeyCs(Key.RIGHT));
        Assert.That(Key_CS.UP == Helpers.keyToKeyCs(Key.UP));
        Assert.That(Key_CS.LEFT == Helpers.keyToKeyCs(Key.LEFT));
        Assert.That(Key_CS.HOME == Helpers.keyToKeyCs(Key.HOME));
        Assert.That(Key_CS.END == Helpers.keyToKeyCs(Key.END));
        Assert.That(Key_CS.SPACE == Helpers.keyToKeyCs(Key.SPACE));
        Assert.That(Key_CS.ESCAPE == Helpers.keyToKeyCs(Key.ESCAPE));
        Assert.That(Key_CS.PAUSE == Helpers.keyToKeyCs(Key.PAUSE));
        Assert.That(Key_CS.MENU == Helpers.keyToKeyCs(Key.MENU));
        Assert.That(Key_CS.CONTROL == Helpers.keyToKeyCs(Key.CONTROL));
        Assert.That(Key_CS.SHIFT == Helpers.keyToKeyCs(Key.SHIFT));
        Assert.That(Key_CS.RETURN == Helpers.keyToKeyCs(Key.RETURN));
        Assert.That(Key_CS.CLEAR == Helpers.keyToKeyCs(Key.CLEAR));
        Assert.That(Key_CS.TAB == Helpers.keyToKeyCs(Key.TAB));
    }

    [Test]
    public void keyToKeyCs_UnmappedKey_ThrowsArgumentException()
    {
        var unmappedKey = (Key)9999;
        var ex = Assert.Throws<ArgumentException>(() => Helpers.keyToKeyCs(unmappedKey));
    }

    [Test]
    public void ImageComparerConveriosnExpcetion()
    {
        Assert.Throws<ArgumentException>(
            () => Helpers.CSImageComparerToImageComparer((CS_IMAGE_COMPARER_TYPE)55555)
        );

        Assert.Throws<ArgumentException>(
            () =>
                Helpers.ImageCompaererToCsImageComparer(
                    (gui_tesing_library.Configuration.IMAGE_COMPARER)55555
                )
        );
    }
}