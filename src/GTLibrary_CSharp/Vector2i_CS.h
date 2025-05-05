#pragma once
#include "../GtLibrary/Vector2i.h"
public ref class Vector2i_CS
{
public:
	int X;
	int Y;
	Vector2i_CS(int x, int y) : X(x), Y(y) {}
	Vector2i_CS(Vector2i vec) : X(vec.x), Y(vec.y) {}
	static Vector2i_CS^ Create(int x, int y) {
		return gcnew Vector2i_CS(x, y);
	}
};

