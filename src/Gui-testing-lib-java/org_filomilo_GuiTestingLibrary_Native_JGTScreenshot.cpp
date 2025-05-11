#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTScreenshot.h"

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_GetWidth
(JNIEnv*, jobject) {
    return 0;
}

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_GetHeight
(JNIEnv*, jobject) {
    return 0;
}

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_GetPixelColorAt
(JNIEnv* env, jobject, jint, jint) {
    return env->NewStringUTF("");
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_SaveAsBitmap
(JNIEnv*, jobject, jstring) {
}

JNIEXPORT jdouble JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_CompareToImage
(JNIEnv*, jobject, jstring) {
    return 0.0;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_SimmilarityBetweenImagesShouldBe
(JNIEnv*, jobject, jstring, jdouble) {
}
