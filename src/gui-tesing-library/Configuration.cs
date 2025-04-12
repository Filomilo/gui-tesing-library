using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using gui_tesing_library.Services;

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
        private static int _ActionDelay = 800;

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


        public static ImageComparerFactory.IMAGE_COMPARER_TYPE ImageComparerType
        {
            get;
            set;
        } = ImageComparerFactory.IMAGE_COMPARER_TYPE.HASH_COMPARER;
    }



    }
