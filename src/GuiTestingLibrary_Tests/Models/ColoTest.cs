using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Models
{
    [TestFixture]
    public class ColorTest
    {
        [Test]
        public void ColorToString()
        {
            gui_tesing_library.Models.Color color = new gui_tesing_library.Models.Color(255, 0, 0);
            Assert.That(color.ToString(), Is.EqualTo($"[{color.r},{color.g},{color.b}]"));
        }

        [Test]
        public void ColorGetHashCode()
        {
            gui_tesing_library.Models.Color color = new gui_tesing_library.Models.Color(255, 0, 0);
            Assert.That(color.GetHashCode(), Is.Not.Null);
        }

        [Test]
        public void CopyColor()
        {
            gui_tesing_library.Models.Color color = new Color(System.Drawing.Color.Red);
            Assert.That(color, Is.EqualTo(Color.Red));
        }

        [Test]
        public void EqualColorTest()
        {
            gui_tesing_library.Models.Color color = Color.Red;
            Assert.That(color.Equals(null), Is.False);
            Assert.That(color.Equals(color), Is.True);
            Assert.That(color.Equals(new object()), Is.False);
        }
    }
}
