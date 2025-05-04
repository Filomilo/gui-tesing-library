#pragma once
#include <Windows.h>
class Casters
{
public:
	static HANDLE intToHadnle(int val)
	{
		HANDLE h = reinterpret_cast<HANDLE>(static_cast<uintptr_t>(val));
		return h;
	}
	static HWND intToHWND(int val)
	{
		HWND hWnd = reinterpret_cast<HWND>(static_cast<uintptr_t>(val));	
		return hWnd;
	}

	static int HandleToInt(HANDLE h)
	{
		return reinterpret_cast<intptr_t>(h); ;
	}
};

