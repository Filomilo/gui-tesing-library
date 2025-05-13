#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTKeyboard.h"
#include "../GtLibrary/GTKeyboad.h"
#include "Converters.h"


GTKeyboard _GTKeyboard = GTKeyboard();


JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTKeyboard_pressKey
  (JNIEnv * env, jobject, jobject _jobject) {
	_GTKeyboard.PressKey(Converters::JKeyToGtKEy(env, _jobject));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTKeyboard_releaseKey
  (JNIEnv * env, jobject, jobject _jobject) {
	_GTKeyboard.ReleaseKey(Converters::JKeyToGtKEy(env, _jobject));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTKeyboard_clickKey
  (JNIEnv * env, jobject, jobject _jobject) {
	_GTKeyboard.ClickKey(Converters::JKeyToGtKEy(env, _jobject));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTKeyboard_type
  (JNIEnv * env, jobject, jstring _jstring) {
	_GTKeyboard.Type(Converters::JStringToWString(env, _jstring));
}

