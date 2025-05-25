using System;
using System.Collections.Generic;
using gui_tesing_library_CS.SystemCalls;
using gui_tesing_library;
using gui_tesing_library.Interfaces;

using Lombok.NET;

namespace gui_tesing_library_CS.Components.CS
{
    [AllArgsConstructor]
    [With]
    public partial class GTProcess_CS_OLD : IGTProcess
    {
        private ISystemCalls _SystemCalls = SystemCallsFactory.GetSystemCalls();

        private int _handle;

        public GTProcess_CS_OLD(int handle)
        {
            this._handle = handle;
        }

        //private Process _Process;
        //public int ProcesId
        //{
        //    get { return this._Process.Id; }
        //}

        //public bool DoesExist
        //{
        //    get { return _Process.Id>0; }
        //}

        //public int kill()
        //{
        //    if(!DoesExist)
        //    {
        //        //todo: logg warrignng
        //        return 0;
        //    }
        //    this._Process.Kill();
        //    Helpers.AwaitTrue(() =>
        //    {
        //        return this._Process.HasExited;
        //    });
        //    return 0;
        //    // add exception handling
        //}

        //public GTProcess_CS(Process process)
        //{
        //    this._Process = process;
        //}

        //public List<GTWindow> getPrcoessWindow()
        //{

        //    List<IntPtr> windowHandles = new List<IntPtr>();
        //    Console.WriteLine($"This Peocesss: {this.ProcesId}");
        //    WinApiWrapper.EnumWindows((hwnd, param) =>
        //       {

        //           StringBuilder title = new StringBuilder(256);
        //           WinApiWrapper.GetWindowText(hwnd, title, title.Capacity);

        //           if (title.Length > 0) // Ignore empty titles
        //           {
        //               Console.WriteLine($"Window Handle: {hwnd}, Title: {title}");
        //           }

        //           GetWindowThreadProcessId(hwnd, out uint parentProcessId);

        //           Console.WriteLine($"Window Handle: {hwnd}, Process ID: {parentProcessId}");

        //           return true; // Continue enumeration
        //       }, IntPtr.Zero);



        //       return null;

        //}
        public string Name => throw new NotImplementedException();

        public bool IsAlive
        {
            get { return _SystemCalls.GetDoesProcessExist(this._handle); }
        }

        public long GetRamUsage()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGTWindow> GetWindowsOfProcess()
        {
            throw new NotImplementedException();
        }

        public void kill()
        {
            this._SystemCalls.TerminateProcess(this._handle);
        }
    }
}
