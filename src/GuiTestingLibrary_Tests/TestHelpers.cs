using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library;
using NUnit.Framework;

namespace GuiTestingLibrary_Tets
{
    class TestHelpers
    {
        public static IGTWindow OpenExampleGui()
        {
            IGTProcess gtRocess = SystemController.Instance.StartProcess(
                "java -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
            );
            Assert.That(gtRocess.IsAlive);
            IGTWindow window = SystemController
                .Instance.WindowOfNameShouldExist("Hello!")
                .FindTopWindowByName("Hello!")
                .SetWindowSize(1280, 720)
                .CenterWindow()
                .BringUpFront();
            Assert.That(window != null);
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
                window.KillProcess();
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
    }
}
