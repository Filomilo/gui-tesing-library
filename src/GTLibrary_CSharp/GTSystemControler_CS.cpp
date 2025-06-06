#include "GTSystemControler_CS.h"
#include "GTWindow_CS.h"
#include "GTProcess_CS.h"
#include "Vector2i_CS.h"
#include "GTSystemVersion_CS.h"
#include "Converters.h"
using namespace System::Collections::Generic;



List<GTWindow_CS^>^ GTSystemControler_CS::FindWindowByName(String^ name) {
    auto nativeWindows = nativeSystem->FindWindowByName(Converters::ConvertStringToWStdString(name));
    List<GTWindow_CS^>^ managedWindows = gcnew List<GTWindow_CS^>(2);
    for (auto& nativeWindow : nativeWindows) {
        managedWindows->Add(gcnew GTWindow_CS(new GTWindow(nativeWindow.GetHandle())));
    }
    return managedWindows;
}

List<GTProcess_CS^>^ GTSystemControler_CS::FindProcessByName(String^ name) {
   
    auto nativeProcesses = nativeSystem->FindProcessByName(Converters::ConvertStringToStdString(name));
    List<GTProcess_CS^>^ managedProcesses = gcnew List<GTProcess_CS^>(2);
    for (GTProcess nativeProcess : nativeProcesses) {
        GTProcess* _GTProcess = new GTProcess(nativeProcess.GetHandle());
        managedProcesses->Add(Converters::ProcessToProcessCS(_GTProcess));
    }
    return managedProcesses;
}

GTWindow_CS^ GTSystemControler_CS::FindTopWindowByName(String^ name) {
    auto nativeWindow = nativeSystem->FindTopWindowByName(Converters::ConvertStringToStdString(name));
    if (!nativeWindow.has_value())
    {
        return nullptr;
    }
    return gcnew GTWindow_CS(new GTWindow(nativeWindow.value().GetHandle()));
}

GTSystemControler_CS^ GTSystemControler_CS::WindowOfNameShouldExist(String^ name) {
    try {
        nativeSystem->WindowOfNameShouldExist(Converters::ConvertStringToStdString(name));
    }
	catch (const std::runtime_error& e) {
		throw gcnew System::Exception(gcnew System::String(e.what()));
	}
    return this;
}

List<GTProcess_CS^>^ GTSystemControler_CS::GetActiveProcesses() {
    std::vector<GTProcess>  nativeProcesses = nativeSystem->GetActiveProcesses();
    List<GTProcess_CS^>^ managedProcesses = gcnew List<GTProcess_CS^>(2);
    for (GTProcess nativeProcess : nativeProcesses) {
		GTProcess* _GTProcess = new GTProcess(nativeProcess.GetHandle());
        managedProcesses->Add(Converters::ProcessToProcessCS(_GTProcess));
    }
    return managedProcesses;
}

List<GTWindow_CS^>^ GTSystemControler_CS::GetActiveWindows() {
    auto nativeWindows = nativeSystem->GetActiveWindows();
    List<GTWindow_CS^>^ managedWindows = gcnew List<GTWindow_CS^>(2);
    for (auto& nativeWindow : nativeWindows) {
        managedWindows->Add(gcnew GTWindow_CS(new GTWindow(nativeWindow.GetHandle())));
    }
    return managedWindows;
}

String^ GTSystemControler_CS::GetClipBoardContent() {
    return Converters::ConvertWStdStringToString(nativeSystem->GetClipBoardContent()) ;
}

GTProcess_CS^ GTSystemControler_CS::StartProcess(String^ commandString) {
   
 auto nativeProcess = nativeSystem->StartProcess(Converters::ConvertStringToStdString(commandString));
 GTProcess* _GTProcess = new GTProcess(nativeProcess.GetHandle());
    return  _GTProcess ? gcnew GTProcess_CS(_GTProcess) : nullptr;
}

GTSystemVersion_CS^ GTSystemControler_CS::GetOsVersion() {
    return gcnew GTSystemVersion_CS(nativeSystem->GetOsVersion());
}

GTSystemVersion_CS^ GTSystemControler_CS::GetSystemVersion() {
    return gcnew GTSystemVersion_CS(nativeSystem->GetSystemVersion());
}

int GTSystemControler_CS::GetWindowTitleBarHeight() {
    return nativeSystem->GetWindowTitleBarHeight();
}

int GTSystemControler_CS::GetWindowBorderWidth() {
    return nativeSystem->GetWindowBorderWidth();
}

int GTSystemControler_CS::GetWindowBorderHeight() {
    return nativeSystem->GetWindowBorderHeight();
}

int GTSystemControler_CS::GetWindowPadding() {
    return nativeSystem->GetWindowPadding();
}

Vector2i_CS^ GTSystemControler_CS::GetScreenSize() {
    auto nativeSize = nativeSystem->GetScreenSize();
    return gcnew Vector2i_CS(nativeSize.x, nativeSize.y);
}

Vector2i_CS^ GTSystemControler_CS::GetMaximizedWindowSize()
{
	return gcnew Vector2i_CS(nativeSystem->GetMaximizedWindowSize());

}
