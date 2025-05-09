using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Models.Tests
{
    [TestFixture()]
    public class ScreenShotTests
    {
        IGTWindow window;

        [SetUp()]
        public void setup()
        {
            window = TestHelpers.OpenExampleGui();
        }

        [TearDown()]
        public void TearDown()
        {
            window.Close();
            window.GetProcessOfWindow().kill(); TestHelpers.CloseExampleGui();
        }

        [Test()]
        public void ScreenShotTest()
        {
            IScreenShot screenShot = window.GetScreenshot();
            screenShot.SaveAsBitmap("D:\\temp\\img.bmp");
            Vector2i expectedImageSize = window.GetWindowContentSize();
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

        [Test()]
        public void GetPixelColorAtTest()
        {
            IScreenShot screenShot = window.GetScreenshot();
            Assert.That(screenShot.GetPixelColorAt(new Vector2i(10, 10)).Equals(Color.Red));
            ;
        }

        [Test()]
        public void SaveAsBitmapTest()
        {
            IScreenShot screenShot = window.GetScreenshot();
            string fileName = "test.bmp";
            screenShot.SaveAsBitmap(fileName);
            Assert.That(File.Exists(fileName), $"File {fileName} should exist");
            File.Delete(fileName);
        }

        [Test()]
        public void CompareToImageTest()
        {
            IScreenShot screenShot = window.GetScreenshot();
            //screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
            Assert.That(
                screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p) >0.96,
                $"Comparing to itself should return 1, instead {screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p)}"
            );
        }

        [Test()]
        public void CompareToImageTestBad()
        {
            IScreenShot screenShot = window.GetScreenshot();
            Assert.That(
                screenShot.CompareToImage(TestHelpers.InageReferance.BlackSquare) < 0.75,
                $"Comparing to itself should be smaller thna 0.75, instead {screenShot.CompareToImage(TestHelpers.InageReferance.BlackSquare)}"
            );
        }
    }
}
