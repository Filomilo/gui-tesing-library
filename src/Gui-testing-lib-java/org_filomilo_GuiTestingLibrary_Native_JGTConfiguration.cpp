#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTConfiguration.h"
#include "../GtLibrary/Configuration.h"
#include "Converters.h"

JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_GetTimeout
(JNIEnv* env, jobject) {
    return Converters::LongToJLong(env, Configuration::GetInstance()->GetTimeout());
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetTimeout
(JNIEnv* env, jobject, jlong _jlong) {
    Configuration::GetInstance()->SetTimeout(Converters::JLongToLong(env, _jlong) );
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetDefaultTimeout
(JNIEnv*, jobject) {
    Configuration::GetInstance()->SetDefaultTimeout();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_DefaultSleep
(JNIEnv*, jobject) {
    Configuration::GetInstance()->DefaultSleep();
}


JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_GetActionDelay
(JNIEnv*, jobject) {
    return Configuration::GetInstance()->getActionDelay();
}


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetActionDelay
(JNIEnv*, jobject, jlong val) {
    return Configuration::GetInstance()->setActioNDelay(val);
}


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetDefaultActionDelay
(JNIEnv*, jobject) {
    Configuration::GetInstance()->setDeafultActioNDelay();
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_GetImageComparer
(JNIEnv* env, jobject obj) {
    return Converters::ImageCOmparertOJImageComparer(env,Configuration::GetInstance()->GetImageComparerType());
}


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetImageComparer
(JNIEnv* env, jobject, jobject _enum) {
    Configuration::GetInstance()->setImageCompareType(Converters::JIMAGECOpmaretOGtImageCOmparer(env, _enum));
}
