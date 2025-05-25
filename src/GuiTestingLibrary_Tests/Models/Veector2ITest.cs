using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Models
{
    [TestFixture]
    public class Veector2ITest
    {
        [Test]
        public void subtractTest()
        {
            Vector2i a = new Vector2i(10, 10);
            Vector2i b = new Vector2i(2, 2);
            Vector2i subtractExpected = new Vector2i(8, 8);
            Assert.That((a - b).Equals(subtractExpected));
        }

        [Test]
        public void addTest()
        {
            Vector2i a = new Vector2i(10, 10);
            Vector2i b = new Vector2i(2, 2);
            Vector2i addtExpected = new Vector2i(12, 12);
            Assert.That((a + b).Equals(addtExpected));
        }

        [Test]
        public void toStringTest()
        {
            Vector2i a = new Vector2i(2, 2);
            Assert.That(a.ToString().Equals($"[{a.x};{a.y}]"));
        }

        [Test]
        public void equlafiales()
        {
            Vector2i a = new Vector2i(2, 2);
            Assert.That(!a.Equals(new object()));
            Assert.That(!a.Equals(null));
            Assert.That(a.Equals(a));
        }

        [Test]
        public void divisinTest()
        {
            Vector2i a = new Vector2i(10, 10);
            Vector2i b = new Vector2i(2, 2);
            Vector2i subtractExpected = new Vector2i(5, 5);
            Assert.That((a / b).Equals(subtractExpected));
        }

        [Test]
        public void divisinbyIntTest()
        {
            Vector2i a = new Vector2i(10, 10);
            int b = 2;
            Vector2i subtractExpected = new Vector2i(5, 5);
            Assert.That((a / b).Equals(subtractExpected));
        }

        [Test]
        public void areaTest()
        {
            Vector2i a = new Vector2i(10, 10);
            Assert.That(a.Area() == 100);
        }

        [Test]
        public void getHash()
        {
            Vector2i a = new Vector2i(10, 10);
            Assert.That(a.GetHashCode() != null);
        }

        [Test]
        public void castFromANtiveTestthTest()
        {
            Vector2i a = new Vector2i(2, 2);
            Vector2i b = new Vector2i(new Vector2i_CS(2, 2));
            Assert.That(a.Equals(b));
        }

        [Test]
        public void vectolEngth()
        {
            Vector2i a = new Vector2i(4, 3);
            Assert.That(a.Length.Equals(5));
        }

        [Test]
        public void nativeTest()
        {
            Vector2i_CS a = new Vector2i_CS(2, 2);
            Vector2i_CS b = new Vector2i(2, 2).Native();
            Assert.That(a.X.Equals(b.X) && a.Y.Equals(b.Y));
        }

        [Test]
        public void castFomrVector2f()
        {
            Vector2i a = new Vector2i(2, 2);
            Vector2i b = (Vector2i)new Vector2f(2f, 2f);
            Assert.That(a.Equals(b));
        }
    }
}
