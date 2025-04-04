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
        public void ColorSwicherTest()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();
            window.Maximize().ShouldBeMinimized(false);
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
            window.Maximize().ShouldBeMinimized(false);
            Thread.Sleep(300);

          
            Vector2i contentSize = window.GetWindowContentSize();
            int sliderLength = (contentSize.x - 140) / 3;
            int spaceBetwenSliders = (contentSize.y - 100) / 3 / 4;
            Vector2i sliderRedStartPostion = new Vector2i(contentSize.x / 3 , contentSize.y / 6)+new Vector2i(25,18);
            Vector2i sliderGrenStaVector2I = sliderRedStartPostion + new Vector2i(0, spaceBetwenSliders);
            Vector2i sliderBlueStaVector2I = sliderGrenStaVector2I + new Vector2i(0, spaceBetwenSliders);
            Vector2i currRedSliderPostion = sliderRedStartPostion;
            Vector2i currGreenSliderPostion = sliderGrenStaVector2I;
            Vector2i currBlueSliderPostion = sliderBlueStaVector2I;
            Vector2i colorCheckPostion = sliderRedStartPostion + new Vector2i(0, -spaceBetwenSliders);
            Color initColor = window.GetContentPixelColorAt(colorCheckPostion);
            Assert.That(initColor.Equals(Color.Black), $"Color at postion [[{colorCheckPostion}]] is not {Color.Black} but [[{initColor}]] ");
            //MouseController.Instance.SetPosition(sliderRedStartPostion);

            var setColor = (int r, int g, int b) =>
            {
                int redOffset =(int) Math.Ceiling (sliderLength * (r / 255.0));
                int greeOffset = (int)Math.Ceiling(sliderLength * (g / 255.0));
                int blueOffset = (int)Math.Ceiling(sliderLength * (b / 255.0));

                Vector2i newRedSliderPostion = sliderRedStartPostion + new Vector2i(redOffset, 0);
                Vector2i newGreenSliderPostion = sliderGrenStaVector2I + new Vector2i(greeOffset, 0);
                Vector2i newBlueSliderPostion = sliderBlueStaVector2I + new Vector2i(blueOffset, 0);

                MouseController.Instance.SetPosition(currRedSliderPostion);
                MouseController.Instance.PressLeft();
                MouseController.Instance.MoveMouseTo(newRedSliderPostion);
                MouseController.Instance.ReleaseLeft();

                MouseController.Instance.SetPosition(currGreenSliderPostion);
                MouseController.Instance.PressLeft();
                MouseController.Instance.MoveMouseTo(newGreenSliderPostion);
                MouseController.Instance.ReleaseLeft();

                MouseController.Instance.SetPosition(currBlueSliderPostion);
                MouseController.Instance.PressLeft();
                MouseController.Instance.MoveMouseTo(newBlueSliderPostion);
                MouseController.Instance.ReleaseLeft();

                currRedSliderPostion = newRedSliderPostion;
                currGreenSliderPostion = newGreenSliderPostion;
                currBlueSliderPostion = newBlueSliderPostion;

                Color Colorshouldbe = new Color(r, g, b);
                Color currColor = window.GetContentPixelColorAt(colorCheckPostion);
                Assert.That(currColor.Equals(Colorshouldbe), $"Color at postion [[{colorCheckPostion}]] is not {Colorshouldbe} but [[{currColor}]] ");


            };
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {

                int r = rnd.Next(0, 255);
                int g = rnd.Next(0, 255);
                int b = rnd.Next(0, 255);

                setColor(r,g,b);
            }

          
            Thread.Sleep(5000);
        }





    }
}
