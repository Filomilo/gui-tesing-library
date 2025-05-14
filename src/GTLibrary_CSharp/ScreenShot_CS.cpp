#include "ScreenShot_CS.h"
#include "../GtLibrary/GTScreenshot.h"
#include "Vector2i_CS.h"
#include "Converters.h"
using namespace System;


int ScreenShot_CS::GetWidth() {
	return native->GetWidth();
}
int ScreenShot_CS::GetHeight() {
	return native->GetHeight();
}
double ScreenShot_CS::CompareToImage(String^ filePathToCompare) {
	return native->CompareToImage(Converters::ConvertStringToStdString(filePathToCompare));
}
Color_CS^ ScreenShot_CS::GetPixelColorAt(Vector2i_CS^ pos) {
	return Converters::ColorToColorCS(this->native->GetPixelColorAt(Converters::Vector2iCSToVector2i(pos)));
}
void ScreenShot_CS::SaveAsBitmap(String^ file) {
	this->native->SaveAsBitmap(Converters::ConvertStringToStdString(file));
}
void ScreenShot_CS::SimmilarityBetweenImagesShouldBe(String^ ImagePath, double simmilarity){
	this->native->SimmilarityBetweenImagesShouldBe(Converters::ConvertStringToStdString(ImagePath), simmilarity);
}
