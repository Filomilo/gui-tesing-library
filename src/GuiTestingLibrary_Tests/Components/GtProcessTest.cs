using System.ComponentModel.DataAnnotations;
using gui_tesing_library;
using gui_tesing_library.Controllers;
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
            gtRocess = SystemController.Instance.StartProcess(TestHelpers.JavaExectutionCommand);
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

        [Test]
        public void TestRIghPreProcesNameTest()
        {
            String nameTobe = "java.exe";
            String nameRetived = gtRocess.Name.Split('\\').Last();
            Assert.That(
                nameRetived == nameTobe,
                $"extected proc name [[{nameRetived}]] to be [[{nameTobe}]]"
            );
        }

        [Test]
        public void TestGetRamUsage()
        {
            long ram = gtRocess.GetRamUsage();
            Assert.That(ram > 0, $"extected proc ram usage to bigger than 0 but is [[{ram}]]");
        }
    }
}
