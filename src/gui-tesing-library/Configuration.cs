﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



    }
}
