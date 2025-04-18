using NUnit.Framework;
using gui_tesing_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using GuiTestingLibrary_Tets;

namespace gui_tesing_library.Models.Tests
{
    [TestFixture()]
    public class ScreenShotTests
    {

        IGTWindow window;
        [SetUp()]
        public void setup()
        {
            window=TestHelpers.OpenExampleGui();
        }

        [TearDown()]
        public void TearDown()
        {
            window.Close();
            window.GetProcessOfWindow().kill();
        }


        [Test()]
        public void ScreenShotTest()
        {
            ScreenShot screenShot = window.GetScreenshot();
            Vector2i expectedImageSize=window.GetWindowContentSize();
            Assert.That(screenShot != null);
            Assert.That(screenShot.Width > 0);
            Assert.That(screenShot.Height > 0);
            Assert.That(screenShot.Width == expectedImageSize.x,$"Screenshot width is [[{screenShot.Width}]] and expected [[{expectedImageSize.x}]]");
            Assert.That(screenShot.Height == expectedImageSize.y, $"Screenshot width is [[{screenShot.Height}]] and expected [[{expectedImageSize.y}]]");

        }

        [Test()]
        public void GetPixelColorAtTest()
        {
            ScreenShot screenShot = window.GetScreenshot();
            Assert.That(screenShot.GetPixelColorAt(new Vector2i(10, 10)).Equals(Color.Red));;
        }

        [Test()]
        public void SaveAsBitmapTest()
        {
            ScreenShot screenShot = window.GetScreenshot();
            string fileName = "test.bmp";
            screenShot.SaveAsBitmap(fileName);
            Assert.That(File.Exists(fileName), $"File {fileName} should exist");
            File.Delete(fileName);
        }

        [Test()]
        public void CompareToImageTest()
        {
            ScreenShot screenShot = window.GetScreenshot();
            Assert.That(screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p) ==1, $"Comparing to itself should return 1, instead {screenShot.CompareToImage(TestHelpers.InageReferance.EntryWindow720p)}");
        }
        [Test()]
        public void CompareToImageTestBad()
        {
            ScreenShot screenShot = window.GetScreenshot();
            Assert.That(screenShot.CompareToImage(TestHelpers.InageReferance.BlackSquare) < 0.75, $"Comparing to itself should be smaller thna 0.75, instead {screenShot.CompareToImage(TestHelpers.InageReferance.BlackSquare)}");
        }

    }
}