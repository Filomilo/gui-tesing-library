using System.ComponentModel.DataAnnotations;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Components;

[TestFixture]
internal class GtProcessTest
{
    [SetUp]
    public void init()
    {
        gtRocess = SystemController.Instance.StartProcess(TestHelpers.JavaExectutionCommand);
        Assert.That(gtRocess.IsAlive);
    }

    [TearDown]
    public void purge()
    {
        Assert.DoesNotThrow(() =>
        {
            gtRocess.kill();
        });
    }

    [Required]
    private IGTProcess gtRocess;

    [Test]
    public void TestRIghPreProcesNameTest()
    {
        var nameTobe = "java.exe";
        var nameRetived = gtRocess.Name.Split('\\').Last();
        Assert.That(
            nameRetived == nameTobe,
            $"extected proc name [[{nameRetived}]] to be [[{nameTobe}]]"
        );
    }

    [Test]
    public void TestGetRamUsage()
    {
        var ram = gtRocess.GetRamUsage();
        Assert.That(ram > 0, $"extected proc ram usage to bigger than 0 but is [[{ram}]]");
    }
}
