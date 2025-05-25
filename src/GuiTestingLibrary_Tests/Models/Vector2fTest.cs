using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Models;

[TestFixture]
public class Vector2fTest
{
    [Test]
    public void subtractTest()
    {
        var a = new Vector2f(10, 10);
        var b = new Vector2f(2, 2);
        var subtractExpected = new Vector2f(8, 8);
        Assert.That((a - b).Equals(subtractExpected));
    }

    [Test]
    public void addTest()
    {
        var a = new Vector2f(10, 10);
        var b = new Vector2f(2, 2);
        var addtExpected = new Vector2f(12, 12);
        Assert.That((a + b).Equals(addtExpected));
    }

    [Test]
    public void toStringTest()
    {
        var a = new Vector2f(2, 2);
        Assert.That(a.ToString().Equals($"[{a.x};{a.y}]"));
    }

    [Test]
    public void equlafiales()
    {
        var a = new Vector2f(2, 2);
        Assert.That(!a.Equals(new object()));
        Assert.That(!a.Equals(null));
        Assert.That(a.Equals(a));
    }

    [Test]
    public void divisinTest()
    {
        var a = new Vector2f(10, 10);
        var b = new Vector2f(2, 2);
        var subtractExpected = new Vector2f(5, 5);
        Assert.That((a / b).Equals(subtractExpected));
    }

    [Test]
    public void divisinbyIntTest()
    {
        var a = new Vector2f(10, 10);
        var b = 2;
        var subtractExpected = new Vector2f(5, 5);
        Assert.That((a / b).Equals(subtractExpected));
    }

    [Test]
    public void getHash()
    {
        var a = new Vector2f(10, 10);
        Assert.That(a.GetHashCode() != null);
    }

    [Test]
    public void castFromANtiveTestthTest()
    {
        var a = new Vector2f(2, 2);
        var b = new Vector2f(new Vector2f_CS(2, 2));
        Assert.That(a.Equals(b));
    }

    [Test]
    public void nativeTest()
    {
        Vector2f_CS a = new Vector2f_CS(2, 2);
        Vector2f_CS b = new Vector2f(2, 2).Native();
        Assert.That(a.x.Equals(b.x) && a.y.Equals(b.y));
    }

    [Test]
    public void castFomrVector2i()
    {
        var a = new Vector2f(2, 2);
        var b = (Vector2f)new Vector2i(2, 2);
        Assert.That(a.Equals(b));
    }

    [Test]
    public void areaTest()
    {
        var a = new Vector2f(2, 2);
        Assert.That(a.Area().Equals(4));
    }

    [Test]
    public void distnaceFrom()
    {
        var a = new Vector2f(0, 0);
        var b = new Vector2f(4, 3);
        float expteced_distance = 5;
        Assert.That(
            a.DistanceFrom(b).Equals(expteced_distance),
            $"expecte distacne form to be {expteced_distance} but is {a.DistanceFrom(b)}"
        );
    }
}