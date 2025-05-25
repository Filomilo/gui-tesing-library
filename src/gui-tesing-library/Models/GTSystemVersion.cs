using System;

namespace gui_tesing_library.Models;

public class NumberedVersion
{
    public string versionString { get; }
    public int Major { get; }
}

public class GTSystemVersion
{
    public GTSystemVersion(OperatingSystem osVersion)
    {
        VersionString = osVersion.VersionString;
    }

    public GTSystemVersion(GTSystemVersion_CS gTSystemVersion_CS)
    {
    }

    public string VersionString { get; }
}