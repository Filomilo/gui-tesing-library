using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GuiTestingLibrary_Tets
{
    [TestFixture]
    class MouseTests
    {
        [TearDown]
        public void UniversalTearDown()
        {
            TestHelpers.CloseExampleGui();
        }

        [Test]
        public void SetGetMousePostionTest()
        {
            Vector2i newPos = new Vector2i(100, 100);
            MouseController.Instance.SetPosition(newPos);
            Assert.That(
                newPos.Equals(MouseController.Instance.Position),
                $"Mouse position is not {newPos}",
                $"{newPos} Equals {MouseController.Instance.Position}"
            );
        }

        [Test]
        public void testCloseWindow()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();

            Vector2i position = window.Position;
            Vector2i size = window.Size;
            Vector2i closePostion = new Vector2i(position.x + size.x - 30, position.y + 10);
            MouseController.Instance.SetPosition(closePostion).PositionShouldBe(closePostion);
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
            Random rnd = new Random();
            Vector2i mouseOffser = new Vector2i(rnd.Next(0, 100), rnd.Next(0, 100));
            //mouseOffser = new Vector2i(1000, 0);
            Vector2i startPostino = new Vector2i(100, 100);
            Vector2i finalPostion = startPostino + mouseOffser;
            MouseController.Instance.SetPosition(new Vector2i(100, 100));
            Assert.That(
                MouseController
                    .Instance.PositionShouldBe(startPostino)
                    .Position.Equals(startPostino),
                $"Mouse position is not {startPostino} but {MouseController.Instance.Position}"
            );
            MouseController.Instance.MoveMouse(mouseOffser);
            Assert.DoesNotThrow(
                () =>
                {
                    MouseController.Instance.PositionShouldBe(finalPostion);
                },
                $"Mouse position is not {finalPostion} but {MouseController.Instance.Position} with move offset {mouseOffser}"
            );
        }

        [Test]
        public void ColorSwicherTest()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();
            window.SetWindowSize(1280, 720).CenterWindow();
            Thread.Sleep(1000);

            Vector2i greeButonPOsiton =
                (window.Size - new Vector2i(30, 30)) / new Vector2i(6, 1) + new Vector2i(20, -80);
            Vector2i blackoBUttonPOsiton = greeButonPOsiton + new Vector2i(0, -80);
            Vector2i WhiteoBUttonPOsiton = greeButonPOsiton + new Vector2i(0, -150);
            Vector2i ColorCheckPosion = greeButonPOsiton + new Vector2i(0, -250);

            Color initilaColor = window.GetContentPixelColorAt(ColorCheckPosion);
            Assert.That(
                initilaColor.Equals(Color.Lime),
                $"Initial color at {ColorCheckPosion} was not white but {initilaColor}"
            );

            MouseController.Instance.SetPosition(greeButonPOsiton);
            MouseController.Instance.ClickLeft();

            Assert.That(
                window.GetContentPixelColorAt(ColorCheckPosion).Equals(Color.Green),
                $"CHanged first color at {ColorCheckPosion} was not green but {window.GetContentPixelColorAt(ColorCheckPosion)}"
            );

            MouseController.Instance.SetPosition(WhiteoBUttonPOsiton);
            MouseController.Instance.ClickLeft();

            Assert.That(
                window.GetContentPixelColorAt(ColorCheckPosion).Equals(Color.White),
                $"CHanged first color at {ColorCheckPosion} was not white  but {window.GetContentPixelColorAt(ColorCheckPosion)}"
            );

            MouseController.Instance.SetPosition(blackoBUttonPOsiton);
            MouseController.Instance.ClickLeft();

            Assert.That(
                window.GetContentPixelColorAt(ColorCheckPosion).Equals(Color.Black),
                $"CHanged first color at {ColorCheckPosion} was not black  but {window.GetContentPixelColorAt(ColorCheckPosion)}"
            );
        }

        [Test]
        public void ColorSliderTest()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();
            window.SetWindowSize(1280, 720).CenterWindow().BringUpFront();

            Vector2i contentSize = window.GetWindowContentSize();
            //int sliderLength = (int)((contentSize.x - 100) * 0.32);
            int sliderLength = (int)((contentSize.x - 100) * 0.126);
            int spaceBetwenSliders = (contentSize.y - 100) / 3 / 4;
            Vector2i sliderRedStartPostion = new Vector2i(
                (int)(contentSize.x * 0.36),
                (int)(contentSize.y * 0.23)
            );
            Vector2i sliderGrenStaVector2I =
                sliderRedStartPostion + new Vector2i(0, spaceBetwenSliders);
            Vector2i sliderBlueStaVector2I =
                sliderGrenStaVector2I + new Vector2i(0, spaceBetwenSliders);
            Vector2i currRedSliderPostion = sliderRedStartPostion;
            Vector2i currGreenSliderPostion = sliderGrenStaVector2I;
            Vector2i currBlueSliderPostion = sliderBlueStaVector2I;
            Vector2i colorCheckPostion =
                sliderRedStartPostion + new Vector2i(0, (int)(-spaceBetwenSliders * 1.5));
            Color initColor = window.GetContentPixelColorAt(colorCheckPostion);
            MouseController
                .Instance.MoveMouseTo(sliderRedStartPostion)
                .PositionShouldBe(sliderRedStartPostion);
            //MouseController.Instance.MoveMouseRelativeToWindowTo(window, sliderBlueStaVector2I);

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
            Thread.Sleep(3000);
            //Assert.That(
            //    initColor.Equals(Color.Black),
            //    $"Color at postion [[{colorCheckPostion}]] is not {Color.Black} but [[{initColor}]] "
            //);

            //var setColor = (int r, int g, int b) =>
            //{
            //    int redOffset = (int)Math.Ceiling(sliderLength * (r / 255.0));
            //    int greeOffset = (int)Math.Ceiling(sliderLength * (g / 255.0));
            //    int blueOffset = (int)Math.Ceiling(sliderLength * (b / 255.0));

            //    Vector2i newRedSliderPostion = sliderRedStartPostion + new Vector2i(redOffset, 0);
            //    Vector2i newGreenSliderPostion =
            //        sliderGrenStaVector2I + new Vector2i(greeOffset, 0);
            //    Vector2i newBlueSliderPostion = sliderBlueStaVector2I + new Vector2i(blueOffset, 0);
            //    window.BringUpFront();
            //    MouseController.Instance.SetPositionRelativeToWindow(window, currRedSliderPostion);
            //    MouseController.Instance.PressLeft();
            //    MouseController.Instance.MoveMouseRelativeToWindowTo(window, newRedSliderPostion);
            //    MouseController.Instance.ReleaseLeft();

            //    window.BringUpFront();
            //    MouseController.Instance.SetPositionRelativeToWindow(
            //        window,
            //        currGreenSliderPostion
            //    );
            //    MouseController.Instance.PressLeft();
            //    MouseController.Instance.MoveMouseRelativeToWindowTo(window, newGreenSliderPostion);
            //    MouseController.Instance.ReleaseLeft();

            //    window.BringUpFront();
            //    MouseController.Instance.SetPositionRelativeToWindow(window, currBlueSliderPostion);
            //    MouseController.Instance.PressLeft();
            //    MouseController.Instance.MoveMouseRelativeToWindowTo(window, newBlueSliderPostion);
            //    MouseController.Instance.ReleaseLeft();

            //    currRedSliderPostion = newRedSliderPostion;
            //    currGreenSliderPostion = newGreenSliderPostion;
            //    currBlueSliderPostion = newBlueSliderPostion;

            //    Color Colorshouldbe = new Color(r, g, b);
            //    Thread.Sleep(50);
            //    Color currColor = window.BringUpFront().GetContentPixelColorAt(colorCheckPostion);

            //    Assert.That(
            //        currColor.getDiffrence(Colorshouldbe) < 2,
            //        $"Color at postion [[{colorCheckPostion}]] is not {Colorshouldbe} but [[{currColor}]], Difrence: {currColor.getDiffrence(Colorshouldbe)} "
            //    );
            //};
            //Random rnd = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    int r = rnd.Next(0, 255);
            //    int g = rnd.Next(0, 255);
            //    int b = rnd.Next(0, 255);

            //    setColor(r, g, b);
            //}

            //Thread.Sleep(5000);
        }
    }
}
