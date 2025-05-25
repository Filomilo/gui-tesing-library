#pragma once
#include <string>

class GTSystemVersion {
private:
    std::string _OsType;

    long major;
    long minor;
	long build;
public:
    GTSystemVersion(const std::string& osType, long major,long minor, long build);
    GTSystemVersion(const GTSystemVersion& other);
	std::string GetOsType() const { return _OsType; }
	long GetMajor() const { return major; }
        
	long GetMinor() const { return minor; }
	long GetBuild() const { return build; }


    std::string GetVersionString() const;

};


