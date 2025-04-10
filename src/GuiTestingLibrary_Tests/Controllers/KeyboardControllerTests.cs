using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using GuiTestingLibrary_Tets;
using NUnit.Framework;

namespace gui_tesing_library.Controllers.Tests
{
    [TestFixture()]
    public class KeyboardControllerTests
    {
        private IGTWindow window;
        private Vector2f windowNameINputPos = new Vector2f(0.25f, 0.24f);
        private Vector2f ChangeWindowTitleButtonPositon = new Vector2f(0.21f, 0.35f);

        [SetUp]
        public void setup()
        {
            window = TestHelpers.OpenExampleGui();
        }

        [TearDown]
        public void TearDown()
        {
            window.GetProcessOfWindow().kill();
            //TestHelpers.CloseExampleGui();
        }

        [Test()]
        public void PressReleaseKeyTest()
        {
            string Title = "Test_" + Guid.NewGuid().ToString();
            MouseController
                .Instance.SetPositionRelativeToWindow(window, windowNameINputPos)
                .ClickLeft();
            KeyboardController
                .Instance.Type(Title)
                .PressKey(Key.CONTROL)
                .ClickKey(Key.KEY_A)
                .ClickKey(Key.KEY_C)
                .ClickKey(Key.KEY_V)
                .ClickKey(Key.KEY_V)
                .ReleaseKey(Key.CONTROL);

            MouseController
                .Instance.SetPositionRelativeToWindow(window, ChangeWindowTitleButtonPositon)
                .ClickLeft();
            Title = Title + Title;
            Assert.That(
                window.WindowNameShouldBe(Title).GetWindowName().Equals(Title),
                $"Window title is not [[{Title}]] but [[{window.GetWindowName()}]]"
            );
        }

        [Test()]
        public void ClickKeyTest()
        {
            string Title = "0a p";
            MouseController
                .Instance.SetPositionRelativeToWindow(window, windowNameINputPos)
                .ClickLeft();

            KeyboardController
                .Instance.ClickKey(Key.KEY_0)
                .ClickKey(Key.KEY_A)
                .ClickKey(Key.SPACE)
                .ClickKey(Key.KEY_P);
            MouseController
                .Instance.SetPositionRelativeToWindow(window, ChangeWindowTitleButtonPositon)
                .ClickLeft();

            Assert.That(
                window.WindowNameShouldBe(Title).GetWindowName().Equals(Title),
                $"Window title is not [[{Title}]] but [[{window.GetWindowName()}]]"
            );
        }

        [Test()]
        public void TypeTest()
        {
            string Title = "Test_" + Guid.NewGuid().ToString();
            MouseController
                .Instance.SetPositionRelativeToWindow(window, windowNameINputPos)
                .ClickLeft();
            KeyboardController.Instance.Type(Title);
            MouseController
                .Instance.SetPositionRelativeToWindow(window, ChangeWindowTitleButtonPositon)
                .ClickLeft();

            Assert.That(
                window.WindowNameShouldBe(Title).GetWindowName().Equals(Title),
                $"Window title is not [[{Title}]] but [[{window.GetWindowName()}]]"
            );
        }
    }
}
