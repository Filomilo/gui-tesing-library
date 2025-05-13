#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTSystem.h"
#include "../GtLibrary/GTSystem.h"
#include "../GtLibrary/GTProcess.h"
#include "Converters.h"

std::shared_ptr<GTSystem>  _GtSystem = GTSystem::Instance();

JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_FindWindowByName
(JNIEnv* env, jobject, jstring name) {
    std::vector<GTWindow> windwos = _GtSystem->FindWindowByName(Converters::JStringToString(env, name));
    jclass windowClass = env->FindClass("org/filomilo/GuiTestingLibrary/Native/JGTWindow");
    jobjectArray array = env->NewObjectArray(windwos.size(), windowClass, nullptr);
    for (size_t i = 0; i < windwos.size(); i++)
    {
    env->SetObjectArrayElement(array, i, Converters::GtWindowToJwindow(env, windwos[i]));
    }
    return array;

}

JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_FindProcessByName
(JNIEnv* env, jobject, jstring name) {
    std::vector<GTProcess> proceses = _GtSystem->FindProcessByName(Converters::JStringToString(env, name));
    jclass processsClass = env->FindClass("org/filomilo/GuiTestingLibrary/Native/JGTProcess");
    jobjectArray array = env->NewObjectArray(proceses.size(), processsClass, nullptr);
    for (size_t i = 0; i < proceses.size(); i++)
    {
        env->SetObjectArrayElement(array, i, Converters::GTrocessToJProcess(env, proceses[i]));
    }
    return array;
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_FindTopWindowByName
(JNIEnv* env, jobject, jstring name) {
    std::optional<GTWindow> window = _GtSystem->FindTopWindowByName(Converters::JStringToString(env, name));
    return window.has_value() ? Converters::GtWindowToJwindow(env, window.value()) : nullptr;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_WindowOfNameShouldExist
(JNIEnv* env, jobject, jstring name)  {
    _GtSystem->WindowOfNameShouldExist(Converters::JStringToString(env, name));
}

JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetActiveProcesses
(JNIEnv* env, jobject) {
    std::vector<GTProcess> proceses = _GtSystem->GetActiveProcesses();
    jclass processsClass = env->FindClass("org/filomilo/GuiTestingLibrary/Native/JGTProcess");
    jobjectArray array = env->NewObjectArray(proceses.size(), processsClass, nullptr);
    for (size_t i = 0; i < proceses.size(); i++)
    {
        env->SetObjectArrayElement(array, i, Converters::GTrocessToJProcess(env, proceses[i]));
    }
    return array;
}

JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetActiveWindows
(JNIEnv* env, jobject) {
    std::vector<GTWindow> windows = _GtSystem->GetActiveWindows();
    jclass processsClass = env->FindClass("org/filomilo/GuiTestingLibrary/Native/JGTWindow");
    jobjectArray array = env->NewObjectArray(windows.size(), processsClass, nullptr);
    for (size_t i = 0; i < windows.size(); i++)
    {
        env->SetObjectArrayElement(array, i, Converters::GtWindowToJwindow(env, windows[i]));
    }
    return array;
}

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetClipBoardContent
(JNIEnv* env, jobject) {
    return Converters::WStringToJstring(env, _GtSystem->GetClipBoardContent());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_StartProcess
(JNIEnv* env, jobject, jstring string) {
    return Converters::GTrocessToJProcess(env, _GtSystem->StartProcess(Converters::JStringToString(env, string)));
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetOsVersion
(JNIEnv* env, jobject) {
    return Converters::GtOsVersionToJOsVersion(env, _GtSystem->GetOsVersion());
}


JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowTitleBarHeight
(JNIEnv* env, jobject) {
    return _GtSystem->GetWindowTitleBarHeight();
}

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowBorderWidth
(JNIEnv* env, jobject) {
    return _GtSystem->GetWindowBorderWidth();
}

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowBorderHeight
(JNIEnv* env, jobject) {
    return _GtSystem->GetWindowBorderHeight();
}

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowPadding
(JNIEnv* env, jobject) {
    return _GtSystem->GetWindowBorderHeight();
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetScreenSize
(JNIEnv* env, jobject) {
    return Converters::Vector2IToJVector2I(env, _GtSystem->GetScreenSize());
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetMaximizedWindowSize
(JNIEnv* env, jobject) {
    return Converters::Vector2IToJVector2I(env, _GtSystem->GetMaximizedWindowSize());
}
