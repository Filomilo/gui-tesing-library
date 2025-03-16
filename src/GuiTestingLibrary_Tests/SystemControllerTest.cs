using gui_tesing_library;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets
{
    public class SystemControllerTest
    {
        [Test]
        public void Test_GetOSVersion()
        {
           OperatingSystem os= SystemController.Instance.GetOSVersion();
            Assert.That("Win32NT"==os.Platform.ToString());
            Assert.That(10==os.Version.Major);
        }
    }
}