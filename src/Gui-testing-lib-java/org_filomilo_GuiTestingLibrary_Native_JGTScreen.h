/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class org_filomilo_GuiTestingLibrary_Native_JGTScreen */

#ifndef _Included_org_filomilo_GuiTestingLibrary_Native_JGTScreen
#define _Included_org_filomilo_GuiTestingLibrary_Native_JGTScreen
#ifdef __cplusplus
extern "C" {
#endif
/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTScreen
 * Method:    GetSize
 * Signature: ()Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetSize
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTScreen
 * Method:    GetMaximizedWindowSize
 * Signature: ()Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetMaximizedWindowSize
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTScreen
 * Method:    GetScreenshot
 * Signature: ()Lorg/filomilo/GuiTestingLibrary/Native/JGTScreenshot;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetScreenshot
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTScreen
 * Method:    GetScreenshotRect
 * Signature: (Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;)Lorg/filomilo/GuiTestingLibrary/Native/JGTScreenshot;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetScreenshotRect
  (JNIEnv *, jobject, jobject, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTScreen
 * Method:    GetPixelColorAt
 * Signature: (Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;)Lorg/filomilo/GuiTestingLibrary/Native/JGTColor;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_GetPixelColorAt
  (JNIEnv *, jobject, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTScreen
 * Method:    PixelAtShouldBeColor
 * Signature: (Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;Lorg/filomilo/GuiTestingLibrary/Native/JGTColor;)V
 */
JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTScreen_PixelAtShouldBeColor
  (JNIEnv *, jobject, jobject, jobject);

#ifdef __cplusplus
}
#endif
#endif
