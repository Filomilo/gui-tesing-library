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

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2f_dispose
(JNIEnv* env, jobject obj) {
	delete static_cast<Vector2f*>(Converters::getNativePtr(env, obj));
}


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2f_setup
(JNIEnv* env , jobject obj, jfloat x, jfloat y) {
    Vector2f* vec = new Vector2f();
    vec->x = x;
    vec->y = y;
    jclass cls = env->GetObjectClass(obj);

    jfieldID fid = Converters::getNativeHandleField(env, obj);

    if (fid == nullptr) {

        return;
    }

    env->SetLongField(obj, fid, reinterpret_cast<jlong>((void*)vec));
}


JNIEXPORT jfloat JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2f_getX
(JNIEnv* env, jobject obj) {
    return static_cast<Vector2f*>(Converters::getNativePtr(env, obj))->x;
}


JNIEXPORT jfloat JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2f_getY
(JNIEnv* env, jobject obj) {
    return static_cast<Vector2f*>(Converters::getNativePtr(env, obj))->y;
}
