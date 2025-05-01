#include "pch.h"
#include "GTProcess.h"
#include <windows.h>
#include <stdexcept>
#include "SystemCallsFactory.h"
std::string GTProcess::GetName() const {
    return "";
}

bool GTProcess::IsAlive() const {
    return SystemCallsFactory::GetSystemCalls()->IsProcesAlive(handle);
}

std::vector<std::shared_ptr<GTWindow>> GTProcess::GetWindowsOfProcess() const {
	std::vector<int> handles = SystemCallsFactory::GetSystemCalls()->FindProcessByName(this->GetName());
	std::vector<std::shared_ptr<GTWindow>> windows;
	for (int handle : handles) {
		std::shared_ptr<GTWindow> window = std::make_shared<GTWindow>(handle);
		if (window) {
			windows.push_back(window);
		}
	}
	return windows;
}

long GTProcess::GetRamUsage() const {
	SystemCallsFactory::GetSystemCalls()->GetRamUsageOfProcess(this->handle);
}

void GTProcess::Kill() {
    SystemCallsFactory::GetSystemCalls()->KillProcess(this->handle);
}
