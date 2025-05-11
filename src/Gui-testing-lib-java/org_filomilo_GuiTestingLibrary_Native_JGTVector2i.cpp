#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTVector2i.h"

JNIEXPORT jfloat JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_getLength
(JNIEnv*, jobject) {
    return 0.0f;
}

JNIEXPORT jboolean JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_equals
(JNIEnv*, jobject, jobject) {
    return JNI_FALSE;
}

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_toString
(JNIEnv* env, jobject) {
    return env->NewStringUTF("JGTVector2i");
}

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_getArea
(JNIEnv*, jobject) {
    return 0;
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_add
(JNIEnv*, jobject, jobject) {
    return nullptr;
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_subtract
(JNIEnv*, jobject, jobject) {
    return nullptr;
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_divide__I
(JNIEnv*, jobject, jint) {
    return nullptr;
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_divide__Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2
(JNIEnv*, jobject, jobject) {
    return nullptr;
}
