using System;
using System.Diagnostics;
using System.Threading;

namespace gui_tesing_library
{
    public static class Helpers
    {


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
