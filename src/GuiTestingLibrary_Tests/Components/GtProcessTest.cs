using System.ComponentModel.DataAnnotations;
using gui_tesing_library;
using NUnit.Framework;


namespace GuiTestingLibrary_Tets.Components
{
    [TestFixture]
    class GtProcessTest
    {
        [Required]
        private IGTProcess gtRocess;


        [NUnit.Framework.SetUp]
        public void init()
        {

            gtRocess = SystemController.Instance.StartProcess(
                "\"C:\\Program Files\\Common Files\\Oracle\\Java\\javapath\\java\" -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
            );
            Assert.That(gtRocess.IsAlive);


        }
        [NUnit.Framework.TearDown]
        public void purge()
        {
            Assert.DoesNotThrow(() =>
            {
                gtRocess.kill();
            });
        }



    }
}
