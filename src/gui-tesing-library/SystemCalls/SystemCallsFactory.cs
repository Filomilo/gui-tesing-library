using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using gui_tesing_library.WInApi;

namespace gui_tesing_library.SystemCalls
{
    public static class SystemCallsFactory
    {
        public static ISystemCalls GetSystemCalls()
        {
            OperatingSystem os = Environment.OSVersion;
            if (os.Platform == PlatformID.Win32NT)
            {
                return new WindwosSystemCalls();
            }
            ErrorController.Throw(new NotImplementedException("This system is not yet supported"));
            return null;
        }
    }
}
