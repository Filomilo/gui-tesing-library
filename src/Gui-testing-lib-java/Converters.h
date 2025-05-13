#pragma once
#include "pch.h"
#include <jni.h>
#include <string>
#include "../GtLibrary/Vector2i.h"
#include "../GtLibrary/Vector2f.h"
#include "../GtLibrary/Key.h"
#include "../GtLibrary/GTWindow.h"
#include "../GtLibrary/GTProcess.h"
#include "../GtLibrary/Color.h"
#include "../GtLibrary/GTScreenshot.h"
#include "../GtLibrary/GTSystemVersion.h"

class Converters
{


public: 
	static std::wstring JStringToWString(JNIEnv* env,jstring _jstring);
	static jstring WStringToJstring(JNIEnv* env, std::wstring _wstring);

	static std::string JStringToString(JNIEnv* env, jstring _jstring);
	static jstring StringToJString(JNIEnv* env, std::string _string);

	static long JLongToLong(JNIEnv* env, jlong _jlong);
	static jlong LongToJLong(JNIEnv* env, long _long);

	static Vector2i JVector2IToVector2I(JNIEnv* env, jobject _jvector2i);
	static jobject Vector2IToJVector2I(JNIEnv* env, Vector2i _vector2i);

	static Vector2f JVector2fToVector2f(JNIEnv* env, jobject _jvector2f);
	static jobject Vector2fToJVector2f(JNIEnv* env, Vector2f _vector2f);

	static GTKey JKeyToGtKEy(JNIEnv* env, jobject _jkey);

	static GTWindow JWindowToGtWindow(JNIEnv* env, jobject _jwindow);
	static jobject GtWindowToJwindow(JNIEnv* env, GTWindow win);

	static GTProcess JProcessToGtProcess(JNIEnv* env, jobject _Jprocess);
	static  jobject GTrocessToJProcess(JNIEnv* env, GTProcess _process);


	static jobject GtScreenShotToJScreenShot(JNIEnv* env, GTScreenshot* _GtScreenshot);
	static GTScreenshot* JScreenShotToGtScreenShot(JNIEnv* env, jobject _jscrrenShot);

	static jobject GtColorToJColor(JNIEnv* env, Color _color);
	static Color JColorToGtColor(JNIEnv* env, jobject _Jcolor);

	static jobject GtOsVersionToJOsVersion(JNIEnv* env, GTSystemVersion _osVersion);
	static GTSystemVersion JOSVersionToGTOsVersion(JNIEnv* env, jobject _josVersion);
};

