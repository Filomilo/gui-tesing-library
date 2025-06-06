﻿using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets;

[TestFixture]
internal class MouseTests
{
    [TearDown]
    public void UniversalTearDown()
    {
        TestHelpers.CloseExampleGui();
    }

    [Test]
    public void SetGetMousePostionTest()
    {
        var newPos = new Vector2i(100, 100);
        MouseController.Instance.SetPosition(newPos);
        Assert.That(
            newPos.Equals(MouseController.Instance.Position),
            $"Mouse position is not {newPos} but {MouseController.Instance.Position}",
            $"{newPos} Equals {MouseController.Instance.Position}"
        );
    }

    [Test]
    public void testCloseWindow()
    {
        var window = TestHelpers.OpenExampleGui();

        var position = window.Position;
        var size = window.Size;
        var closePostion = new Vector2i(position.x + size.x - 30, position.y + 10);
        Assert.DoesNotThrow(
            () =>
            {
                MouseController.Instance.SetPosition(closePostion).PositionShouldBe(closePostion);
            },
            $"Positon shuld be {closePostion} but is {MouseController.Instance.Position}"
        );
        Assert.That(
            MouseController.Instance.Position.Equals(closePostion),
            $"Mouse controller is not on close button postion {closePostion} but {MouseController.Instance.Position}",
            $"{closePostion}=={MouseController.Instance.Position}"
        );
        MouseController.Instance.ClickLeft();
        Assert.That(
            !window.ShouldWindowExist(false).DoesExist,
            $"Window {window.GetWindowName()} stil exist"
        );
    }

    [Test]
    public void testMouseMove()
    {
        var rnd = new Random();
        var mouseOffser = new Vector2i(rnd.Next(0, 100), rnd.Next(0, 100));
        //mouseOffser = new Vector2i(1000, 0);
        var startPostino = new Vector2i(100, 100);
        var finalPostion = startPostino + mouseOffser;
        MouseController.Instance.SetPosition(new Vector2i(100, 100));
        Assert.That(
            MouseController.Instance.PositionShouldBe(startPostino).Position.Equals(startPostino),
            $"Mouse position is not {startPostino} but {MouseController.Instance.Position}"
        );
        MouseController.Instance.MoveMouse(mouseOffser);
        Assert.DoesNotThrow(
            () =>
            {
                MouseController.Instance.PositionShouldBe(finalPostion, 2);
            },
            $"Mouse position is not {finalPostion} but {MouseController.Instance.Position} with move offset {mouseOffser}"
        );
    }

    [Test]
    public void ColorSwicherTest()
    {
        var window = TestHelpers.OpenExampleGui();
        gui_tesing_library.Configuration.ActionDelay = 100;
        window.SetWindowSize(1280, 720).CenterWindow();
        Thread.Sleep(1000);

        var initilaColor = window.GetContentPixelColorAt(
            TestHelpers.RelativePostions.ColorSwitcherColorTest
        );
        Assert.That(
            initilaColor.Equals(Color.Lime),
            $"Initial color at {TestHelpers.RelativePostions.ColorSwitcherColorTest} was not white but {initilaColor}"
        );

        MouseController.Instance.SetPositionRelativeToWindow(
            window,
            TestHelpers.RelativePostions.ColorSwitcherGreenButton
        );
        MouseController.Instance.ClickLeft();

        Assert.That(
            window
                .GetContentPixelColorAt(TestHelpers.RelativePostions.ColorSwitcherColorTest)
                .Equals(Color.Green),
            $"CHanged first color at {TestHelpers.RelativePostions.ColorSwitcherColorTest} was not green but {window.GetContentPixelColorAt(TestHelpers.RelativePostions.ColorSwitcherColorTest)}"
        );

        MouseController.Instance.SetPositionRelativeToWindow(
            window,
            TestHelpers.RelativePostions.ColorSwitcherWhiteButton
        );
        MouseController.Instance.ClickLeft();

        Assert.That(
            window
                .GetContentPixelColorAt(TestHelpers.RelativePostions.ColorSwitcherColorTest)
                .Equals(Color.White),
            $"CHanged first color at {TestHelpers.RelativePostions.ColorSwitcherColorTest} was not white  but {window.GetContentPixelColorAt(TestHelpers.RelativePostions.ColorSwitcherColorTest)}"
        );

        MouseController.Instance.SetPositionRelativeToWindow(
            window,
            TestHelpers.RelativePostions.ColorSwitcherBlackButton
        );
        MouseController.Instance.ClickLeft();

        Assert.That(
            window
                .GetContentPixelColorAt(TestHelpers.RelativePostions.ColorSwitcherColorTest)
                .Equals(Color.Black),
            $"CHanged first color at {TestHelpers.RelativePostions.ColorSwitcherColorTest} was not black  but {window.GetContentPixelColorAt(TestHelpers.RelativePostions.ColorSwitcherColorTest)}"
        );
    }

    [Test]
    public void GetPostionRelativeToWinodwTest()
    {
        var window = TestHelpers.OpenExampleGui();
        var pos = new Vector2f(0.5f, 0.5f);
        MouseController.Instance.SetPositionRelativeToWindow(window, pos);
        Thread.Sleep(1000);
        Assert.That(
            MouseController.Instance.GetPostionRelativeToWinodw(window).DistanceFrom(pos) < 0.01,
            $"Mouse postion reative to window should be [[{pos}]] but is [[{MouseController.Instance.GetPostionRelativeToWinodw(window)}]]"
        );
    }

    [Test]
    public void setMOusePostinoRelativeToWindwo()
    {
        var window = TestHelpers.OpenExampleGui();
        MouseController.Instance.SetPositionRelativeToWindow(window, new Vector2f(0.5f, 0.5f));
        Assert.DoesNotThrow(() =>
        {
            MouseController.Instance.PositionRelativeToWindowShouldBe(
                window,
                new Vector2f(0.5f, 0.5f),
                0.01f
            );
        });
    }

    [Test]
    public void moveMouseTo()
    {
        MouseController.Instance.SetPosition(new Vector2i(100, 100));
        Assert.That(
            MouseController
                .Instance.PositionShouldBe(new Vector2i(100, 100))
                .Position.Equals(new Vector2i(100, 100)),
            $"Mouse position is not {new Vector2i(100, 100)} but {MouseController.Instance.Position}"
        );
        MouseController.Instance.MoveMouseTo(new Vector2i(200, 200));
        Assert.DoesNotThrow(
            () =>
            {
                MouseController.Instance.PositionShouldBe(new Vector2i(200, 200), 2);
            },
            $"Mouse position is not {new Vector2i(200, 200)} but {MouseController.Instance.Position}"
        );
    }

    [Test]
    public void moveRealitveToWindow()
    {
        var window = TestHelpers.OpenExampleGui();
        var conntentPositon = window.GetWindowContentPosition();
        MouseController.Instance.SetPositionRelativeToWindow(window, new Vector2i(100, 100));
        Assert.That(
            MouseController
                .Instance.PositionShouldBe(conntentPositon + new Vector2i(100, 100))
                .Position.Equals(conntentPositon + new Vector2i(100, 100)),
            $"Mouse position is not {conntentPositon + new Vector2i(100, 100)} but {MouseController.Instance.Position}"
        );
        MouseController.Instance.MoveMouseRelativeToWindowTo(window, new Vector2i(200, 200));

        Assert.DoesNotThrow(
            () =>
            {
                MouseController.Instance.PositionShouldBe(
                    conntentPositon + new Vector2i(200, 200),
                    2
                );
            },
            $"Mouse position is not {conntentPositon + new Vector2i(200, 200)} but {MouseController.Instance.Position}"
        );
    }

    [Test]
    public void MoveRelativeToWindowRelative()
    {
        var window = TestHelpers.OpenExampleGui();

        MouseController.Instance.SetPositionRelativeToWindow(window, new Vector2i(100, 100));

        Assert.DoesNotThrow(() =>
        {
            MouseController.Instance.MoveMouseRelativeToWindowTo(window, new Vector2f(0.5f, 0.5f));
        });
        Thread.Sleep(1000);
        Assert.DoesNotThrow(() =>
        {
            MouseController.Instance.PositionRelativeToWindowShouldBe(
                window,
                new Vector2f(0.5f, 0.5f),
                0.02f
            );
        });
    }

    [Test]
    public void ColorSliderTest()
    {
        var window = TestHelpers.OpenExampleGui();
        gui_tesing_library.Configuration.ActionDelay = 50;
        //int sliderLength = (int)((contentSize.x - 100) * 0.32);
        //int sliderLength = (int)((contentSize.x - 100) * 0.126);
        //int spaceBetwenSliders = (contentSize.y - 100) / 3 / 4;
        //Vector2i sliderRedStartPostion = new Vector2i(
        //    (int)(contentSize.x * 0.36),
        //    (int)(contentSize.y * 0.23)
        //);
        //Vector2i sliderGrenStaVector2I =
        //    sliderRedStartPostion + new Vector2i(0, spaceBetwenSliders);
        //Vector2i sliderBlueStaVector2I =
        //    sliderGrenStaVector2I + new Vector2i(0, spaceBetwenSliders);
        var currRedSliderPostion = TestHelpers.RelativePostions.RedSliderStartPostion;
        var currGreenSliderPostion = TestHelpers.RelativePostions.GreenSliderStartPostion;
        var currBlueSliderPostion = TestHelpers.RelativePostions.BlueSliderStartPostion;
        //Vector2i colorCheckPostion =
        //    sliderRedStartPostion + new Vector2i(0, (int)(-spaceBetwenSliders * 1.5));
        //MouseController
        //    .Instance.MoveMouseTo(sliderRedStartPostion)
        //    .PositionShouldBe(sliderRedStartPostion);
        //MouseController.Instance.MoveMouseRelativeToWindowTo(window, TestHelpers.RelativePostions.SliderColorCheckPostion);

        //MouseController
        //    .Instance.SetPositionRelativeToWindow(window, sliderBlueStaVector2I)
        //    .PositionShouldBe(window.Position + sliderBlueStaVector2I)
        //    .MoveMouseTo(
        //        window.Position + sliderBlueStaVector2I + new Vector2i(sliderLength, 0)
        //    )
        //.MoveMouseTo(
        //    window.Position + sliderBlueStaVector2I + new Vector2i(sliderLength, 0)
        //)
        //.SetPosition(
        //    window.Position + sliderBlueStaVector2I + new Vector2i(sliderLength, 0)
        //)
        //.PositionShouldBe(
        //    window.Position + sliderBlueStaVector2I + new Vector2i(sliderLength, 0)
        //);
        //Thread.Sleep(3000);
        var initColor = window.GetContentPixelColorAt(
            TestHelpers.RelativePostions.SliderColorCheckPostion
        );

        Assert.That(
            initColor.Equals(Color.Black),
            $"Color at postion [[{TestHelpers.RelativePostions.SliderColorCheckPostion}]] is not {Color.Black} but [[{initColor}]] "
        );

        var setColor = (int r, int g, int b) =>
        {
            var redOffset = (float)(TestHelpers.RelativePostions.ColorSliderLength * (r / 255.0));
            var greeOffset = (float)(TestHelpers.RelativePostions.ColorSliderLength * (g / 255.0));
            var blueOffset = (float)(TestHelpers.RelativePostions.ColorSliderLength * (b / 255.0));

            var newRedSliderPostion =
                TestHelpers.RelativePostions.RedSliderStartPostion + new Vector2f(redOffset, 0f);
            var newGreenSliderPostion =
                TestHelpers.RelativePostions.GreenSliderStartPostion + new Vector2f(greeOffset, 0);
            var newBlueSliderPostion =
                TestHelpers.RelativePostions.BlueSliderStartPostion + new Vector2f(blueOffset, 0);
            Assert.That(
                newRedSliderPostion.x < TestHelpers.RelativePostions.RedSliderEndPostion.x,
                $"Red lisder move positn oshoudl be less then maximusm red slider postion, new positon [[{newRedSliderPostion}]] slider max [[{TestHelpers.RelativePostions.RedSliderEndPostion}]]"
            );
            Assert.That(
                newGreenSliderPostion.x < TestHelpers.RelativePostions.GreenSliderEndPostion.x,
                $"Green lisder move positn oshoudl be less then maximusm Green slider postion, new positon [[{newGreenSliderPostion}]] slider max [[{TestHelpers.RelativePostions.GreenSliderEndPostion}]]"
            );
            Assert.That(
                newBlueSliderPostion.x < TestHelpers.RelativePostions.BlueSliderEndPostion.x,
                $"Blue lisder move positn oshoudl be less then maximusm Blue slider postion, new positon [[{newBlueSliderPostion}]] slider max [[{TestHelpers.RelativePostions.BlueSliderEndPostion}]]"
            );

            window.BringUpFront();
            MouseController.Instance.SetPositionRelativeToWindow(window, currRedSliderPostion);
            MouseController.Instance.PressLeft();
            MouseController.Instance.MoveMouseRelativeToWindowTo(window, newRedSliderPostion);
            MouseController.Instance.ReleaseLeft();

            window.BringUpFront();
            MouseController.Instance.SetPositionRelativeToWindow(window, currGreenSliderPostion);
            MouseController.Instance.PressLeft();
            MouseController.Instance.MoveMouseRelativeToWindowTo(window, newGreenSliderPostion);
            MouseController.Instance.ReleaseLeft();

            window.BringUpFront();
            MouseController.Instance.SetPositionRelativeToWindow(window, currBlueSliderPostion);
            MouseController.Instance.PressLeft();
            MouseController.Instance.MoveMouseRelativeToWindowTo(window, newBlueSliderPostion);
            MouseController.Instance.ReleaseLeft();

            currRedSliderPostion = newRedSliderPostion;
            currGreenSliderPostion = newGreenSliderPostion;
            currBlueSliderPostion = newBlueSliderPostion;

            var Colorshouldbe = new Color(r, g, b);
            Thread.Sleep(100);
            var currColor = window
                .BringUpFront()
                .ContentPixelAtShouldBeColor(
                    TestHelpers.RelativePostions.SliderColorCheckPostion,
                    Colorshouldbe,
                    6
                )
                .GetContentPixelColorAt(TestHelpers.RelativePostions.SliderColorCheckPostion);

            Assert.That(
                currColor.getDiffrence(Colorshouldbe) < 6,
                $"Color at postion [[{TestHelpers.RelativePostions.SliderColorCheckPostion}]] is not {Colorshouldbe} but [[{currColor}]], Difrence: {currColor.getDiffrence(Colorshouldbe)} "
            );
        };
        var rnd = new Random();
        for (var i = 0; i < 5; i++)
        {
            var r = rnd.Next(0, 255);
            var g = rnd.Next(0, 255);
            var b = rnd.Next(0, 255);

            setColor(r, g, b);
        }

        Thread.Sleep(5000);
    }

    [Test]
    public void TestRIghtClickClose()
    {
        var windwoGtWindow = TestHelpers.OpenExampleGui();
        MouseController.Instance.SetPositionRelativeToWindow(windwoGtWindow, new Vector2i(20, -10));
        MouseController.Instance.ClickRight();
        MouseController.Instance.MoveMouse(new Vector2i(10, 130));
        MouseController.Instance.ClickLeft();
        Assert.DoesNotThrow(() =>
        {
            windwoGtWindow.ShouldWindowExist(false);
        });
        //Thread.Sleep(5000);
    }

    [Test]
    public void TestRIghPressReleaseClose()
    {
        var windwoGtWindow = TestHelpers.OpenExampleGui();
        MouseController.Instance.SetPositionRelativeToWindow(windwoGtWindow, new Vector2i(20, -10));
        MouseController.Instance.PressRight();
        MouseController.Instance.ReleaseRight();
        MouseController.Instance.MoveMouse(new Vector2i(10, 130));
        MouseController.Instance.ClickLeft();
        Assert.DoesNotThrow(() =>
        {
            windwoGtWindow.ShouldWindowExist(false);
        });
        //Thread.Sleep(5000);
    }

    [Test]
    public void drawingTest()
    {
        var windwoGtWindow = TestHelpers.OpenExampleGui();
        var CanvasPostion = TestHelpers.RelativePostions.CanvasPostion;
        var CanvasSize = TestHelpers.RelativePostions.CanvasSize;
        var startPositon = new Vector2i(
            (int)(windwoGtWindow.GetWindowContentSize().x * CanvasPostion.x),
            (int)(windwoGtWindow.GetWindowContentSize().y * CanvasPostion.y)
        );
        var endPostion = new Vector2i(
            (int)(windwoGtWindow.GetWindowContentSize().x * (CanvasSize.x + CanvasPostion.x)),
            (int)(windwoGtWindow.GetWindowContentSize().y * (CanvasSize.y + CanvasPostion.y))
        );
        var delayprevoid = gui_tesing_library.Configuration.ActionDelay;
        gui_tesing_library.Configuration.ActionDelay = 5;
        MouseController.Instance.ClickMiddle();
        var height = endPostion.y - startPositon.y;

        for (var y = startPositon.y; y < endPostion.y; y += 1)
        {
            MouseController.Instance.SetPositionRelativeToWindow(
                windwoGtWindow,
                new Vector2i(startPositon.x, y)
            );

            switch (y / (height / 3))
            {
                case 1:
                    MouseController.Instance.PressRight();
                    break;
                case 2:
                    MouseController.Instance.PressLeft();
                    break;
                case 3:
                    MouseController.Instance.PressMiddle();
                    break;
            }

            MouseController.Instance.MoveMouse(new Vector2i(endPostion.x - startPositon.x, 0));

            switch (y / (height / 3))
            {
                case 1:
                    MouseController.Instance.ReleaseRight();
                    break;
                case 2:
                    MouseController.Instance.ReleaseLeft();
                    break;
                case 3:
                    MouseController.Instance.ReleaseMiddle();
                    break;
            }
        }

        gui_tesing_library.Configuration.ActionDelay = delayprevoid;

        var screenshot = windwoGtWindow
            .BringUpFront()
            .GetScreenshotRect(startPositon, endPostion - startPositon);

        Assert.That(screenshot.CompareToImage(TestHelpers.InageReferance.DrawnCanvas) > 0.95);
    }

    [Test]
    public void ScrollTest()
    {
        var windwoGtWindow = TestHelpers.OpenExampleGui();
        MouseController.Instance.SetPositionRelativeToWindow(
            windwoGtWindow,
            TestHelpers.RelativePostions.ScrollTestPosition
        );
        var scrollDff = 100;
        gui_tesing_library.Configuration.ActionDelay = 10;
        for (var i = 0; i < 20000; i += scrollDff)
            MouseController.Instance.Scroll(-scrollDff);
        gui_tesing_library.Configuration.ActionDelay = 500;

        MouseController.Instance.ClickLeft();

        var color = windwoGtWindow.GetContentPixelColorAt(
            TestHelpers.RelativePostions.ScrollColorTestPosition
        );
        Assert.That(
            color.Equals(Color.Red),
            $"Color at postion [[{TestHelpers.RelativePostions.ScrollColorTestPosition}]] is not {Color.Red} but [[{color}]] "
        );
    }
}
