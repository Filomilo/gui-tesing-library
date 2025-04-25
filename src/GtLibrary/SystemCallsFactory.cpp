#include "pch.h"
#include "SystemCallsFactory.h"
#include "SystemCalls.h"
std::shared_ptr<ISystemCalls> SystemCallsFactory::GetSystemCalls() {
    return std::make_shared<SystemCalls>();
}