#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTConfiguration.h"


JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_GetTimeout
(JNIEnv*, jobject) {
    return 0;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetTimeout
(JNIEnv*, jobject, jlong) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_SetDefaultTimeout
(JNIEnv*, jobject) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTConfiguration_DefaultSleep
(JNIEnv*, jobject) {
}