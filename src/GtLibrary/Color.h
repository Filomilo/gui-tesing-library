#pragma once
class Color
{
public:
	unsigned char r, g, b;
	Color() : r(0), g(0), b(0) {}
	Color(int r, int g, int b) : r(r), g(g), b(b) {}
	bool Equals(Color c, int pass=0);
};

