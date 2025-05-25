#include "pch.h"
#include "GTSystemVersion.h"

GTSystemVersion::GTSystemVersion(const std::string& osType, long major, long minor, long build)

    : _OsType(osType), major(major), minor(minor), build(build) {
};
GTSystemVersion::GTSystemVersion(const GTSystemVersion& other)
    : _OsType(other._OsType), major(other.major), minor(other.minor), build(other.build) {
};
std::string GTSystemVersion::GetVersionString() const {
	return _OsType + " " + std::to_string(major) + "." + std::to_string(minor) + " Build: " + std::to_string(build);
}
