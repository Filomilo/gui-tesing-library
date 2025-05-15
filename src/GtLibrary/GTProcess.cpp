#include "pch.h"
#include "GTProcess.h"
#include <windows.h>
#include <stdexcept>
#include "SystemCallsFactory.h"
std::wstring GTProcess::GetName() const {
    return SystemCallsFactory::GetSystemCalls()->GetProcesName(handle);
}

bool GTProcess::IsAlive() const {
	return SystemCallsFactory::GetSystemCalls()->IsProcesAlive(handle);
}

std::vector<GTWindow> GTProcess::GetWindowsOfProcess() const {
	std::vector<HWND> handles = SystemCallsFactory::GetSystemCalls()->GetWindowsOfProcess(this->handle);
	std::vector<GTWindow> windows;
	for (HWND handle : handles) {
		GTWindow window = GTWindow(handle);
	
			windows.push_back(window);
		
	}
	return windows;
}


long GTProcess::GetRamUsage() const {
return	SystemCallsFactory::GetSystemCalls()->GetRamUsageOfProcess(this->handle);
}

void GTProcess::Kill() {
    SystemCallsFactory::GetSystemCalls()->KillProcess(this->handle);
}

HANDLE GTProcess::GetHandle() {
	return this->handle;
}