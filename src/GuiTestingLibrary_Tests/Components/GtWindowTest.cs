using System.ComponentModel.DataAnnotations;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Components
{
    [TestFixture]
    class GtWindowTest
    {
        [Required]
        private IGTProcess gtRocess;

        [Required]
        private IGTWindow window;

        [NUnit.Framework.SetUp]
        public void init()
        {
            window = TestHelpers.OpenExampleGui();
            Assert.That(window != null);
        }

        [NUnit.Framework.TearDown]
        public void purge()
        {
            TestHelpers.CloseExampleGui();
            Assert.That(window.DoesExist == false);
            Assert.That(
                SystemController.Instance.FindTopWindowByName("Hello!") == null,
                "Window with anme Hello should not exist"
            );
            ;
        }

        [Test]
        public void getWindowNameTest()
        {
            Assert.That(window.GetWindowName().Equals("Hello!"));
            Assert.That(window.WindowNameShouldBe("Hello!").GetWindowName().Equals("Hello!"));
        }

        [Test]
        public void getWindowSizeTest()
        {
            Assert.DoesNotThrow(() =>
            {
                window.SizeShouldBe(new Vector2i(1280, 720));
            });

            Assert.That(window.Size.x == 1280 && window.Size.y == 720);
        }

        [Test]
        public void setWindowSizeTest()
        {
            window.SetWindowSize(800, 600);
            Assert.That(window.Size.x == 800 && window.Size.y == 600);
        }

        [Test]
        public void setWindowPostionTest()
        {
            window.SetPostion(0, 0);
            Vector2i pos = window.Position;
            Assert.That(pos.x == 0 && pos.y == 0);
        }

        [Test]
        public void GetScreenShot()
        {
            window.ShouldBeMinimized(false);
            Thread.Sleep(1000);
            IScreenShot screenShot = window.GetScreenshot();
            Assert.That(screenShot != null);
            screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
        }

        [Test]
        public void getColorTest()
        {
            Assert.That(window.IsMinimized == false);
            window.ShouldBeMinimized(false);
            int colorGridSize = 30;
            Vector2i pos = new Vector2i(0, 0) + new Vector2i(250, 210);
            //Assert.That(
            //    window.PixelAtShouldBeColor(pos, red).GetPixelColorAt(pos).Equals(red),
            //    $"Pixel color at 0,0 was not red but {window.GetContentPixelColorAt(pos)}"
            //);
            Vector2i contentSize = window.GetWindowContentSize();
            Vector2i contentPs = window.GetWindowContentPosition();
            //Thread.Sleep(1000);
            ////////////////////////////////////////////////////////////////////
            //Vector2i rightCorenr = new Vector2i(window.GetWindowContentSize().x, 0);
            //Color colorRightTop = window.GetContentPixelColorAt(rightCorenr);
            //Assert.That(colorRightTop.Equals(Color.Black));

            //for (int i = 0; i < window.GetWindowContentSize().y; i += 10)
            //{
            //    for (int j = 0; j < window.GetWindowContentSize().x; j += 10)
            //    {
            //        Console.WriteLine(
            //            $"[[{j} ,{i}]]  -- " + window.GetContentPixelColorAt(new Vector2i(j, i))
            //        );
            //    }
            //}
            //Color colorLeftTop = window.GetContentPixelColorAt(new Vector2i(0, 0));
            //Assert.That(colorLeftTop.Equals(Color.Red));
            ////////////////////////////////////////////////////////////
            ///
            ///
            gui_tesing_library.Configuration.ActionDelay = 0;
            for (int x = 0; x < colorGridSize; x += 10)
            {
                for (int y = 0; y < colorGridSize; y += 10)
                {
                    Color colorLeftTop = window.GetContentPixelColorAt(new Vector2i(x, y));
                    Assert.That(
                        colorLeftTop.Equals(Color.Red),
                        $"Color at {x},{y} is {colorLeftTop} not {Color.Red} but [[{colorLeftTop}]] "
                    );
                }
            }
            for (int x = 0; x < colorGridSize; x += 10)
            {
                for (int y = 0; y < colorGridSize; y += 10)
                {
                    Vector2i pixelpos = new Vector2i(contentSize.x - x, y);
                    Color colorRightTop = window.GetContentPixelColorAt(pixelpos);
                    Assert.That(
                        colorRightTop.Equals(Color.Black),
                        $"Color at {pixelpos} is {colorRightTop} not {Color.Black}"
                    );
                }
            }
            for (int x = 0; x < colorGridSize; x += 10)
            {
                for (int y = 0; y < colorGridSize; y += 10)
                {
                    Vector2i pixelpos = new Vector2i(x, contentSize.y - y);
                    Color colorLeftBottom = window.GetContentPixelColorAt(pixelpos);
                    Assert.That(
                        colorLeftBottom.Equals(Color.Green),
                        $"Color at {pixelpos} is {colorLeftBottom} not {Color.Green}"
                    );
                }
            }
        }

        [Test()]
        public void GetPixelColorAtPostion()
        {
            Vector2i pos = new Vector2i(10, 10);
            Assert.That(
                window.PixelAtShouldBeColor(pos, Color.Red).GetPixelColorAt(pos).Equals(Color.Red),
                $"Pixel at {pos} shoud be RED but is {window.GetPixelColorAt(pos)}"
            );
        }

        [Test()]
        public void GetContentPixelColorAtPostion()
        {
            Vector2i pos = new Vector2i(1, 1);
            Assert.That(
                window
                    .ContentPixelAtShouldBeColor(pos, Color.Red)
                    .GetContentPixelColorAt(pos)
                    .Equals(Color.Red),
                $"Pixel at {pos} shoud be RED but is {window.GetPixelColorAt(pos)}"
            );
        }

        [Test()]
        public void GetwindowContentSize()
        {
            Vector2i windwoSize = new Vector2i(800, 800);
            window.SetWindowSize(windwoSize.x, windwoSize.y).CenterWindow();
            Vector2i expctedContentSize =
                windwoSize
                - new Vector2i(
                    SystemController.Instance.GetWindowBorderWidth() * 2
                        + SystemController.Instance.GetWindowPadding() * 2
                        + 1,
                    SystemController.Instance.GetWindowBorderHeight() * 2
                        + SystemController.Instance.GetWindowTitleBarHeight()
                        + SystemController.Instance.GetWindowPadding() * 2
                        + 5
                );
            Assert.That(
                window.GetWindowContentSize().Equals(expctedContentSize),
                $"Window content size should be {expctedContentSize} but is {window.GetWindowContentSize()}"
            );
        }

        [Test()]
        public void MinimizeMaximizeWindow()
        {
            window.Minimize();
            Assert.That(
                window.ShouldBeMinimized(true).IsMinimized,
                $"Window should be minimized but is not"
            );
            window.Maximize();

            Assert.That(
                window.ShouldBeMinimized(false).IsMinimized == false,
                $"Window should be maximized but is not"
            );
        }

        [Test()]
        public void GetWindowTitle()
        {
            String title = "Hello!";
            Assert.That(
                window.WindowNameShouldBe(title).GetWindowName().Equals(title),
                $"window title shoudl bse [[{title}]] but is {window.GetWindowName()}"
            );
            Assert.That(
                window.Name.Equals(title),
                $"window title shoudl bse [[{title}]] but is {window.GetWindowName()}"
            );
        }

        [Test()]
        public void SetGetPostion()
        {
            Vector2i pos = new Vector2i(100, 100);
            window.SetPostion(pos.x, pos.y);
            Assert.That(
                window.Position.Equals(pos),
                $"Window postion should be {pos} but is {window.Position}"
            );
        }

        [Test()]
        public void MoveWIndow()
        {
            Vector2i startpos = new Vector2i(100, 1000);
            Vector2i moveVEctor = new Vector2i(100, 100);
            window.SetPostion(startpos.x, startpos.y);
            Assert.That(
                window.Position.Equals(startpos),
                $"Window postion should be {startpos} but is {window.Position}"
            );
            window.MoveWindow(moveVEctor);
            Assert.That(
                window.Position.Equals(startpos + moveVEctor),
                $"Window postion should be {startpos} but is {window.Position}"
            );
        }

        [Test()]
        public void GetScrrensShot()
        {
            IScreenShot screenShot = window.GetScreenshot();

            Assert.That(
                screenShot.Width == (window.GetWindowContentSize().x),
                $"Screenshot image width should be {window.GetWindowContentSize().x} but is {screenShot.Width}"
            );
            Assert.That(
                screenShot.Height == (window.GetWindowContentSize().y),
                $"Screenshot image width should be {window.GetWindowContentSize().y} but is {screenShot.Height}"
            );

            Assert.That(
                screenShot.GetPixelColorAt(new Vector2i(0, 0)).Equals(Color.Red),
                $"Screenshot image at {new Vector2i(0, 0)} should be RED but is {screenShot.GetPixelColorAt(new Vector2i(0, 0))}"
            );
            double simmilarity = screenShot.CompareToImage(
                TestHelpers.InageReferance.EntryWindow720p
            );
            Assert.That(
                simmilarity > 0.95,
                $"Screenshot should be simmilat to EntryWindow720p but similiarity is {simmilarity}"
            );
        }

        [Test()]
        public void GetScrrensShotRect()
        {
            Vector2i rectPos = new Vector2i(0, 0);
            Vector2i rectSize = new Vector2i(100, 100);
            IScreenShot screenShot = window.GetScreenshotRect(rectPos, rectSize);
            //screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
            Assert.That(
                screenShot.Width == (rectSize.x),
                $"Screenshot image width should be {rectSize.x} but is {screenShot.Width}"
            );
            Assert.That(
                screenShot.Height == (rectSize.y),
                $"Screenshot image width should be {rectSize.y} but is {screenShot.Height}"
            );

            Assert.That(
                screenShot.GetPixelColorAt(new Vector2i(0, 0)).Equals(Color.Red),
                $"Screenshot image at {new Vector2i(0, 0)} should be RED but is {screenShot.GetPixelColorAt(new Vector2i(0, 0))}"
            );
            double simmilarity = screenShot.CompareToImage(
                TestHelpers.InageReferance.EntryWindow720p100px
            );
            Assert.That(
                simmilarity > 0.95,
                $"Screenshot should be simmilat to EntryWindow720p100px but similiarity is {simmilarity}"
            );
        }
    }
}
