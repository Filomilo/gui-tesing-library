using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library;
using gui_tesing_library.Components;
using NUnit.Framework;


namespace GuiTestingLibrary_Tets.Components
{
    [TestFixture]
    class GtProcessTest
    {
        private GTProcess gtRocess;


        [NUnit.Framework.SetUp]
        public void init()
        {
         
                gtRocess = SystemController.Instance.StartProcess(
                    "\"C:\\Program Files\\Common Files\\Oracle\\Java\\javapath\\java\" -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
                );
                Assert.That(gtRocess.ProcesId > 0);

            
    }
        [NUnit.Framework.TearDown]
        public void purge()
        {
            Assert.That(gtRocess.kill() >= 0);
        }


      
    }
}
