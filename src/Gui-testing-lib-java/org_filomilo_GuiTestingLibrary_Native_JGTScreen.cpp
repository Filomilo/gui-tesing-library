#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTScreen.h"
#include "Converters.h"
#include "../GtLibrary/GTScreen.h"

GTScreen _GtScreeen = GTScreen();

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetSize
(JNIEnv* env, jobject obj) {
    return Converters::Vector2IToJVector2I(env, _GtScreeen.GetSize());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetMaximizedWindowSize
(JNIEnv* env, jobject obj) {
    return Converters::Vector2IToJVector2I(env, _GtScreeen.GetMaximizedWindowSize());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetScreenshot
(JNIEnv* env, jobject obj) {
    return Converters::GtScreenShotToJScreenShot(env, _GtScreeen.GetScreenshot());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetScreenshotRect
(JNIEnv* env, jobject obj, jobject x, jobject y) {
    return Converters::GtScreenShotToJScreenShot(env, _GtScreeen.GetScreenshotRect(Converters::JVector2IToVector2I(env, x), Converters::JVector2IToVector2I(env, y)));
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetPixelColorAt
(JNIEnv* env, jobject obj, jobject point) {
    return Converters::GtColorToJColor(env, _GtScreeen.GetPixelColorAt(Converters::JVector2IToVector2I(env, point)));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_PixelAtShouldBeColor
(JNIEnv* env, jobject obj, jobject point, jobject color) {
   _GtScreeen.PixelAtShouldBeColor(Converters::JVector2IToVector2I(env, point),Converters::JColorToGtColor(env, color));
}
