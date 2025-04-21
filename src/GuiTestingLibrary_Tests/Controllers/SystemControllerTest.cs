using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Tests
{
    [TestFixture()]
    public class SystemControllerTest
    {
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

            TestHelpers.CloseExampleGui();
        }
    }
}
