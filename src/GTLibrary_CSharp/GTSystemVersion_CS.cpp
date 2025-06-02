#include "GTSystemVersion_CS.h"
#include "Converters.h"

GTSystemVersion_CS::GTSystemVersion_CS(GTSystemVersion nativeVersion) {
	_osType = Converters::ConvertStdStringToString(nativeVersion.GetOsType());
	_major = nativeVersion.GetMajor();
	_minor = nativeVersion.GetMinor();
	_build = nativeVersion.GetBuild();
}
GTSystemVersion_CS::GTSystemVersion_CS(const GTSystemVersion_CS^ obj) {
	_osType = obj->_osType;
	_major = obj->_major;
	_minor = obj->_minor;
	_build = obj->_build;
}
String^ GTSystemVersion_CS::GetOsType() {
	return this->_osType;
}
long GTSystemVersion_CS::GetMajor() {
	return this->_major;
}
long GTSystemVersion_CS::GetMinor() {
	return this->_minor;
}
long GTSystemVersion_CS::GetBuild() {
	return this->_build;
}