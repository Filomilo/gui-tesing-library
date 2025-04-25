#pragma once
#include "../GtLibrary/GTProcess.h"
#include <memory>
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
};

