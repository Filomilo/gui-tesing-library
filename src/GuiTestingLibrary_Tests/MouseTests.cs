using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library;
using gui_tesing_library.Controllers;
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
            Assert.That(newPos.Equals(MouseController.Instance.Position),$"Mouse position is not {newPos}",$"{newPos} Equals {MouseController.Instance.Position}");
        }
        [Test]
        public void testCloseWindow()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();

            Vector2i position = window.Position;
            Vector2i size = window.Size;
            Vector2i closePostion = new Vector2i(position.x + size.x-30, position.y+10);
            MouseController.Instance.SetPosition(closePostion).PositionShouldBe(closePostion);
            Assert.That(MouseController.Instance.Position.Equals(closePostion),$"Mouse controller is not on close button postion {closePostion} but {MouseController.Instance.Position}",$"{closePostion}=={MouseController.Instance.Position}");
            MouseController.Instance.ClickLeft();
            Assert.That(!window.ShouldWindowExist(false).DoesExist,$"Window {window.GetWindowName()} stil exist");
           
            

        }
    }
}
