using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Models;

[TestFixture]
public class ColorTest
{
    [Test]
    public void ColorToString()
    {
        var color = new Color(255, 0, 0);
        Assert.That(color.ToString(), Is.EqualTo($"[{color.r},{color.g},{color.b}]"));
    }

    [Test]
    public void ColorGetHashCode()
    {
        var color = new Color(255, 0, 0);
        Assert.That(color.GetHashCode(), Is.Not.Null);
    }

    [Test]
    public void CopyColor()
    {
        var color = new Color(System.Drawing.Color.Red);
        Assert.That(color, Is.EqualTo(Color.Red));
    }

    [Test]
    public void EqualColorTest()
    {
        var color = Color.Red;
        Assert.That(color.Equals(null), Is.False);
        Assert.That(color.Equals(color), Is.True);
        Assert.That(color.Equals(new object()), Is.False);
    }
}
