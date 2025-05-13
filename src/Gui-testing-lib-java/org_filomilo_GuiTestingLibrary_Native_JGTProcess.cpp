#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTProcess.h"
#include "Converters.h"

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getName
(JNIEnv* env, jobject obj) {
    return Converters::WStringToJstring(env, Converters::JProcessToGtProcess(env, obj).GetName());
}

JNIEXPORT jboolean JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_isAlive
(JNIEnv* env, jobject obj) {
    return Converters::JProcessToGtProcess(env, obj).IsAlive();
}

JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getWindowsOfProcess
(JNIEnv* env, jobject obj) {
    std::vector<GTWindow> windwos = Converters::JProcessToGtProcess(env, obj).GetWindowsOfProcess();
    jclass windowClass = env->FindClass("org/filomilo/GuiTestingLibrary/Native/JGTWindow");
    jobjectArray array = env->NewObjectArray(windwos.size(), windowClass, nullptr);
    for (size_t i = 0; i < windwos.size(); i++)
    {
        env->SetObjectArrayElement(array, i, Converters::GtWindowToJwindow(env, windwos[i]));
    }
    return array;
}

JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getRamUsage
(JNIEnv* env, jobject obj) {
    return Converters::JProcessToGtProcess(env, obj).GetRamUsage();
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_kill
(JNIEnv* env, jobject obj) {
    Converters::JProcessToGtProcess(env, obj).Kill();
}
