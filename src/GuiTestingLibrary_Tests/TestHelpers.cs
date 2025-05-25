using System.Diagnostics;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using LoremNET;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets
{
    class TestHelpers
    {
        public static String JavaExectutionCommand =
            "java -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar";

        public static IGTWindow OpenExampleGui()
        {
            int prevActionDleay = gui_tesing_library.Configuration.ActionDelay;
            gui_tesing_library.Configuration.ActionDelay = 10;
            IGTProcess gtRocess = SystemController.Instance.StartProcess(JavaExectutionCommand);
            Assert.That(gtRocess.IsAlive);
            IGTWindow window = SystemController
                .Instance.WindowOfNameShouldExist("Hello!")
                .FindTopWindowByName("Hello!")
                .SetWindowSize(1280, 720)
                .CenterWindow()
                .BringUpFront()
                .SizeShouldBe(new Vector2i(1280, 720));

            Assert.That(window != null);
            gui_tesing_library.Configuration.ActionDelay = prevActionDleay;
            return window;
        }

        public static void CloseExampleGui()
        {
            if (SystemController.Instance.FindTopWindowByName("Hello!") == null)
                return;
            try
            {
                IGTWindow window = SystemController
                    .Instance.WindowOfNameShouldExist("Hello!")
                    .FindTopWindowByName("Hello!");

                IGTProcess gtRocess = window.GetProcessOfWindow();
                Assert.DoesNotThrow(() =>
                {
                    gtRocess.kill();
                });
                window.Close();
                window.KillProcess().ShouldWindowExist(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //Assert.That(window.DoesExist == false);
            //Assert.Throws<ArgumentException>(() =>
            //{
            //    SystemController.Instance.FindTopWindowByName("Hello!");
            //});
        }

        private const long Timeout = 2000;

        public static void EnsureTrue(Func<bool> func, long timeout = Timeout)
        {
            if (Debugger.IsAttached)
            {
                timeout *= 100;
            }

            bool state = false;
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                state = func();
                if (state == true)
                    break;
                Thread.Sleep(100);
                if (stopwatch.ElapsedMilliseconds > timeout)
                    throw new TimeoutException($"Ensure true timouet {timeout}");
            }
        }

        internal static class RelativePostions
        {
            public static Vector2f windowNameINputPos = new Vector2f(0.25f, 0.24f);
            public static Vector2f ChangeWindowTitleButtonPositon = new Vector2f(0.21f, 0.35f);
            public static Vector2f TextAreaInput = new Vector2f(0.21f, 0.55f);
            public static Vector2f ColorSwitcherColorTest = new Vector2f(0.21f, 0.66f);
            public static Vector2f ColorSwitcherGreenButton = new Vector2f(0.21f, 0.9f);
            public static Vector2f ColorSwitcherBlackButton =
                ColorSwitcherGreenButton + new Vector2f(0, -0.06f);
            public static Vector2f ColorSwitcherWhiteButton =
                ColorSwitcherBlackButton + new Vector2f(0, -0.06f);

            public static Vector2f SliderColorCheckPostion = new Vector2f(0.355f, 0.10f);
            public static Vector2f RedSliderStartPostion = new Vector2f(0.355f, 0.19f);
            public static Vector2f RedSliderEndPostion = new Vector2f(0.652f, 0.19f);
            public static Vector2f GreenSliderStartPostion = new Vector2f(0.355f, 0.26f);
            public static Vector2f GreenSliderEndPostion = new Vector2f(0.652f, 0.26f);
            public static Vector2f BlueSliderStartPostion = new Vector2f(0.355f, 0.33f);
            public static Vector2f BlueSliderEndPostion = new Vector2f(0.652f, 0.33f);
            public static float ColorSliderLength =
                BlueSliderEndPostion.x - BlueSliderStartPostion.x;
            public static Vector2f CanvasPostion = new Vector2f(0.66f, 0.086f);
            public static Vector2f CanvasSize = new Vector2f(0.30f, 0.27f);

            public static Vector2f ScrollTestPosition = new Vector2f(0.8f, 0.92f);

            public static Vector2f ScrollColorTestPosition = new Vector2f(0.8f, 0.75f);
        }

        private static string ImageReferanceLocation =
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
            + "\\ScreenShotReferances\\";

        internal static class InageReferance
        {
            internal static readonly string BlackSquare =
                ImageReferanceLocation + "BlackSquare.bmp";
            public static string EntryWindow720p = ImageReferanceLocation + "EntryWindow_720p.bmp";
            public static string EntryWindow720p100px =
                ImageReferanceLocation + "EntryWindow720p100px.bmp";
            public static string DrawnCanvas = ImageReferanceLocation + "drawncanvas.bmp";
        }

        public static string GetLoremIpsumText()
        {
            return Lorem.Paragraph(10, 20);
        }
    }
}
