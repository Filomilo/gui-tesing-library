#include "pch.h"
#include "GTProcess.h"
std::string GTProcess::GetName() const {
    return "";
}

bool GTProcess::IsAlive() const {
    return false;
}

std::vector<std::shared_ptr<GTWindow>> GTProcess::GetWindowsOfProcess() const {
    return {};
}

long GTProcess::GetRamUsage() const {
    return 0;
}

void GTProcess::Kill() {
}
