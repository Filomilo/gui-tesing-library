#include "pch.h"
#include "org_filomilo_GuiTestingLibrary_Native_NativeGtSystem.h"


#include <jni.h>

JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_NativeGtSystem_GetClipBoard
(JNIEnv* env, jobject obj)
{
	jstring result = env->NewStringUTF("Hello from C++");
	return result;
}