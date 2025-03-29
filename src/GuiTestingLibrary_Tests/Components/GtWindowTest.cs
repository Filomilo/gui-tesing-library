using gui_tesing_library.Components;
using gui_tesing_library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;

namespace GuiTestingLibrary_Tets.Components
{
    [TestFixture]
    class GtWindowTest
    {
        private IGTProcess gtRocess;
        private IGTWindow window;

        [NUnit.Framework.SetUp]
        public void init()
        {

            gtRocess = SystemController.Instance.StartProcess(
                "\"C:\\Program Files\\Common Files\\Oracle\\Java\\javapath\\java\" -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
            );
            Assert.That(gtRocess.IsAlive);
            window = SystemController.Instance.WindowOfNameShouldExist("Hello!"). FindTopWindowByName("Hello!");
            Assert.That(window!=null);
           
        }
        [NUnit.Framework.TearDown]
        public void purge()
        {
            Assert.DoesNotThrow(() =>
            {
                gtRocess.kill();
            });
            window.Close();
            window.KillProcess();
            window.ShouldWindowExist(false);
            Assert.That(window.DoesExist == false);
            Assert.Throws<ArgumentException>(() =>
            {
                SystemController.Instance.FindTopWindowByName("Hello!");
            });
        }

        [Test]
        public void getWindowSizeTest()
        {
            Assert.DoesNotThrow(() =>
            {
                window.SizeShouldBe(new Vector2i(336, 279));
            });
          
            Assert.That(window.Size.x==336 && window.Size.y == 279);
        }
        [Test]
        public void setWindowSizeTest()
        {

            window.SetWindowSize(800, 600);
            Assert.That(window.Size.x == 800 && window.Size.y == 600);
        }
        [Test]
        public void setWindowPostionTest()
        {

            window.SetPostion(0, 0);
            Assert.That(window.Position.x == 0 && window.Position.y == 0);
        }


        [Test]
        public void minimizeMaximizeWindow()
        {
            Assert.That(window.IsMinimized==false);
            window.Minimize();
            Assert.That(window.ShouldBeMinimized(true).IsMinimized==true);
            window.BringUpFront();
            Assert.That(window.ShouldBeMinimized(false).IsMinimized == false);
            window.Maximize();
            Assert.That(window.Size.x == ScreenController.Instance.MaximizedWindowSize.x && window.Size.y == ScreenController.Instance.MaximizedWindowSize.y);
        }


    }
}
