#pragma once
#include "../GtLibrary/GTSystemVersion.h"
using namespace System;

class GTSystemVersion;

public ref class GTSystemVersion_CS
{
private:
	String^ _osType;
	long _major;
	long _minor;
	long _build;
public:
	GTSystemVersion_CS(GTSystemVersion nativeVersion);
	GTSystemVersion_CS(const GTSystemVersion_CS^ obj);
	String^ GetOsType();
	long GetMajor();
	long GetMinor();
	long GetBuild();

};

