/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class org_filomilo_GuiTestingLibrary_Native_JGTSystem */

#ifndef _Included_org_filomilo_GuiTestingLibrary_Native_JGTSystem
#define _Included_org_filomilo_GuiTestingLibrary_Native_JGTSystem
#ifdef __cplusplus
extern "C" {
#endif
/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    FindWindowByName
 * Signature: (Ljava/lang/String;)[Lorg/filomilo/GuiTestingLibrary/Native/JGTWindow;
 */
JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_FindWindowByName
  (JNIEnv *, jobject, jstring);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    FindProcessByName
 * Signature: (Ljava/lang/String;)[Lorg/filomilo/GuiTestingLibrary/Native/JGTProcess;
 */
JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_FindProcessByName
  (JNIEnv *, jobject, jstring);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    FindTopWindowByName
 * Signature: (Ljava/lang/String;)Lorg/filomilo/GuiTestingLibrary/Native/JGTWindow;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_FindTopWindowByName
  (JNIEnv *, jobject, jstring);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    WindowOfNameShouldExist
 * Signature: (Ljava/lang/String;)V
 */
JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_WindowOfNameShouldExist
  (JNIEnv *, jobject, jstring);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetActiveProcesses
 * Signature: ()[Lorg/filomilo/GuiTestingLibrary/Native/JGTProcess;
 */
JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetActiveProcesses
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetActiveWindows
 * Signature: ()[Lorg/filomilo/GuiTestingLibrary/Native/JGTWindow;
 */
JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetActiveWindows
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetClipBoardContent
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetClipBoardContent
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    StartProcess
 * Signature: (Ljava/lang/String;)Lorg/filomilo/GuiTestingLibrary/Native/JGTProcess;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_StartProcess
  (JNIEnv *, jobject, jstring);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetOsVersion
 * Signature: ()Lorg/filomilo/GuiTestingLibrary/Native/JGTSystemVersion;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetOsVersion
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetWindowTitleBarHeight
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowTitleBarHeight
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetWindowBorderWidth
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowBorderWidth
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetWindowBorderHeight
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowBorderHeight
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetWindowPadding
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetWindowPadding
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetScreenSize
 * Signature: ()Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetScreenSize
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTSystem
 * Method:    GetMaximizedWindowSize
 * Signature: ()Lorg/filomilo/GuiTestingLibrary/Native/JGTVector2i;
 */
JNIEXPORT jobject JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTSystem_GetMaximizedWindowSize
  (JNIEnv *, jobject);

#ifdef __cplusplus
}
#endif
#endif
