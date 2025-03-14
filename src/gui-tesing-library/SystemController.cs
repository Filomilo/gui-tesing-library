using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library
{
     public class SystemController
    {
        private static readonly SystemController _instance = new SystemController();
        private SystemController() { }
        public static SystemController Instance => _instance;

        public OperatingSystem GetOSVersion()
        {
            return Environment.OSVersion;
        }
    }
}
