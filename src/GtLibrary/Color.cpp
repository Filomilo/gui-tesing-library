#include "pch.h"
#include "Color.h"

bool Color::Equals(Color c, int pass) {
	return this->r - c.r<=pass && this->g - c.g<=pass && this->b - c.b<=pass;
}