#pragma once
#include "Configuration.h"
#include <stdexcept>
#include <chrono>
#include <thread>
#include <functional>
using namespace std::chrono;
class Helpers
{
	
public:

	static void ensureTrue(std::function<bool()> functionPointer, const std::string& mes = "");

};

