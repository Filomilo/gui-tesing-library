using System.Diagnostics;
using gui_tesing_library;
using gui_tesing_library.Controllers;
using gui_tesing_library.Models;
using LoremNET;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets;

internal class TestHelpers
{
    private const long Timeout = 2000;

    public static string JavaExectutionCommand =
        "java -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar";

    private static readonly string ImageReferanceLocation =
        Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
        + "\\ScreenShotReferances\\";

    public static IGTWindow OpenExampleGui()
    {
        var prevActionDleay = gui_tesing_library.Configuration.ActionDelay;
        gui_tesing_library.Configuration.ActionDelay = 10;
        var gtRocess = SystemController.Instance.StartProcess(JavaExectutionCommand);
        Assert.That(gtRocess.IsAlive);
        var window = SystemController
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
            var window = SystemController
                .Instance.WindowOfNameShouldExist("Hello!")
                .FindTopWindowByName("Hello!");

            var gtRocess = window.GetProcessOfWindow();
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

    public static void EnsureTrue(Func<bool> func, long timeout = Timeout)
    {
        if (Debugger.IsAttached)
            timeout *= 100;

        var state = false;
        var stopwatch = Stopwatch.StartNew();
        while (true)
        {
            state = func();
            if (state)
                break;
            Thread.Sleep(100);
            if (stopwatch.ElapsedMilliseconds > timeout)
                throw new TimeoutException($"Ensure true timouet {timeout}");
        }
    }

    public static string GetLoremIpsumText()
    {
        return Lorem.Paragraph(10, 20);
    }

    internal static class RelativePostions
    {
        public static Vector2f windowNameINputPos = new(0.25f, 0.24f);
        public static Vector2f ChangeWindowTitleButtonPositon = new(0.21f, 0.35f);
        public static Vector2f TextAreaInput = new(0.21f, 0.55f);
        public static Vector2f ColorSwitcherColorTest = new(0.21f, 0.66f);
        public static Vector2f ColorSwitcherGreenButton = new(0.21f, 0.9f);

        public static Vector2f ColorSwitcherBlackButton =
            ColorSwitcherGreenButton + new Vector2f(0, -0.06f);

        public static Vector2f ColorSwitcherWhiteButton =
            ColorSwitcherBlackButton + new Vector2f(0, -0.06f);

        public static Vector2f SliderColorCheckPostion = new(0.355f, 0.10f);
        public static Vector2f RedSliderStartPostion = new(0.355f, 0.19f);
        public static Vector2f RedSliderEndPostion = new(0.652f, 0.19f);
        public static Vector2f GreenSliderStartPostion = new(0.355f, 0.26f);
        public static Vector2f GreenSliderEndPostion = new(0.652f, 0.26f);
        public static Vector2f BlueSliderStartPostion = new(0.355f, 0.33f);
        public static Vector2f BlueSliderEndPostion = new(0.652f, 0.33f);

        public static float ColorSliderLength = BlueSliderEndPostion.x - BlueSliderStartPostion.x;

        public static Vector2f CanvasPostion = new(0.66f, 0.086f);
        public static Vector2f CanvasSize = new(0.30f, 0.27f);

        public static Vector2f ScrollTestPosition = new(0.8f, 0.92f);

        public static Vector2f ScrollColorTestPosition = new(0.8f, 0.75f);
    }

    internal static class InageReferance
    {
        internal static readonly string BlackSquare = ImageReferanceLocation + "BlackSquare.bmp";

        public static string EntryWindow720p = ImageReferanceLocation + "EntryWindow_720p.bmp";

        public static string EntryWindow720p100px =
            ImageReferanceLocation + "EntryWindow720p100px.bmp";

        public static string DrawnCanvas = ImageReferanceLocation + "drawncanvas.bmp";
    }
}
