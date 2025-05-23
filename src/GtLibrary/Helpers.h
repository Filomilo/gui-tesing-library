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

	static void ensureTrue(std::function<bool()> functionPointer)
	{
		long timeout = GtConfiguration::GetInstance()->GetTimeout();
		auto  startTime = high_resolution_clock::now();
		while (true)
		{
			if (functionPointer())
			{
				break;
			}
			else
			{
				auto  stopTime = high_resolution_clock::now();

				auto duration = duration_cast<microseconds>(stopTime -  startTime );
				

				if (duration.count() > timeout)
				{
					throw std::runtime_error("Timeout");
				}
			}
			std::chrono::milliseconds timespan(10000); 

			std::this_thread::sleep_for(timespan);
		}
	}

};

