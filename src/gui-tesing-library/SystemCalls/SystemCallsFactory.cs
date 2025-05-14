using System;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;

namespace gui_tesing_library.SystemCalls
{
    public static class SystemCallsFactory
    {
        public static ISystemCalls GetSystemCalls()
        {
            OperatingSystem os = Environment.OSVersion;
            if (os.Platform == PlatformID.Win32NT)
            {
                return new WindowsSystemCalls();
            }
            ErrorController.Throw(new NotImplementedException("This system is not yet supported"));
            return null;
        }
    }
}
