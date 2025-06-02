using gui_tesing_library.Controllers;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets;

[TestFixture]
public class SystemControllerTest
{
    [Test]
    [Ignore("This test is platform specific")]
    public void Test_GetOSVersion()
    {
        var os = SystemController.Instance.OsVersion;
        Assert.That("Microsoft Windows NT 10.0.22631.0" == os.VersionString);
    }

    [Test]
    public void Test_StartProces()
    {
        var gtRocess = SystemController.Instance.StartProcess(
            "\"C:\\Program Files\\Common Files\\Oracle\\Java\\javapath\\java\" -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
        );
        Assert.That(gtRocess.IsAlive);
        Assert.DoesNotThrow(() => gtRocess.kill());
    }

    [Test]
    [Ignore("This test is platform specific")]
    public void Test_GetMaximisedWindowSize()
    {
        var MaxWindowsize = SystemController.Instance.MaximizedWindowSize;
        Assert.That(MaxWindowsize.x == 1936); // System specific
        Assert.That(MaxWindowsize.y == 1048);
    }
}