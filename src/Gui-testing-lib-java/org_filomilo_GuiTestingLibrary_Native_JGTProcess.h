/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class org_filomilo_GuiTestingLibrary_Native_JGTProcess */

#ifndef _Included_org_filomilo_GuiTestingLibrary_Native_JGTProcess
#define _Included_org_filomilo_GuiTestingLibrary_Native_JGTProcess
#ifdef __cplusplus
extern "C" {
#endif
/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTProcess
 * Method:    dispose
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_dispose
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTProcess
 * Method:    getName
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getName
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTProcess
 * Method:    isAlive
 * Signature: ()Z
 */
JNIEXPORT jboolean JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_isAlive
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTProcess
 * Method:    getWindowsOfProcess
 * Signature: ()[Lorg/filomilo/GuiTestingLibrary/Native/JGTWindow;
 */
JNIEXPORT jobjectArray JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getWindowsOfProcess
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTProcess
 * Method:    getRamUsage
 * Signature: ()J
 */
JNIEXPORT jlong JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_getRamUsage
  (JNIEnv *, jobject);

/*
 * Class:     org_filomilo_GuiTestingLibrary_Native_JGTProcess
 * Method:    kill
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_org_filomilo_GuiTestingLibrary_Native_JGTProcess_kill
  (JNIEnv *, jobject);

#ifdef __cplusplus
}
#endif
#endif
