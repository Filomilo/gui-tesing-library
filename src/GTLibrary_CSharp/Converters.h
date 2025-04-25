#pragma once
#include <string>
//#include <msclr/marshal_cppstd.h>

ref class Converters
{
public:
    static std::string ConvertStringToStdString(System::String^ managedString) {
        return "asd";
        //return msclr::interop::marshal_as<std::string>(managedString);
    }
};