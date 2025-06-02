using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Models;

[TestFixture]
public class SystemVersionTest
{
    [Test]
    public void csSystemVerion()
    {
        var gtSystemVersion = new GTSystemVersion(Environment.OSVersion);
        Assert.That(gtSystemVersion.VersionString, Is.Not.Null.Or.Empty);
    }
}
