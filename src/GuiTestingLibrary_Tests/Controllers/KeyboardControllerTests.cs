using gui_tesing_library.Models;
using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Controllers.Tests;

[TestFixture]
public class KeyboardControllerTests
{
    [SetUp]
    public void setup()
    {
        window = TestHelpers.OpenExampleGui();
    }

    [TearDown]
    public void TearDown()
    {
        window.GetProcessOfWindow().kill();
        //TestHelpers.CloseExampleGui();
    }

    private IGTWindow window;

    [Test]
    public void PressReleaseKeyTest()
    {
        var Title = "Test_";
        MouseController
            .Instance.SetPositionRelativeToWindow(
                window,
                TestHelpers.RelativePostions.windowNameINputPos
            )
            .ClickLeft();
        KeyboardController
            .Instance.Type(Title)
            .PressKey(Key.CONTROL)
            .ClickKey(Key.KEY_A)
            .ClickKey(Key.KEY_C)
            .ClickKey(Key.KEY_V)
            .ClickKey(Key.KEY_V)
            .ReleaseKey(Key.CONTROL);

        MouseController
            .Instance.SetPositionRelativeToWindow(
                window,
                TestHelpers.RelativePostions.ChangeWindowTitleButtonPositon
            )
            .ClickLeft();
        Title = Title + Title;
        Assert.That(
            window.WindowNameShouldBe(Title).GetWindowName().Equals(Title),
            $"Window title is not [[{Title}]] but [[{window.GetWindowName()}]]"
        );
        window.WindowNameShouldBe(Title).GetProcessOfWindow().kill();
    }

    [Test]
    public void ClickKeyTest()
    {
        var Title = "0a p";
        MouseController
            .Instance.SetPositionRelativeToWindow(
                window,
                TestHelpers.RelativePostions.windowNameINputPos
            )
            .ClickLeft();

        KeyboardController
            .Instance.ClickKey(Key.KEY_0)
            .ClickKey(Key.KEY_A)
            .ClickKey(Key.SPACE)
            .ClickKey(Key.KEY_P);
        MouseController
            .Instance.SetPositionRelativeToWindow(
                window,
                TestHelpers.RelativePostions.ChangeWindowTitleButtonPositon
            )
            .ClickLeft();

        Assert.That(
            window.WindowNameShouldBe(Title).GetWindowName().Equals(Title),
            $"Window title is not [[{Title}]] but [[{window.GetWindowName()}]]"
        );
    }

    [Test]
    public void TypeTest()
    {
        var Title = "Test_";
        MouseController
            .Instance.SetPositionRelativeToWindow(
                window,
                TestHelpers.RelativePostions.windowNameINputPos
            )
            .ClickLeft();
        KeyboardController.Instance.Type(Title);
        MouseController
            .Instance.SetPositionRelativeToWindow(
                window,
                TestHelpers.RelativePostions.ChangeWindowTitleButtonPositon
            )
            .ClickLeft();

        Assert.That(
            window.WindowNameShouldBe(Title).GetWindowName().Equals(Title),
            $"Window title is not [[{Title}]] but [[{window.GetWindowName()}]]"
        );
    }
}