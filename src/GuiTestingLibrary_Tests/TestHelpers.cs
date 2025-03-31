﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library;

namespace GuiTestingLibrary_Tets
{
    class TestHelpers
    {
        public static IGTWindow OpenExampleGui()
        {
           IGTProcess gtRocess = SystemController.Instance.StartProcess(
                "\"C:\\Program Files\\Common Files\\Oracle\\Java\\javapath\\java\" -jar ..\\..\\..\\..\\JavaFx_Demo\\target\\JavaFx_Demo-1.0-SNAPSHOT-shaded.jar"
            );
            Assert.That(gtRocess.IsAlive);
            IGTWindow window = SystemController.Instance.WindowOfNameShouldExist("Hello!").FindTopWindowByName("Hello!");
            Assert.That(window != null);
            return window;
        }

        public static void CloseExampleGui()
        {
            IGTWindow window= SystemController.Instance.WindowOfNameShouldExist("Hello!").FindTopWindowByName("Hello!");
            IGTProcess gtRocess = window.GetProcessOfWindow();
            Assert.DoesNotThrow(() =>
            {
                gtRocess.kill();
            });
            window.Close();
            window.KillProcess();
            window.ShouldWindowExist(false);
            Assert.That(window.DoesExist == false);
            Assert.Throws<ArgumentException>(() =>
            {
                SystemController.Instance.FindTopWindowByName("Hello!");
            });
        }
    }
}
