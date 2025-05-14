#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTMouse.h"
#include "../GtLibrary/GTMouse.h"
#include "Converters.h"

GTMouse _GTMouse = GTMouse();


JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_GetPosition
(JNIEnv* env, jobject obj) {
    return Converters::Vector2IToJVector2I(env, _GTMouse.GetPosition());
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouse
(JNIEnv* env, jobject obj, jobject pos) {
    return _GTMouse.MoveMouse(Converters::JVector2IToVector2I(env, pos));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_SetPosition
(JNIEnv* env, jobject obj, jobject pos) {
    return _GTMouse.SetPosition(Converters::JVector2IToVector2I(env, pos));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ClickLeft
(JNIEnv* env, jobject obj) {
    _GTMouse.ClickLeft();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ClickRight
(JNIEnv* env, jobject obj) {
    _GTMouse.ClickRight();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ClickMiddle
(JNIEnv* env, jobject obj) {
    _GTMouse.ClickMiddle();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PressLeft
(JNIEnv* env, jobject obj) {
    _GTMouse.PressLeft();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PressMiddle
(JNIEnv* env, jobject obj) {
    _GTMouse.PressMiddle();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PressRight
(JNIEnv* env, jobject obj) {
    _GTMouse.PressRight();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ReleaseLeft
(JNIEnv* env, jobject obj) {
    _GTMouse.ReleaseLeft();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ReleaseMiddle
(JNIEnv* env, jobject obj) {
    _GTMouse.ReleaseMiddle();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_ReleaseRight
(JNIEnv* env, jobject obj) {
    _GTMouse.ReleaseRight();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_Scroll
(JNIEnv* env, jobject obj, jint amount) {
    _GTMouse.Scroll(amount);
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_SetPositionRelativeToWindow__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
    _GTMouse.SetPositionRelativeToWindow(Converters::JWindowToGtWindow(env, window), Converters::JVector2IToVector2I(env, pos));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_SetPositionRelativeToWindow__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2f_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
    _GTMouse.SetPositionRelativeToWindow(Converters::JWindowToGtWindow(env, window), Converters::JVector2fToVector2f(env, pos));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PositionShouldBe
(JNIEnv* env, jobject obj, jobject pos, jint tolerance) {
    _GTMouse.PositionShouldBe(Converters::JVector2IToVector2I(env, pos), tolerance);
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouseTo
(JNIEnv* env, jobject obj, jobject pos) {
    _GTMouse.MoveMouseTo(Converters::JVector2IToVector2I(env, pos));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouseRelativeToWindowTo__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
    _GTMouse.MoveMouseRelativeToWindowTo(Converters::JWindowToGtWindow(env, window), Converters::JVector2IToVector2I(env, pos));

}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_MoveMouseRelativeToWindowTo__Lorg_filomilo_GuiTestingLibrary_Native_JGTWindow_2Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2f_2
(JNIEnv* env, jobject obj, jobject window, jobject pos) {
    _GTMouse.MoveMouseRelativeToWindowTo(Converters::JWindowToGtWindow(env, window), Converters::JVector2fToVector2f(env, pos));
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_GetPositionRelativeToWindow
(JNIEnv* env, jobject obj, jobject window) {
  return Converters::Vector2fToJVector2f(env, _GTMouse.GetPositionRelativeToWindow(Converters::JWindowToGtWindow(env, window)))  ;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTMouse_PositionRelativeToWindowShouldBe
(JNIEnv* env, jobject obj, jobject window, jobject pos, jfloat tolerance) {
    _GTMouse.PositionRelativeToWindowShouldBe(Converters::JWindowToGtWindow(env, window), Converters::JVector2fToVector2f(env, pos),tolerance);
}
