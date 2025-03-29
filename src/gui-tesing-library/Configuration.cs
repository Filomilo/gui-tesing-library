using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gui_tesing_library
{
    public class Configuration
    {
        private static long _ProcesAwaitTime=6000;

        public static long ProcesAwaitTime
        {
            get
            {
                return _ProcesAwaitTime;
            }
            set
            {
                _ProcesAwaitTime = value;
            }
        }
        private static int _ActionDelay = 200;

        public static int ActionDelay
        {
            get
            {
                return _ActionDelay;
            }
            set
            {
                _ActionDelay = value;
            }
        }


    }
}