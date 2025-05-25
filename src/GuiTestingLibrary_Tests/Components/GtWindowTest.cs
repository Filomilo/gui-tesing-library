using System.ComponentModel.DataAnnotations;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Components;

[TestFixture]
internal class GtWindowTest
{
    [SetUp]
    public void init()
    {
        window = TestHelpers.OpenExampleGui();
        Assert.That(window != null);
    }

    [TearDown]
    public void purge()
    {
        TestHelpers.CloseExampleGui();
        Assert.That(window.DoesExist == false);
        Assert.DoesNotThrow(
            () =>
            {
                TestHelpers.EnsureTrue(() =>
                {
                    return SystemController.Instance.FindTopWindowByName("Hello!") == null;
                });
            },
            "Window with anme Hello should not exist"
        );
        ;
    }

    [Required]
    private IGTProcess gtRocess;

    [Required]
    private IGTWindow window;

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
        var pos = window.Position;
        Assert.That(pos.x == 0 && pos.y == 0);
    }

    [Test]
    public void GetScreenShot()
    {
        window.ShouldBeMinimized(false);
        Thread.Sleep(1000);
        var screenShot = window.GetScreenshot();
        Assert.That(screenShot != null);
        screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
    }

    [Test]
    public void getColorTest()
    {
        Assert.That(window.IsMinimized == false);
        window.ShouldBeMinimized(false);
        var colorGridSize = 30;
        var pos = new Vector2i(0, 0) + new Vector2i(250, 210);
        //Assert.That(
        //    window.PixelAtShouldBeColor(pos, red).GetPixelColorAt(pos).Equals(red),
        //    $"Pixel color at 0,0 was not red but {window.GetContentPixelColorAt(pos)}"
        //);
        var contentSize = window.GetWindowContentSize();
        var contentPs = window.GetWindowContentPosition();
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
        for (var x = 0; x < colorGridSize; x += 10)
        for (var y = 0; y < colorGridSize; y += 10)
        {
            var colorLeftTop = window.GetContentPixelColorAt(new Vector2i(x, y));
            Assert.That(
                colorLeftTop.Equals(Color.Red),
                $"Color at {x},{y} is {colorLeftTop} not {Color.Red} but [[{colorLeftTop}]] "
            );
        }

        for (var x = 0; x < colorGridSize; x += 10)
        for (var y = 0; y < colorGridSize; y += 10)
        {
            var pixelpos = new Vector2i(contentSize.x - x, y);
            var colorRightTop = window.GetContentPixelColorAt(pixelpos);
            Assert.That(
                colorRightTop.Equals(Color.Black),
                $"Color at {pixelpos} is {colorRightTop} not {Color.Black}"
            );
        }

        for (var x = 0; x < colorGridSize; x += 10)
        for (var y = 0; y < colorGridSize; y += 10)
        {
            var pixelpos = new Vector2i(x, contentSize.y - y);
            var colorLeftBottom = window.GetContentPixelColorAt(pixelpos);
            Assert.That(
                colorLeftBottom.Equals(Color.Green),
                $"Color at {pixelpos} is {colorLeftBottom} not {Color.Green}"
            );
        }
    }

    [Test]
    public void GetPixelColorAtPostion()
    {
        var pos = new Vector2i(10, 10);
        Assert.That(
            window.PixelAtShouldBeColor(pos, Color.Red).GetPixelColorAt(pos).Equals(Color.Red),
            $"Pixel at {pos} shoud be RED but is {window.GetPixelColorAt(pos)}"
        );
    }

    [Test]
    public void GetContentPixelColorAtPostion()
    {
        var pos = new Vector2i(1, 1);
        Assert.That(
            window
                .ContentPixelAtShouldBeColor(pos, Color.Red)
                .GetContentPixelColorAt(pos)
                .Equals(Color.Red),
            $"Pixel at {pos} shoud be RED but is {window.GetPixelColorAt(pos)}"
        );
    }

    [Test]
    public void GetwindowContentSize()
    {
        var windwoSize = new Vector2i(800, 800);
        window.SetWindowSize(windwoSize.x, windwoSize.y).CenterWindow();
        var expctedContentSize =
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

    [Test]
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

    [Test]
    public void GetWindowTitle()
    {
        var title = "Hello!";
        Assert.That(
            window.WindowNameShouldBe(title).GetWindowName().Equals(title),
            $"window title shoudl bse [[{title}]] but is {window.GetWindowName()}"
        );
        Assert.That(
            window.Name.Equals(title),
            $"window title shoudl bse [[{title}]] but is {window.GetWindowName()}"
        );
    }

    [Test]
    public void SetGetPostion()
    {
        var pos = new Vector2i(100, 100);
        window.SetPostion(pos.x, pos.y);
        Assert.That(
            window.Position.Equals(pos),
            $"Window postion should be {pos} but is {window.Position}"
        );
    }

    [Test]
    public void MoveWIndow()
    {
        var startpos = new Vector2i(100, 1000);
        var moveVEctor = new Vector2i(100, 100);
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

    [Test]
    public void GetScrrensShot()
    {
        var screenShot = window.GetScreenshot();

        Assert.That(
            screenShot.Width == window.GetWindowContentSize().x,
            $"Screenshot image width should be {window.GetWindowContentSize().x} but is {screenShot.Width}"
        );
        Assert.That(
            screenShot.Height == window.GetWindowContentSize().y,
            $"Screenshot image width should be {window.GetWindowContentSize().y} but is {screenShot.Height}"
        );

        Assert.That(
            screenShot.GetPixelColorAt(new Vector2i(0, 0)).Equals(Color.Red),
            $"Screenshot image at {new Vector2i(0, 0)} should be RED but is {screenShot.GetPixelColorAt(new Vector2i(0, 0))}"
        );
        double simmilarity = 0;
        Assert.DoesNotThrow(() =>
        {
            simmilarity = screenShot
                .SimmilarityBetweenImagesShouldBe(TestHelpers.InageReferance.EntryWindow720p, 0.9)
                .CompareToImage(TestHelpers.InageReferance.EntryWindow720p);
        });

        Assert.That(
            simmilarity > 0.95,
            $"Screenshot should be simmilat to EntryWindow720p but similiarity is {simmilarity}"
        );
    }

    [Test]
    public void GetScrrensShotRect()
    {
        var rectPos = new Vector2i(0, 0);
        var rectSize = new Vector2i(100, 100);
        var screenShot = window.GetScreenshotRect(rectPos, rectSize);
        //screenShot.SaveAsBitmap("D:\\temp\\test.bmp");
        Assert.That(
            screenShot.Width == rectSize.x,
            $"Screenshot image width should be {rectSize.x} but is {screenShot.Width}"
        );
        Assert.That(
            screenShot.Height == rectSize.y,
            $"Screenshot image width should be {rectSize.y} but is {screenShot.Height}"
        );

        Assert.That(
            screenShot.GetPixelColorAt(new Vector2i(0, 0)).Equals(Color.Red),
            $"Screenshot image at {new Vector2i(0, 0)} should be RED but is {screenShot.GetPixelColorAt(new Vector2i(0, 0))}"
        );
        var simmilarity = screenShot.CompareToImage(
            TestHelpers.InageReferance.EntryWindow720p100px
        );
        Assert.That(
            simmilarity > 0.95,
            $"Screenshot should be simmilat to EntryWindow720p100px but similiarity is {simmilarity}"
        );
    }

    [Test]
    public void WindowNameShouldBe()
    {
        Assert.DoesNotThrow(() =>
        {
            Assert.That(
                window.WindowNameShouldBe("Hello!").GetWindowName() == "Hello!"
                    && window.Name == "Hello!"
            );
        });
    }

    [Test]
    public void ContentPixleShouldBe()
    {
        Assert.DoesNotThrow(() =>
        {
            Assert.That(
                window
                    .ContentPixelAtShouldBeColor(new Vector2i(0, 0), Color.Red)
                    .GetContentPixelColorAt(new Vector2i(0, 0))
                    .Equals(Color.Red)
            );
        });
        Assert.DoesNotThrow(() =>
        {
            Assert.That(
                window
                    .PixelAtShouldBeColor(new Vector2i(10, 10), Color.Red)
                    .GetPixelColorAt(new Vector2i(10, 10))
                    .Equals(Color.Red)
            );
        });
    }

    [Test]
    public void ShouldBeMInimiezedTest()
    {
        Assert.DoesNotThrow(() =>
        {
            Assert.That(window.ShouldBeMinimized(false).IsMinimized == false);
            window.Minimize();
            Assert.That(window.ShouldBeMinimized(true).IsMinimized);
            window.Maximize();
            Assert.That(window.ShouldBeMinimized(false).IsMinimized == false);
        });
    }

    [Test]
    public void PositionTest()
    {
        Assert.DoesNotThrow(() =>
        {
            window.SetPostion(0, 0);
            Assert.That(window.Position.Equals(new Vector2i(0, 0)));
            window.MoveWindow(new Vector2i(100, 100));
            Assert.That(window.Position.Equals(new Vector2i(100, 100)));
        });
    }

    [Test]
    public void MaximizeWindow()
    {
        window.Maximize();
        Assert.That(window.ShouldBeMinimized(false).IsMinimized == false);
        var adjusrmetnd = new Vector2i(-16, 32);
        Assert.That(
            window.Size.x + adjusrmetnd.x == ScreenController.Instance.MaximizedWindowSize.x
                && window.Size.y + adjusrmetnd.y == ScreenController.Instance.MaximizedWindowSize.y,
            $"window size is {window.Size + adjusrmetnd} but maxmiezed window size is {ScreenController.Instance.MaximizedWindowSize}"
        );
    }
}
