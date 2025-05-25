using System;

namespace gui_tesing_library.Models;

public class GTSystemVersion
{
    private string _OsType;
    private long _Minor;
    private long _Major;
    private long _Build;

    public GTSystemVersion(GTSystemVersion_CS gTSystemVersion_CS)
    {
        _OsType = gTSystemVersion_CS.GetOsType();
        _Minor = gTSystemVersion_CS.GetMinor();
        _Major = gTSystemVersion_CS.GetMajor();
        _Build = gTSystemVersion_CS.GetBuild();
    }

    public GTSystemVersion(OperatingSystem oSVersion)
    {
        this._OsType = oSVersion.Platform.ToString();
        this._Major = oSVersion.Version.Major;
        this._Minor = oSVersion.Version.Minor;
        this._Build = oSVersion.Version.Build;
    }

    public string VersionString
    {
        get { return $"{_OsType} {_Major}.{_Minor} Build: {_Build}"; }
    }
}
