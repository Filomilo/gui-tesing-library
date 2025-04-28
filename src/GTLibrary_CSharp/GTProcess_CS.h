#pragma once
using namespace System;
using namespace System::Collections::Generic;


#include "../GtLibrary/GTProcess.h"
#include <memory>
#include <vector>
#include <string>
#include "GTProcess_CS.h"
#include "GTWindow_CS.h"
#include "Vector2i_CS.h"
#include "GTSystemVersion_CS.h"
#include "../GtLibrary/GTSystem.h"

ref class GTWindow_CS;

public ref class GTProcess_CS
{
private: 
	GTProcess* _nativeProcess;
public:
	GTProcess_CS(GTProcess* nativeProcess) : _nativeProcess(nativeProcess) {}
	GTProcess_CS(std::shared_ptr<GTProcess> nativeProcess) : _nativeProcess(nativeProcess.get()) {}
	~GTProcess_CS() {
		delete _nativeProcess;
	}
	!GTProcess_CS() {
		delete _nativeProcess;
	}

	void kill();
	long GetRamUsage();
	bool IsAlive();
	String^ GetName();
	List<GTWindow_CS^>^  GetWindowsOfProcess();
};

