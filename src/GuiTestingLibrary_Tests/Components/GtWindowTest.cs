using gui_tesing_library.Components;
using gui_tesing_library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiTestingLibrary_Tets.Components
{
    [TestFixture]
    class GtWindowTest
    {
        private GTProcess gtRocess;
        private GTWindow window;

        [NUnit.Framework.SetUp]
        public void init()
        {

            gtRocess = SystemController.Instance.StartProcess(
                "java -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
            );
            Assert.That(gtRocess.ProcesId > 0);

            Thread.Sleep(5000 );
            window = SystemController.Instance.GetWindowByName("Hello!");
            Assert.That(window!=null);

        }
        [NUnit.Framework.TearDown]
        public void purge()
        {
            Assert.That(gtRocess.kill() >= 0);
        }

        [Test]
        public void getWindowSize()
        {
         
            Console.WriteLine(window.Size);
            Assert.That(window.Size.X==336 && window.Size.Y == 279);
        }


    }
}
