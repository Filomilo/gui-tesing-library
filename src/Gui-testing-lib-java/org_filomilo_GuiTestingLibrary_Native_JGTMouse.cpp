#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTMouse.h"

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_GetPosition
(JNIEnv* env, jobject obj) {
    return nullptr;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouse
(JNIEnv* env, jobject obj, jobject pos) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_SetPosition
(JNIEnv* env, jobject obj, jobject pos) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ClickLeft
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ClickRight
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ClickMiddle
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PressLeft
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PressMiddle
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PressRight
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ReleaseLeft
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ReleaseMiddle
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ReleaseRight
(JNIEnv* env, jobject obj) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_Scroll
(JNIEnv* env, jobject obj, jint amount) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_SetPositionRelativeToWindow__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_SetPositionRelativeToWindow__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2f_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PositionShouldBe
(JNIEnv* env, jobject obj, jobject pos, jint tolerance) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouseTo
(JNIEnv* env, jobject obj, jobject pos) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouseRelativeToWindowTo__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouseRelativeToWindowTo__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2f_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_GetPositionRelativeToWindow
(JNIEnv* env, jobject obj, jobject window) {
    return nullptr;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PositionRelativeToWindowShouldBe
(JNIEnv* env, jobject obj, jobject window, jobject pos, jfloat tolerance) {
}
