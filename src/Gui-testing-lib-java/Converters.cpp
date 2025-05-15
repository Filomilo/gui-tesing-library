#include "pch.h"
#include <jni.h>
#include "Converters.h"
#include <iostream>







jobject createJavaVector(JNIEnv* env,std::string className, void* pointer) {
    jclass cls = env->FindClass(className.c_str());
    if (!cls) {
        return nullptr;
    }

    jmethodID ctor = env->GetMethodID(cls, "<init>", "(J)V");
    if (!ctor) {
        return nullptr;
    }
    return env->NewObject(cls, ctor, reinterpret_cast<jlong>(pointer));
}


std::wstring Converters::JStringToWString(JNIEnv* env,jstring _jstring) {
    std::wstring value;

    const jchar* raw = env->GetStringChars(_jstring, 0);
    jsize len = env->GetStringLength(_jstring);

    value.assign(raw, raw + len);

    env->ReleaseStringChars(_jstring, raw);

    return value;
}
jstring Converters::WStringToJstring(JNIEnv* env, std::wstring _wstring) {
    return env->NewString(reinterpret_cast<const jchar*>(_wstring.c_str()), _wstring.length());
}





std::string Converters::JStringToString(JNIEnv* env, jstring _jstring) {

    const char* chars = env->GetStringUTFChars(_jstring, nullptr);
    std::string result(chars);
    env->ReleaseStringUTFChars(_jstring, chars);

    return result;

 }
 jstring Converters::StringToJString(JNIEnv* env, std::string _string) {
     return env->NewStringUTF(_string.c_str());
 }

 long Converters::JLongToLong(JNIEnv* env, jlong _jlong) {
     return _jlong;
 }
 jlong Converters::LongToJLong(JNIEnv* env, long _long) {
     return _long;
 }

 Vector2i Converters::JVector2IToVector2I(JNIEnv* env, jobject _jvector2i) {
     Vector2i* vec = (Vector2i*)getNativePtr(env, _jvector2i);
     return *vec;

 }
 jobject Converters::Vector2IToJVector2I(JNIEnv* env, Vector2i _vector2i) {
     Vector2i* vec = new Vector2i(_vector2i);
     return createJavaVector(env, "org/filomilo/GuiTestingLibrary/Native/JGTVector2i", vec);
 }

 Vector2f Converters::JVector2fToVector2f(JNIEnv* env, jobject _jvector2f) {
     Vector2f* vec = (Vector2f*)getNativePtr(env, _jvector2f);
     return *vec;
 }
 jobject Converters::Vector2fToJVector2f(JNIEnv* env, Vector2f _vector2f) {
     Vector2f* vec = new Vector2f(_vector2f);
     return createJavaVector(env, "org/filomilo/GuiTestingLibrary/Native/JGTVector2f", vec);

 }
 GTKey Converters::JKeyToGtKEy(JNIEnv* env, jobject _jkey) {

     jclass enumClass = env->GetObjectClass(_jkey);
     jmethodID ordinalMethod = env->GetMethodID(enumClass, "ordinal", "()I");
     jint ordinal = env->CallIntMethod(_jkey, ordinalMethod);
     return static_cast<GTKey>(ordinal);
 }

 GTWindow Converters::JWindowToGtWindow(JNIEnv* env, jobject _jwindow) {
     GTWindow* win = (GTWindow*)getNativePtr(env, _jwindow);
     return *win;
 }
 jobject Converters::GtWindowToJwindow(JNIEnv* env, GTWindow _win) {
     GTWindow* win = new GTWindow(_win);
     return createJavaVector(env, "org/filomilo/GuiTestingLibrary/Native/JGTWindow", win);
 }

 GTProcess* Converters::JProcessToGtProcess(JNIEnv* env, jobject _Jprocess) {

     GTProcess* proc = (GTProcess*)getNativePtr(env, _Jprocess);
     return proc;
 }
  jobject Converters::GTrocessToJProcess(JNIEnv* env, GTProcess _process) {
      GTProcess* proc = new GTProcess(_process.GetHandle());
      std::cout << "Converting windwos to jwindow:: \n";
      std::wcout << proc->GetName();
      return createJavaVector(env, "org/filomilo/GuiTestingLibrary/Native/JGTProcess", proc);
  }


 jobject Converters::GtScreenShotToJScreenShot(JNIEnv* env, GTScreenshot* _GtScreenshot) {
     return createJavaVector(env, "org/filomilo/GuiTestingLibrary/Native/JGTScreenshot", _GtScreenshot);
 }
 GTScreenshot* Converters::JScreenShotToGtScreenShot(JNIEnv* env, jobject _jscrrenShot) {
     GTScreenshot* screen = (GTScreenshot*)getNativePtr(env, _jscrrenShot);
     return screen;
 }

 jobject Converters::GtColorToJColor(JNIEnv* env, Color _color) {
     jclass cls = env->FindClass("org/filomilo/GuiTestingLibrary/Native/JGTColor");
     if (cls == nullptr) {
         return nullptr;
     }
     jmethodID constructor = env->GetMethodID(cls, "<init>", "(III)V");
     if (constructor == nullptr) {
         return nullptr;
     }

     jobject colorObject = env->NewObject(cls, constructor, _color.r, _color.g, _color.b);
     return colorObject;
 }
 Color Converters::JColorToGtColor(JNIEnv* env, jobject _Jcolor) {
     jclass cls = env->GetObjectClass(_Jcolor);
     jfieldID red_id = env->GetFieldID(cls, "r", "I");
     jfieldID green_id = env->GetFieldID(cls, "g", "I");
     jfieldID blue_id = env->GetFieldID(cls, "b", "I");

 
     jint r = env->GetIntField(_Jcolor, red_id);
     jint g = env->GetIntField(_Jcolor, green_id);
     jint b = env->GetIntField(_Jcolor, blue_id);
     return Color(r,g,b);
 }

 jobject Converters::GtOsVersionToJOsVersion(JNIEnv* env, GTSystemVersion _osVersion) {
     
     GTSystemVersion* os = new GTSystemVersion(_osVersion);
     return createJavaVector(env, "org/filomilo/GuiTestingLibrary/Native/JGTSystemVersion", os);
 }
 GTSystemVersion Converters::JOSVersionToGTOsVersion(JNIEnv* env, jobject _josVersion) {
     GTSystemVersion* os = (GTSystemVersion*)getNativePtr(env, _josVersion);
     return *os;
 }

 jboolean Converters::boolToJBool(JNIEnv* env, bool val) {
     return val ? JNI_TRUE : JNI_FALSE;
 }

 jobject Converters::ImageCOmparertOJImageComparer(JNIEnv* env, int cppEnumValue) {
     jclass enumClass = env->FindClass("org/filomilo/GuiTestingLibrary/Native/JGTConfiguration/IMageComparer");
     jmethodID valuesMethod = env->GetStaticMethodID(enumClass, "values", "()[org/filomilo/GuiTestingLibrary/Native/JGTConfiguration/IMageComparer;");
     jobjectArray enumValues = (jobjectArray)env->CallStaticObjectMethod(enumClass, valuesMethod);
     jobject javaEnum = env->GetObjectArrayElement(enumValues, cppEnumValue);
     return javaEnum;
 }


 IMMAGE_COMPARPER_TYPE Converters::JIMAGECOpmaretOGtImageCOmparer(JNIEnv* env, jobject javaEnum)
 {
     jclass enumClass = env->GetObjectClass(javaEnum);
     jmethodID ordinalMethod = env->GetMethodID(enumClass, "ordinal", "()I");
     jint ordinal = env->CallIntMethod(javaEnum, ordinalMethod);

     IMMAGE_COMPARPER_TYPE cppEnum = static_cast<IMMAGE_COMPARPER_TYPE>(ordinal);
     return cppEnum;
 }