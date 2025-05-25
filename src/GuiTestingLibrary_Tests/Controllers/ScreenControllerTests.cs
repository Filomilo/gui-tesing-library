using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Controllers.Tests
{
    [TestFixture()]
    public class ScreenControllerTests
    {
        [Test()]
        public void GetScreenshotTest()
        {
            IScreenShot screenShot = ScreenController.Instance.GetScreenshot();
            screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
        }

        [Test()]
        public void pixelColorShoudBe()
        {
            IGTWindow windwo = TestHelpers.OpenExampleGui();

            Vector2i colorCheckPos = windwo.GetWindowContentPosition() + new Vector2i(10, 10);
            Assert.That(
                ScreenController
                    .Instance.PixelAtShouldBeColor(colorCheckPos, Color.Red)
                    .GetPixelColorAt(colorCheckPos)
                    .Equals(Color.Red)
            );

            TestHelpers.CloseExampleGui();
        }

        [Test()]
        public void getScrrenShotRect()
        {
            IGTWindow windwo = TestHelpers.OpenExampleGui();

            IScreenShot screenShot = ScreenController.Instance.GetScreenshotRect(
                windwo.GetWindowContentPosition(),
                windwo.GetWindowContentSize()
            );
            float similaity = 0.90f;
            Assert.That(
                screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p) > similaity,
                $"Expected simialotiy to be more tha {similaity} but {screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p)}"
            );

            TestHelpers.CloseExampleGui();
        }

        [Test()]
        public void getSize()
        {
            Vector2i size = ScreenController.Instance.Size;
            Assert.That(size.x > 100 && size.y > 100);
        }
    }
}
