using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;

namespace gui_tesing_library.Controllers.Tests
{
    [TestFixture()]
    public class ScreenControllerTests
    {
        [Test()]
        public void GetScreenshotTest()
        {
            ScreenShot screenShot = ScreenController.Instance.GetScreenshot();
            screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
        }
    }
}
