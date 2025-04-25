using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets
{
    [TestFixture]
    public class DllTest
    {
        [Test]
        public void testMethod()
        {
            TestWrap testWrap = new TestWrap();
            int a = 10,
                b = 144;
            int c = a + b;
            int cnative = testWrap.Add(a, b);
            Assert.That(c == cnative);
        }
    }
}
