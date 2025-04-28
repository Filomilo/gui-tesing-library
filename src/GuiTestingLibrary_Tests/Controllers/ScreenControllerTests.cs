using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
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
            screenShot.SaveAsBitmap("C\\test.bmp");
        }
    }
}
