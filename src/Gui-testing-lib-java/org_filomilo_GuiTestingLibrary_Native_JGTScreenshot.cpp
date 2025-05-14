#include "pch.h"
#include <jni.h>
#include "org_filomilo_GuiTestingLibrary_Native_JGTScreenshot.h"
#include "Converters.h"

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_GetWidth
(JNIEnv* env, jobject obj) {
    return Converters::JScreenShotToGtScreenShot(env, obj)->GetWidth();
}

JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_GetHeight
(JNIEnv* env, jobject obj) {
    return Converters::JScreenShotToGtScreenShot(env, obj)->GetHeight();
}

JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_GetPixelColorAt
(JNIEnv* env, jobject obj, jint x , jint y) {
    return Converters::GtColorToJColor(env, Converters::JScreenShotToGtScreenShot(env, obj)->GetPixelColorAt(Vector2i(x,y)));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_SaveAsBitmap
(JNIEnv* env, jobject obj, jstring location) {
    Converters::JScreenShotToGtScreenShot(env, obj)->SaveAsBitmap(Converters::JStringToString(env, location));
}

JNIEXPORT jdouble JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_CompareToImage
(JNIEnv* env, jobject obj, jstring locationOfImageToCompare) {
    return Converters::JScreenShotToGtScreenShot(env, obj)->CompareToImage(Converters::JStringToString(env, locationOfImageToCompare));
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_SimmilarityBetweenImagesShouldBe
(JNIEnv* env, jobject obj, jstring locationOfImageToCompare, jdouble shoudlBe) {
    Converters::JScreenShotToGtScreenShot(env, obj)->SimmilarityBetweenImagesShouldBe(Converters::JStringToString(env, locationOfImageToCompare), shoudlBe);
}

JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreenshot_dispose
(JNIEnv* env, jobject obj)
{
	delete static_cast<GTScreenshot*>(Converters::getNativePtr(env, obj));
}
