using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using gui_tesing_library.Components;
using gui_tesing_library.Models;

namespace gui_tesing_library
{
    public class Configuration
    {
        private static long _ProcesAwaitTime = 6000;
        static  GT
        public static long ProcesAwaitTime
        {
            get { return GTC; }
            set { _ProcesAwaitTime = value; }
        }
        private static int _ActionDelay = 800;

        public static int ActionDelay
        {
            get { return _ActionDelay; }
            set { _ActionDelay = value; }
        }

        public static ImageComparerFactory.IMAGE_COMPARER_TYPE ImageComparerType { get; set; } =
            ImageComparerFactory.IMAGE_COMPARER_TYPE.HASH_COMPARER;
    }
}
