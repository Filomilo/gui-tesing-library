#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTVector2f.h"
#include "Converters.h"

JNIEXPORT jfloat JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2f_length
(JNIEnv* env, jobject obj) {
    return Converters::JVector2fToVector2f(env, obj).Length();
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2f_subtract
(JNIEnv* env, jobject obj1, jobject obj2) {
    return Converters::Vector2fToJVector2f(env, Converters::JVector2fToVector2f(env, obj1) - Converters::JVector2fToVector2f(env, obj2));
}
