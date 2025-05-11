#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTProcess.h"

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getName
(JNIEnv* env, jobject) {
    return env->NewStringUTF("");
}

JNIEXPORT jboolean JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_isAlive
(JNIEnv*, jobject) {
    return JNI_FALSE;
}

JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getWindowsOfProcess
(JNIEnv* env, jobject) {
    return env->NewObjectArray(0, env->FindClass("java/lang/String"), nullptr);
}

JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getRamUsage
(JNIEnv*, jobject) {
    return 0;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_kill
(JNIEnv*, jobject) {
}
