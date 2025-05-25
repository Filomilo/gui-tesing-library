using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Tests
{
    [TestFixture()]
    public class SystemControllerTest
    {
        [TearDown]
        public void TearDown()
        {
            TestHelpers.CloseExampleGui();
        }

        [Test()]
        public void GetClipBoardContentTest()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();
            MouseController
                .Instance.SetPositionRelativeToWindow(
                    window,
                    TestHelpers.RelativePostions.TextAreaInput
                )
                .ClickLeft();
            string loreIsum = TestHelpers.GetLoremIpsumText();
            KeyboardController
                .Instance.Type(loreIsum)
                .PressKey(Key.CONTROL)
                .ClickKey(Key.KEY_A)
                .ClickKey(Key.KEY_C)
                .ReleaseKey(Key.CONTROL);
            string clipBoardContent = SystemController.Instance.GetClipBoardContent();
            Assert.That(
                clipBoardContent.Equals(loreIsum),
                $"Clip board content was not {loreIsum} but {clipBoardContent}"
            );
            Thread.Sleep(1000);
        }

        [Test()]
        public void getActiveProcessesTest()
        {
            List<IGTProcess> processes = SystemController.Instance.GetActiveProcesses().ToList();
            Assert.That(processes.Count > 0, "There should be at least one active process.");
        }

        [Test()]
        public void FindProcessByNameTest()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();

            IEnumerable<IGTProcess> process = SystemController.Instance.FindProcessByName(
                "java.exe"
            );
            Assert.That(
                process.Count() > 0,
                "There should be at least one process with the name 'java.exe'."
            );
        }

        [Test()]
        public void GetActviWindowsTest()
        {
            IEnumerable<IGTWindow> windows = SystemController.Instance.GetActiveWindows();
            Assert.That(windows.Count() > 0, "There should be at least one active window.");
            IGTWindow window = TestHelpers.OpenExampleGui();
            IEnumerable<IGTWindow> windowsAfter = SystemController.Instance.GetActiveWindows();
            Assert.That(
                windowsAfter.Count() == windows.Count() + 1,
                "There should be more active windows after opening the example GUI."
            );
        }

        [Test()]
        public void FindWindowByName()
        {
            IGTWindow window = TestHelpers.OpenExampleGui();
            IEnumerable<IGTWindow> windowFound = SystemController
                .Instance.WindowOfNameShouldExist("Hello!")
                .FindWindowByName("Hello!");
            Assert.That(
                windowFound.Count() > 0,
                "There should be at least one window with the name 'Hello!'."
            );
        }

        [Test]
        public void GetMaximiezedWIndowSize()
        {
            Vector2i maximizedWindowSize = SystemController.Instance.GetMaximizedWindowSize();
            Assert.That(
                maximizedWindowSize.x > 0 && maximizedWindowSize.y > 0,
                "Maximized window size should be greater than 0."
            );
            Assert.That(maximizedWindowSize.Equals(SystemController.Instance.MaximizedWindowSize));
        }

        [Test]
        public void GetScreenSizeTest()
        {
            Vector2i screenSize = SystemController.Instance.GetScreenSize();
            Assert.That(
                screenSize.x > 0 && screenSize.y > 0,
                "Screen size should be greater than 0."
            );
        }

        [Test]
        public void GetOSVersopn()
        {
            GTSystemVersion osVersion = SystemController.Instance.GetOsVersion();
            Assert.That(osVersion != null, "OS Version should not be null.");
            Assert.That(
                !string.IsNullOrEmpty(osVersion.VersionString),
                "OS Version string should not be empty."
            );
            Assert.That(
                osVersion.VersionString.Length > 0,
                "OS Version string should have a length greater than 0."
            );
            Assert.That(
                osVersion.VersionString.Equals(SystemController.Instance.OsVersion.VersionString)
            );
            Assert.That(
                osVersion.VersionString.Equals(
                    SystemController.Instance.GetSystemVersion().VersionString
                )
            );
        }
    }
}
