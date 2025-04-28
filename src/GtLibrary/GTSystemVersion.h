#pragma once
#include <string>

class GTSystemVersion {
private:
    std::string _OsVersion;

public:
    GTSystemVersion(const std::string& osVersion);
    GTSystemVersion(const GTSystemVersion& other);

    std::string GetVersionString() const;

};


