using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Models;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets.Models
{
    [TestFixture]
    public class Vector2fTest
    {
        [Test]
        public void subtractTest()
        {
            Vector2f a = new Vector2f(10, 10);
            Vector2f b = new Vector2f(2, 2);
            Vector2f subtractExpected = new Vector2f(8, 8);
            Assert.That((a - b).Equals(subtractExpected));
        }
        [Test]
        public void addTest()
        {
            Vector2f a = new Vector2f(10, 10);
            Vector2f b = new Vector2f(2, 2);
            Vector2f addtExpected = new Vector2f(12, 12);
            Assert.That((a + b).Equals(addtExpected));
        }
        [Test]
        public void toStringTest()
        {
            Vector2f a = new Vector2f(2, 2);
            Assert.That(a.ToString().Equals($"[{a.x};{a.y}]"));
        }

        [Test]
        public void equlafiales()
        {
            Vector2f a = new Vector2f(2, 2);
            Assert.That(!a.Equals(new object()));
            Assert.That(!a.Equals(null));
            Assert.That(a.Equals(a));
        }

        [Test]
        public void divisinTest()
        {
            Vector2f a = new Vector2f(10, 10);
            Vector2f b = new Vector2f(2, 2);
            Vector2f subtractExpected = new Vector2f(5, 5);
            Assert.That((a / b).Equals(subtractExpected));
        }
        [Test]
        public void divisinbyIntTest()
        {
            Vector2f a = new Vector2f(10, 10);
            int b = 2;
            Vector2f subtractExpected = new Vector2f(5, 5);
            Assert.That((a / b).Equals(subtractExpected));
        }

     

        [Test]
        public void getHash()
        {
            Vector2f a = new Vector2f(10, 10);
            Assert.That(a.GetHashCode() != null);
        }
        [Test]
        public void castFromANtiveTestthTest()
        {
            Vector2f a = new Vector2f(2, 2);
            Vector2f b = new Vector2f(new Vector2f_CS(2, 2));
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
            Vector2f a = new Vector2f(2, 2);
            Vector2f b = (Vector2f)new Vector2i(2, 2);
            Assert.That(a.Equals(b));
        }

        [Test]
        public void areaTest()
        {
            Vector2f a = new Vector2f(2, 2);
            Assert.That(a.Area().Equals(4));
        }


        [Test]
        public void distnaceFrom()
        {
            Vector2f a = new Vector2f(0,0);
              Vector2f b = new Vector2f(4,3);
              float expteced_distance = 5;
            Assert.That(a.DistanceFrom(b).Equals(expteced_distance), $"expecte distacne form to be {expteced_distance} but is {a.DistanceFrom(b)}");
        }
    }
}
