#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTWindow.h"
#include "Converters.h"

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetPosition
(JNIEnv* env, jobject obj) {
    return Converters::Vector2IToJVector2I(env, Converters::JWindowToGtWindow(env, obj).GetPosition()) ;
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetSize
(JNIEnv* env, jobject obj) {
    return Converters::Vector2IToJVector2I(env, Converters::JWindowToGtWindow(env, obj).GetSize());
}

JNIEXPORT jboolean JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_DoesExist
(JNIEnv* env, jobject obj) {
    return Converters::JWindowToGtWindow(env, obj).DoesExist();
}

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetName
(JNIEnv* env, jobject obj) {
    return Converters::WStringToJstring(env, Converters::JWindowToGtWindow(env, obj).GetName()) ;
}

JNIEXPORT jboolean JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_IsMinimized
(JNIEnv* env, jobject obj) {
    return Converters::JWindowToGtWindow(env, obj).IsMinimized();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_MoveWindow
(JNIEnv* env, jobject obj, jobject vec) {
    Converters::JWindowToGtWindow(env, obj).MoveWindow(Converters::JVector2IToVector2I(env, vec));
;}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_Minimize
(JNIEnv* env, jobject obj) {
    Converters::JWindowToGtWindow(env, obj).Minimize();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_Maximize
(JNIEnv* env, jobject obj) {
    Converters::JWindowToGtWindow(env, obj).Maximize();
}



JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_Close
(JNIEnv* env, jobject obj) {
    Converters::JWindowToGtWindow(env, obj).Close();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_SetWindowSize
(JNIEnv* env, jobject obj, jint width, jint height) {
    Converters::JWindowToGtWindow(env, obj).SetWindowSize( width, height );
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_SetPosition
(JNIEnv* env, jobject obj, jint x, jint y) {
    Converters::JWindowToGtWindow(env, obj).SetPosition(x, y );
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_BringUpFront
(JNIEnv* env, jobject obj) {
    Converters::JWindowToGtWindow(env, obj).BringUpFront();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_SizeShouldBe
(JNIEnv* env, jobject obj, jobject vec) {
    Converters::JWindowToGtWindow(env, obj).SizeShouldBe(Converters::JVector2IToVector2I(env, vec));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_ShouldWindowExist
(JNIEnv* env, jobject obj, jboolean shouldExist) {
    Converters::JWindowToGtWindow(env, obj).ShouldWindowExist(shouldExist);
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_KillProcess
(JNIEnv* env, jobject obj) {
    Converters::JWindowToGtWindow(env, obj).KillProcess();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_ShouldBeMinimized
(JNIEnv* env, jobject obj, jboolean minimized) {
    Converters::JWindowToGtWindow(env, obj).ShouldBeMinimized(minimized);
}

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetWindowName
(JNIEnv* env, jobject obj) {
    return Converters::WStringToJstring(env, Converters::JWindowToGtWindow(env, obj).GetWindowName());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetWindowContentPosition
(JNIEnv* env, jobject obj) {
    return Converters::Vector2IToJVector2I(env, Converters::JWindowToGtWindow(env, obj).GetWindowContentPosition());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetWindowContentSize
(JNIEnv* env, jobject obj) {
    return Converters::Vector2IToJVector2I(env, Converters::JWindowToGtWindow(env, obj).GetWindowContentSize());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetContentPixelColorAt__Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2
(JNIEnv* env, jobject obj, jobject vec) {
    return Converters::GtColorToJColor(env, Converters::JWindowToGtWindow(env, obj).GetContentPixelColorAt(Converters::JVector2IToVector2I(env, vec)));
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetContentPixelColorAt__Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2f_2
(JNIEnv* env, jobject obj, jobject vec) {
    return Converters::GtColorToJColor(env, Converters::JWindowToGtWindow(env, obj).GetContentPixelColorAt(Converters::JVector2fToVector2f(env, vec)));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_ContentPixelAtShouldBeColor__Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2i_2Lorg_filomilo_GuiTestingLibrary_Native_JGTColor_2
(JNIEnv* env, jobject obj, jobject vec, jobject color) {
    Converters::JWindowToGtWindow(env, obj).ContentPixelAtShouldBeColor(
        Converters::JVector2IToVector2I(env, vec),
        Converters::JColorToGtColor(env, color)
    );
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_CenterWindow
(JNIEnv* env, jobject obj) {
    Converters::JWindowToGtWindow(env, obj).CenterWindow();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_WindowNameShouldBe
(JNIEnv* env, jobject obj, jstring name) {
    Converters::JWindowToGtWindow(env, obj).WindowNameShouldBe(Converters::JStringToWString (env, name));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_ContentPixelAtShouldBeColor__Lorg_filomilo_GuiTestingLibrary_Native_JGTVector2f_2Lorg_filomilo_GuiTestingLibrary_Native_JGTColor_2I
(JNIEnv* env, jobject obj, jobject vec, jobject color, jint tolerance) {
    Converters::JWindowToGtWindow(env, obj).ContentPixelAtShouldBeColor(
        Converters::JVector2fToVector2f (env, vec),
        Converters::JColorToGtColor (env, color),
        tolerance
    );
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetScreenshot
(JNIEnv* env, jobject obj) {
    return Converters::GtScreenShotToJScreenShot(env, Converters::JWindowToGtWindow(env, obj).GetScreenshot());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetScreenshotRect
(JNIEnv* env, jobject obj, jobject topLeft, jobject size) {
    return Converters::GtScreenShotToJScreenShot(env, Converters::JWindowToGtWindow(env, obj).GetScreenshotRect(
        Converters::JVector2IToVector2I(env, topLeft),
        Converters::JVector2IToVector2I(env, size)
    ));
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_GetPixelColorAt
(JNIEnv* env, jobject obj, jobject vec) {
    return Converters::GtColorToJColor(env, Converters::JWindowToGtWindow(env, obj).GetPixelColorAt(Converters::JVector2IToVector2I(env, vec)));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_PixelAtShouldBeColor
(JNIEnv* env, jobject obj, jobject vec, jobject color) {
    Converters::JWindowToGtWindow(env, obj).PixelAtShouldBeColor(
        Converters::JVector2IToVector2I(env, vec),
        Converters::JColorToGtColor(env, color)
    );
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTWindow_dispose
(JNIEnv* env, jobject obj) {
	delete static_cast<GTWindow*>(Converters::getNativePtr(env, obj));
}
