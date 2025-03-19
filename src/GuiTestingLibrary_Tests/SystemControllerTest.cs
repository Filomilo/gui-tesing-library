using gui_tesing_library;
using NUnit.Framework;
using gui_tesing_library.Components;
using System.Diagnostics;

namespace GuiTestingLibrary_Tets
{
    [TestFixture]
    public class SystemControllerTest
    {
        [Test]
        public void Test_GetOSVersion()
        {
           OperatingSystem os= SystemController.Instance.GetOSVersion();
            Assert.That("Win32NT"==os.Platform.ToString());
            Assert.That(10==os.Version.Major);
        }
        [Test] 
        public void Test_StartProces()
        {
            GTProcess gtRocess = SystemController.Instance.StartProcess(
                "java -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
                );
            Assert.That(gtRocess.ProcesId>0);
            Assert.That(gtRocess.kill() >= 0);
        }

    }
}