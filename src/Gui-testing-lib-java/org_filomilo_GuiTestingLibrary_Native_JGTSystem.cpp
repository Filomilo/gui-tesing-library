#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTSystem.h"

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetClipBoardContent
(JNIEnv* env, jobject obj) {
    return env->NewStringUTF("");
}
