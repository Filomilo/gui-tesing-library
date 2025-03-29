using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library.Models
{
    public class NumberedVersion
    {
        public string versionString { get; }
        public int Major { get; }
    }

    public class GTSystemVersion
    {
        private string _OsVersion;

        public string VersionString
        {
            get
            {
                return _OsVersion;
            }
        }


        public GTSystemVersion(OperatingSystem osVersion)
        {
            this._OsVersion = osVersion.VersionString;
        }

    }
}
