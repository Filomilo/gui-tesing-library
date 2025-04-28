#include "GTProcess_CS.h"
using namespace System::Collections::Generic;


using namespace System;


void GTProcess_CS::kill() {

}
long  GTProcess_CS::GetRamUsage() {
	return -1;
}
bool  GTProcess_CS::IsAlive() {
	return false;
}
String^ GTProcess_CS::GetName() {
	return "";
}

List<GTWindow_CS^>^ GTProcess_CS::GetWindowsOfProcess() {
	return nullptr;
}
