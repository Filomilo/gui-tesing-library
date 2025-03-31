using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using NUnit.Framework;

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
            Assert.That(newPos.Equals(MouseController.Instance.Position));
        }
    }
}
