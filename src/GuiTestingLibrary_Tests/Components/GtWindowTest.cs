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
            window = SystemController.Instance.GetWindowByName("Hello!");
            Assert.That(window!=null);
           
        }
        [NUnit.Framework.TearDown]
        public void purge()
        {
            Assert.That(gtRocess.kill() >= 0);
            window.KillProces();

            Assert.That(window.DoesExist() == false);
            Assert.That(SystemController.Instance.GetWindowByName("Hello!") == null);
            ;
        }

        [Test]
        public void getWindowSizeTest()
        {
         
            Assert.That(window.Size.X==336 && window.Size.Y == 279);
        }
        [Test]
        public void setWindowSizeTest()
        {

            window.SetWindowSize(800, 600);
            Assert.That(window.Size.X == 800 && window.Size.Y == 600);
        }
        [Test]
        public void setWindowPostionTest()
        {

            window.SetPostion(0, 0);
            Assert.That(window.Postion.X == 0 && window.Postion.Y == 0);
        }


        [Test]
        public void minimizeMaximizeWindow()
        {
            Assert.That(window.IsMinimized==false);
            window.Minimize();
            Assert.That(window.IsMinimized==true);
            window.BringUpFront();
            Assert.That(window.IsMinimized == false);
            window.Maximize();
            Assert.That(window.Size.X == SystemController.MaximizedWindowSize.X && window.Size.Y == SystemController.MaximizedWindowSize.Y);
        }


    }
}
