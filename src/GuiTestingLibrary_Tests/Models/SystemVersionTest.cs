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
    public class SystemVersionTest
    {
        [Test]
        public void csSystemVerion()
        {
            GTSystemVersion gtSystemVersion = new GTSystemVersion(Environment.OSVersion);
            Assert.That(gtSystemVersion.VersionString, Is.Not.Null.Or.Empty);
        }
    }
}
