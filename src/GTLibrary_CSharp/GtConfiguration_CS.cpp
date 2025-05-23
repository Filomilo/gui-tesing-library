#include "GtConfiguration_CS.h"
#include "../GtLibrary/Configuration.h"
#include "Converters.h"

void GtConfiguration_CS::SetTimeout(long newTimeout) {
	GtConfiguration::GetInstance()->SetTimeout(newTimeout);
}
long GtConfiguration_CS::GetTimeout() {
	return GtConfiguration::GetInstance()->GetTimeout();
}
void GtConfiguration_CS::SetDefaultTimeout() {
	GtConfiguration::GetInstance()->SetDefaultTimeout();
}
void GtConfiguration_CS::DefaultSleep() {
	GtConfiguration::GetInstance()->DefaultSleep();
}
void GtConfiguration_CS::setActioNDelay(long time) {
	GtConfiguration::GetInstance()->setActioNDelay(time);
}
void GtConfiguration_CS::setDeafultActioNDelay()
{
	GtConfiguration::GetInstance()->setDeafultActioNDelay();
}
long GtConfiguration_CS::getActionDelay() {
	return GtConfiguration::GetInstance()->getActionDelay();
}
CS_IMAGE_COMPARER_TYPE GtConfiguration_CS::GetImageComparerType()
{
	return Converters::GtImageComparerToCsImageComparer(GtConfiguration::GetInstance()->GetImageComparerType())  ;
}
void GtConfiguration_CS::setImageCompareType(CS_IMAGE_COMPARER_TYPE type) {
  	GtConfiguration::GetInstance()->setImageCompareType(Converters::CSImageComparerToGTImageComparer(type));
}

