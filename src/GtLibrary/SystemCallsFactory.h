#pragma once
#include <memory>
#include "ISystemCalls.h"
class SystemCallsFactory
{
public:
	static std::shared_ptr<ISystemCalls> GetSystemCalls();

};

