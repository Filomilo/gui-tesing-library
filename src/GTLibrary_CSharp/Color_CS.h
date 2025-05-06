#pragma once
public ref class Color_CS
{
public:
	int r;
	int g;
	int b;
	 Color_CS(int r, int g, int b) : r(r), g(g), b(b) {}
	 static Color_CS^ create(int r, int g, int b) {
		 return gcnew Color_CS(r, g, b);
	 }
};

