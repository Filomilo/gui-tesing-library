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