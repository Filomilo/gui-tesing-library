#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTSystemVersion.h"
#include "Converters.h"

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystemVersion_GetVersionString
(JNIEnv* env, jobject obj) {
    return Converters::StringToJString(env, Converters::JOSVersionToGTOsVersion(env, obj).GetVersionString()) ;
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystemVersion_dispose
(JNIEnv* env, jobject obj){
	delete static_cast<GTSystemVersion*>(Converters::getNativePtr(env, obj));
}
