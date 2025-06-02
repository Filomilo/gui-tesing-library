using System;

namespace gui_tesing_library.Models;

public class GTSystemVersion
{
    private readonly long _Build;
    private readonly long _Major;
    private readonly long _Minor;
    private readonly string _OsType;

    public GTSystemVersion(GTSystemVersion_CS gTSystemVersion_CS)
    {
        _OsType = gTSystemVersion_CS.GetOsType();
        _Minor = gTSystemVersion_CS.GetMinor();
        _Major = gTSystemVersion_CS.GetMajor();
        _Build = gTSystemVersion_CS.GetBuild();
    }

    public GTSystemVersion(OperatingSystem oSVersion)
    {
        _OsType = oSVersion.Platform.ToString();
        _Major = oSVersion.Version.Major;
        _Minor = oSVersion.Version.Minor;
        _Build = oSVersion.Version.Build;
    }

    public string VersionString => $"{_OsType} {_Major}.{_Minor} Build: {_Build}";
}
