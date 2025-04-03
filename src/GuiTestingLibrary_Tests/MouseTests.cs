using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            Vector2i WhiteoBUttonPOsiton = greeButonPOsiton + new Vector2i(0, -170);
            Vector2i ColorCheckPosion = greeButonPOsiton + new Vector2i(0, -250);

            Color initilaColor = window.GetContentPixelColorAt(ColorCheckPosion);
            Assert.That(
                initilaColor.Equals(Color.White),
                $"Initial color at {ColorCheckPosion} was not white but {initilaColor}"
            );

            MouseController.Instance.SetPosition(greeButonPOsiton);
            MouseController.Instance.ClickLeft();
            Assert.That(
                window.GetContentPixelColorAt(ColorCheckPosion).Equals(Color.Green),
                $"Initial color at {ColorCheckPosion} was not green but {window.GetContentPixelColorAt(ColorCheckPosion)}"
            );

            MouseController.Instance.SetPosition(blackoBUttonPOsiton);
            MouseController.Instance.ClickLeft();
            Assert.That(
                window.GetContentPixelColorAt(ColorCheckPosion).Equals(Color.Black),
                $"Initial color at {ColorCheckPosion} was not black but {window.GetContentPixelColorAt(ColorCheckPosion)}"
            );

            Thread.Sleep(5000);
            TestHelpers.CloseExampleGui();
        }
    }
}
