#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTSystemVersion.h"

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystemVersion_GetVersionString
(JNIEnv* env, jobject obj) {
    return env->NewStringUTF("1.0.0");
}