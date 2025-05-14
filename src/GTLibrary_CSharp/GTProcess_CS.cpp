#include "GTProcess_CS.h"
#include "Converters.h"
using namespace System::Collections::Generic;


using namespace System;


void GTProcess_CS::kill() {
	this->_nativeProcess->Kill();
}
long  GTProcess_CS::GetRamUsage() {
	return this->_nativeProcess->GetRamUsage();
}
bool  GTProcess_CS::IsAlive() {
	return this->_nativeProcess->IsAlive();
}
String^ GTProcess_CS::GetName() {
	return Converters::ConvertWStdStringToString(this->_nativeProcess->GetName()) ;
}

List<GTWindow_CS^>^ GTProcess_CS::GetWindowsOfProcess() {
	//std::vector<int> windows = this->_nativeProcess->GetWindowsOfProcess();
	throw new std::exception("not implented");
}
