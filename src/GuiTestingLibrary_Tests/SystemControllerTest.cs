using gui_tesing_library;
using gui_tesing_library.Models;
using NUnit.Framework;
using System.Numerics;

namespace GuiTestingLibrary_Tets
{
    [TestFixture]
    public class SystemControllerTest
    {
        [Test]
        [Ignore("This test is platform specific")]
        public void Test_GetOSVersion()
        {
            GTSystemVersion os = SystemController.Instance.OsVersion;
            Assert.That("Microsoft Windows NT 10.0.22631.0" == os.VersionString);
        }
        [Test]
        public void Test_StartProces()
        {
            IGTProcess gtRocess = SystemController.Instance.StartProcess(
                "\"C:\\Program Files\\Common Files\\Oracle\\Java\\javapath\\java\" -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
                );
            Assert.That(gtRocess.IsAlive);
            Assert.DoesNotThrow((() => gtRocess.kill()));
        }
        [Test]
        [Ignore("This test is platform specific")]
        public void Test_GetMaximisedWindowSize()
        {
            Vector2 MaxWindowsize = SystemController.Instance.MaximizedWindowSize;
            Assert.That(MaxWindowsize.X == 1936); // System specific
            Assert.That(MaxWindowsize.Y == 1048);
        }

    }
}