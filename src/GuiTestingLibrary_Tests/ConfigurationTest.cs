using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets
{
    [TestFixture()]
    public class ConfigurationTest
    {


        [Test]
        public void testDelayTime()
        {
            int previoudDelyTime = gui_tesing_library.Configuration.ActionDelay;
            gui_tesing_library.Configuration.ActionDelay = previoudDelyTime+200;
            Assert.That(gui_tesing_library.Configuration.ActionDelay == previoudDelyTime + 200, $"" +
                $"Conifguraiotn delay time should be {previoudDelyTime + 200} but is {gui_tesing_library.Configuration.ActionDelay}");
            gui_tesing_library.Configuration.ActionDelay = previoudDelyTime;
        }

        [Test]
        public void testProcesAwaitTIme()
        {
            long prevoiusAwaitTime = gui_tesing_library.Configuration.ProcesAwaitTime;
            gui_tesing_library.Configuration.ProcesAwaitTime = prevoiusAwaitTime + 200;
            Assert.That(gui_tesing_library.Configuration.ProcesAwaitTime == prevoiusAwaitTime + 200, $"" +
                $"Conifguraiotn proces await tiome should be {prevoiusAwaitTime + 200} but is {gui_tesing_library.Configuration.ProcesAwaitTime}");
            gui_tesing_library.Configuration.ProcesAwaitTime = prevoiusAwaitTime;
        }
        [Test]
        public void testImageComparerType()
        {
gui_tesing_library.Configuration.IMAGE_COMPARER prevoudTime = gui_tesing_library.Configuration.ImageComparerType;
gui_tesing_library.Configuration.ImageComparerType = gui_tesing_library.Configuration.IMAGE_COMPARER.PIEXEL_BY_PIXEL;
       Assert.That(gui_tesing_library.Configuration.ImageComparerType == gui_tesing_library.Configuration.IMAGE_COMPARER.PIEXEL_BY_PIXEL, $"" +
                $"Conifguraiotn image comparer should be {gui_tesing_library.Configuration.IMAGE_COMPARER.PIEXEL_BY_PIXEL} but is {gui_tesing_library.Configuration.ImageComparerType}");
            gui_tesing_library.Configuration.ImageComparerType = prevoudTime;
        }
    }
}
