using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Models.Tests;

[TestFixture]
public class ScreenShotTests
{
    [SetUp]
    public void setup()
    {
        window = TestHelpers.OpenExampleGui();
    }

    [TearDown]
    public void TearDown()
    {
        window.Close();
        window.GetProcessOfWindow().kill();
        TestHelpers.CloseExampleGui();
    }

    private IGTWindow window;

    [Test]
    public void ScreenShotTest()
    {
        var screenShot = window.GetScreenshot();
        screenShot.SaveAsBitmap("D:\\temp\\img.bmp");
        var expectedImageSize = window.GetWindowContentSize();
        Assert.That(screenShot != null);
        Assert.That(screenShot.Width > 0);
        Assert.That(screenShot.Height > 0);
        Assert.That(
            screenShot.Width == expectedImageSize.x,
            $"Screenshot width is [[{screenShot.Width}]] and expected [[{expectedImageSize.x}]]"
        );
        Assert.That(
            screenShot.Height == expectedImageSize.y,
            $"Screenshot width is [[{screenShot.Height}]] and expected [[{expectedImageSize.y}]]"
        );
    }

    [Test]
    public void GetPixelColorAtTest()
    {
        var screenShot = window.GetScreenshot();
        Assert.That(screenShot.GetPixelColorAt(new Vector2i(10, 10)).Equals(Color.Red));
        ;
    }

    [Test]
    public void SaveAsBitmapTest()
    {
        var screenShot = window.GetScreenshot();
        var fileName = "test.bmp";
        screenShot.SaveAsBitmap(fileName);
        Assert.That(File.Exists(fileName), $"File {fileName} should exist");
        File.Delete(fileName);
    }

    [Test]
    public void CompareToImageTest()
    {
        var screenShot = window.GetScreenshot();
        //screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
        Assert.That(
            screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p) > 0.95,
            $"Comparing to itself should return bi bebr ta 0.96"
                + $", instead {screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p)}"
        );
    }

    [Test]
    public void CompareToImageTestBad()
    {
        var screenShot = window.GetScreenshot();
        Assert.That(
            screenShot.CompareToImage(TestHelpers.InageReferance.BlackSquare) < 0.75,
            $"Comparing to itself should be smaller thna 0.75, instead {screenShot.CompareToImage(TestHelpers.InageReferance.BlackSquare)}"
        );
    }
}
