#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTConfiguration.h"
#include "../GtLibrary/Configuration.h"
#include "Converters.h"

JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_GetTimeout
(JNIEnv* env, jobject) {
    return Converters::LongToJLong(env, GtConfiguration::GetInstance()->GetTimeout());
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetTimeout
(JNIEnv* env, jobject, jlong _jlong) {
    GtConfiguration::GetInstance()->SetTimeout(Converters::JLongToLong(env, _jlong) );
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetDefaultTimeout
(JNIEnv*, jobject) {
    GtConfiguration::GetInstance()->SetDefaultTimeout();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_DefaultSleep
(JNIEnv*, jobject) {
    GtConfiguration::GetInstance()->DefaultSleep();
}


JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_GetActionDelay
(JNIEnv*, jobject) {
    return GtConfiguration::GetInstance()->getActionDelay();
}


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetActionDelay
(JNIEnv*, jobject, jlong val) {
    return GtConfiguration::GetInstance()->setActioNDelay(val);
}


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetDefaultActionDelay
(JNIEnv*, jobject) {
    GtConfiguration::GetInstance()->setDeafultActioNDelay();
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_GetImageComparer
(JNIEnv* env, jobject obj) {
    return Converters::ImageCOmparertOJImageComparer(env, GtConfiguration::GetInstance()->GetImageComparerType());
}


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetImageComparer
(JNIEnv* env, jobject, jobject _enum) {
    GtConfiguration::GetInstance()->setImageCompareType(Converters::JIMAGECOpmaretOGtImageCOmparer(env, _enum));
}
