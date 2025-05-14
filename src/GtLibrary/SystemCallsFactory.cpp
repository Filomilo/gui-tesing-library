#include "pch.h"
#include "SystemCallsFactory.h"
#include "SystemCalls.h"
std::shared_ptr<ISystemCalls> SystemCallsFactory::GetSystemCalls() {
    std::shared_ptr<ISystemCalls> ptr = std::make_shared<SystemCalls>();
	return ptr;
}