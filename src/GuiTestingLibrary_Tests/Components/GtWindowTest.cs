using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library;
using gui_tesing_library.Components;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Components
{
    [TestFixture]
    class GtWindowTest
    {
        private IGTProcess gtRocess;
        private IGTWindow window;

        [NUnit.Framework.SetUp]
        public void init()
        {
            gtRocess = SystemController.Instance.StartProcess(
                "\"C:\\Program Files\\Common Files\\Oracle\\Java\\javapath\\java\" -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
            );
            Assert.That(gtRocess.IsAlive);
            window = SystemController
                .Instance.WindowOfNameShouldExist("Hello!")
                .FindTopWindowByName("Hello!");
            Assert.That(window != null);
        }

        [NUnit.Framework.TearDown]
        public void purge()
        {
            Assert.DoesNotThrow(() =>
            {
                gtRocess.kill();
            });
            window.Close();
            window.KillProcess();
            window.ShouldWindowExist(false);
            Assert.That(window.DoesExist == false);
            Assert.Throws<ArgumentException>(() =>
            {
                SystemController.Instance.FindTopWindowByName("Hello!");
            });
        }

        [Test]
        public void getWindowSizeTest()
        {
            Assert.DoesNotThrow(() =>
            {
                window.SizeShouldBe(new Vector2i(336, 279));
            });

            Assert.That(window.Size.x == 336 && window.Size.y == 279);
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
            Assert.That(window.Position.x == 0 && window.Position.y == 0);
        }

        [Test]
        public void minimizeMaximizeWindow()
        {
            Assert.That(window.IsMinimized == false);
            window.Minimize();
            Assert.That(window.ShouldBeMinimized(true).IsMinimized == true);
            window.BringUpFront();
            Assert.That(window.ShouldBeMinimized(false).IsMinimized == false);
            window.Maximize();
            Assert.That(
                window.Size.x == ScreenController.Instance.MaximizedWindowSize.x
                    && window.Size.y == ScreenController.Instance.MaximizedWindowSize.y
            );
        }

        [Test]
        public void GetScreenShot()
        {
            window.ShouldBeMinimized(false);
            Thread.Sleep(1000);
            ScreenShot screenShot = window.GetScreenshot();
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
            Thread.Sleep(1000);

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

            gui_tesing_library.Configuration.ActionDelay = 0;
            for (int x = 0; x < colorGridSize; x++)
            {
                for (int y = 0; y < colorGridSize; y++)
                {
                    Color colorLeftTop = window.GetContentPixelColorAt(new Vector2i(x, y));
                    Assert.That(
                        colorLeftTop.Equals(Color.Red),
                        $"Color at {x},{y} is {colorLeftTop} not {Color.Red}"
                    );
                }
            }
            for (int x = 0; x < colorGridSize; x++)
            {
                for (int y = 0; y < colorGridSize; y++)
                {
                    Vector2i pixelpos = new Vector2i(contentSize.x - x, y);
                    Color colorRightTop = window.GetContentPixelColorAt(pixelpos);
                    Assert.That(
                        colorRightTop.Equals(Color.Black),
                        $"Color at {pixelpos} is {colorRightTop} not {Color.Black}"
                    );
                }
            }
            for (int x = 0; x < colorGridSize; x++)
            {
                for (int y = 0; y < colorGridSize; y++)
                {
                    Vector2i pixelpos = new Vector2i(x, contentSize.y - y);
                    Color colorLeftBottom = window.GetContentPixelColorAt(pixelpos);
                    Assert.That(
                        colorLeftBottom.Equals(Color.Green),
                        $"Color at {pixelpos} is {colorLeftBottom} not {Color.Green}"
                    );
                }
            }
            //Color colorMiddleTop = window.GetContentPixelColorAt(
            //    new Vector2i(window.GetWindowContentSize().x / 2, 0)
            //);
            //Assert.That(colorMiddleTop.Equals(Color.Blue));

            //Color colorLeftBottom = window.GetContentPixelColorAt(
            //    new Vector2i(0, window.GetWindowContentSize().y - 2)
            //);
            //Assert.That(colorLeftBottom.Equals(Color.Green));

            //Color colorRightBottom = window.GetContentPixelColorAt(
            //    new Vector2i(window.GetWindowContentSize().x, window.GetWindowContentSize().y)
            //);
            ////Assert.That(colorRightBottom.Equals(Color.Orange));

            //Color colorMiddleBottom = window.GetContentPixelColorAt(
            //    new Vector2i(window.GetWindowContentSize().x / 2, window.GetWindowContentSize().y)
            //);
            //Assert.That(colorMiddleBottom.Equals(Color.Aqua));

            //Color colorLeftMiddle = window.GetContentPixelColorAt(
            //    new Vector2i(0, window.GetWindowContentSize().y / 2)
            //);
            //Assert.That(colorLeftMiddle.Equals(Color.Yellow));
            //window.GetScreenshot().SaveAsBitmap("D:\\temp\\tmp.bmp");
            //Color colorRightMiddle = window.GetContentPixelColorAt(
            //    new Vector2i(
            //        window.GetWindowContentSize().x - 10,
            //        window.GetWindowContentSize().y / 2
            //    )
            //);
            //Assert.That(
            //    colorRightMiddle.Equals(Color.Pink),
            //    $"Got {colorRightMiddle} expected {Color.Pink}"
            //);
        }
    }
}
