#include "GtConfiguration_CS.h"
#include "../GtLibrary/Configuration.h"


void GtConfiguration_CS::SetTimeout(long newTimeout) {
	Configuration::GetInstance()->SetTimeout(newTimeout);
}
long GtConfiguration_CS::GetTimeout() {
	return GtConfiguration_CS::GetInstance()->GetTimeout();
}
void GtConfiguration_CS::SetDefaultTimeout() {
	GtConfiguration_CS
}
void GtConfiguration_CS::DefaultSleep() {
	GtConfiguration_CS::GetInstance()->DefaultSleep();
}
void GtConfiguration_CS::setActioNDelay(long time) {
	GtConfiguration_CS::GetInstance()->setActioNDelay(time);
}
void GtConfiguration_CS::setDeafultActioNDelay()
{
	GtConfiguration_CS::GetInstance()->setDeafultActioNDelay();
}
long GtConfiguration_CS::getActionDelay() {
	return GtConfiguration_CS::GetInstance()->getActionDelay();
}
IMMAGE_COMPARPER_TYPE GtConfiguration_CS::GetImageComparerType()
{
	return GtConfiguration_CS::GetInstance()->GetImageComparerType();
}
void setImageCompareType(IMMAGE_COMPARPER_TYPE type) {
	Configuration::GetInstance()->setImageCompareType(type);
}