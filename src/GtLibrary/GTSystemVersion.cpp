#include "pch.h"
#include "GTSystemVersion.h"

GTSystemVersion::GTSystemVersion(const std::string& osVersion)
    : _OsVersion(osVersion) {
}

GTSystemVersion::GTSystemVersion(const GTSystemVersion& other)
    : _OsVersion(other._OsVersion) {
}

std::string GTSystemVersion::GetVersionString() const {
    return _OsVersion;
}
