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

std::vector<std::shared_ptr<GTWindow>> GTProcess::GetWindowsOfProcess() const {
	std::vector<HWND> handles = SystemCallsFactory::GetSystemCalls()->GetWindowsOfProcess(this->handle);
	std::vector<std::shared_ptr<GTWindow>> windows;
	for (HWND handle : handles) {
		std::shared_ptr<GTWindow> window = std::make_shared<GTWindow>(handle);
		if (window) {
			windows.push_back(window);
		}
	}
	return windows;
}


long GTProcess::GetRamUsage() const {
return	SystemCallsFactory::GetSystemCalls()->GetRamUsageOfProcess(this->handle);
}

void GTProcess::Kill() {
    SystemCallsFactory::GetSystemCalls()->KillProcess(this->handle);
}
