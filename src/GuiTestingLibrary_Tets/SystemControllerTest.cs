using gui_tesing_library;

namespace GuiTestingLibrary_Tets
{
    public class SystemControllerTest
    {
        [Fact]
        public void Test_GetOSVersion()
        {
           OperatingSystem os= SystemController.Instance.GetOSVersion();
            Assert.Equal("Win32NT", os.Platform.ToString());
            Assert.Equal(10, os.Version.Major);
        }
    }
}