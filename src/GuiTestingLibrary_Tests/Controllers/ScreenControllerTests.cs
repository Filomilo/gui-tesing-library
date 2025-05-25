using gui_tesing_library.Models;
using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Controllers.Tests;

[TestFixture]
public class ScreenControllerTests
{
    [Test]
    public void GetScreenshotTest()
    {
        var screenShot = ScreenController.Instance.GetScreenshot();
        screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
    }

    [Test]
    public void pixelColorShoudBe()
    {
        var windwo = TestHelpers.OpenExampleGui();

        var colorCheckPos = windwo.GetWindowContentPosition() + new Vector2i(10, 10);
        Assert.That(
            ScreenController
                .Instance.PixelAtShouldBeColor(colorCheckPos, Color.Red)
                .GetPixelColorAt(colorCheckPos)
                .Equals(Color.Red)
        );

        TestHelpers.CloseExampleGui();
    }

    [Test]
    public void getScrrenShotRect()
    {
        var windwo = TestHelpers.OpenExampleGui();

        var screenShot = ScreenController.Instance.GetScreenshotRect(
            windwo.GetWindowContentPosition(),
            windwo.GetWindowContentSize()
        );
        var similaity = 0.90f;
        Assert.That(
            screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p) > similaity,
            $"Expected simialotiy to be more tha {similaity} but {screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p)}"
        );

        TestHelpers.CloseExampleGui();
    }

    [Test]
    public void getSize()
    {
        var size = ScreenController.Instance.Size;
        Assert.That(size.x > 100 && size.y > 100);
    }
}