#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTVector2i.h"
#include "Converters.h"

JNIEXPORT jfloat JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_getLength
(JNIEnv* env, jobject obj) {
    return Converters::JVector2IToVector2I(env, obj).Length();
}

JNIEXPORT jboolean JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_equals
(JNIEnv* env, jobject obj1, jobject obj2) {
    return Converters::JVector2IToVector2I(env, obj1) == Converters::JVector2IToVector2I(env, obj2) ? JNI_TRUE : JNI_FALSE;
}

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_toString
(JNIEnv* env, jobject obj) {
    Vector2i vec = Converters::JVector2IToVector2I(env, obj);
    std::string str = "JGTVector2i(" + std::to_string(vec.x) + ", " + std::to_string(vec.y) + ")";
    return Converters::StringToJString(env, str);
}


JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_getArea
(JNIEnv* env, jobject obj) {
    Vector2i vec = Converters::JVector2IToVector2I(env, obj);
    return vec.Area();
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_add
(JNIEnv* env, jobject obj1, jobject obj2) {
    Vector2i result = Converters::JVector2IToVector2I(env, obj1) + Converters::JVector2IToVector2I(env, obj2);
    return Converters::Vector2IToJVector2I (env, result);
}


JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_subtract
(JNIEnv* env, jobject obj1, jobject obj2) {
    Vector2i result = Converters::JVector2IToVector2I(env, obj1) - Converters::JVector2IToVector2I(env, obj2);
    return Converters::Vector2IToJVector2I(env, result);
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_divide__I
(JNIEnv* env, jobject obj, jint scalar) {
    Vector2i vec = Converters::JVector2IToVector2I(env, obj);
    Vector2i result(vec.x / scalar, vec.y / scalar);
    return Converters::Vector2IToJVector2I(env, result);
}


JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_divide__Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2
(JNIEnv* env, jobject obj1, jobject obj2) {
    Vector2i v1 = Converters::JVector2IToVector2I(env, obj1);
    Vector2i v2 = Converters::JVector2IToVector2I(env, obj2);
    Vector2i result(v1.x / v2.x, v1.y / v2.y);
    return Converters::Vector2IToJVector2I(env, result);
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_dispose
(JNIEnv* env, jobject obj) {
	delete static_cast<Vector2i*>(Converters::getNativePtr(env, obj));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_setup
(JNIEnv* env, jobject obj, jint x, jint y) {
    Vector2i* vec = new Vector2i();
    vec->x = x;
    vec->y = y;
    jclass cls = env->GetObjectClass(obj);

    jfieldID fid =Converters::getNativeHandleField(env,obj);

    if (fid == nullptr) {

        return;
    }

    env->SetLongField(obj, fid, reinterpret_cast<jlong>((void*)vec));
}


JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_getX
(JNIEnv* env, jobject obj) {
    return Converters::JVector2IToVector2I(env, obj).x;
}
JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTVector2i_gety
(JNIEnv* env, jobject obj) {
    return Converters::JVector2IToVector2I(env, obj).y;
}