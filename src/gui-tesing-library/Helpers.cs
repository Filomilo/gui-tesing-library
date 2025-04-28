using System;
using System.Diagnostics;
using System.Threading;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    public static class Helpers
    {
        public static Key_CS keyToKeyCs(Key key)
        {
            return key switch
            {
                Key.RSHIFT => Key_CS.RSHIFT,
                Key.LCONTROL => Key_CS.LCONTROL,
                Key.RCONTROL => Key_CS.RCONTROL,
                Key.LSHIFT => Key_CS.LSHIFT,
                Key.NUMLOCK => Key_CS.NUMLOCK,
                Key.F24 => Key_CS.F24,
                Key.BACK => Key_CS.BACK,
                Key.F23 => Key_CS.F23,
                Key.F22 => Key_CS.F22,
                Key.F21 => Key_CS.F21,
                Key.F20 => Key_CS.F20,
                Key.F19 => Key_CS.F19,
                Key.F18 => Key_CS.F18,
                Key.F17 => Key_CS.F17,
                Key.F16 => Key_CS.F16,
                Key.F15 => Key_CS.F15,
                Key.F14 => Key_CS.F14,
                Key.F13 => Key_CS.F13,
                Key.F12 => Key_CS.F12,
                Key.F11 => Key_CS.F11,
                Key.F10 => Key_CS.F10,
                Key.F9 => Key_CS.F9,
                Key.F8 => Key_CS.F8,
                Key.F7 => Key_CS.F7,
                Key.F6 => Key_CS.F6,
            };
        }

        internal static void AwaitTrue(Func<bool> func, string mes = "")
        {
            bool state = false;
            Stopwatch sw = Stopwatch.StartNew();
            while (state == false)
            {
                if (sw.ElapsedMilliseconds > Configuration.ProcesAwaitTime)
                {
                    sw.Stop();
                    throw new TimeoutException("Did not reach state within max time ::: " + mes);
                }
                state = func();
                if (!state)
                    Thread.Sleep(100);
            }

            sw.Stop();
        }
    }
}
