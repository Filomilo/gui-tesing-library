using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using gui_tesing_library.Components;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using WindowsInput;
using static gui_tesing_library.WinApiWrapper;

namespace gui_tesing_library.WInApi
{
    class WindwosSystemCalls : ISystemCalls
    {
        private InputSimulator _inputSimulator = new InputSimulator();
        public int CreateProcess(string startCommand)
        {
            String programName = "";
            String args = "";
            if (startCommand.StartsWith("\""))
            {
                Match match = Regex.Match(startCommand, "\"(.*?)\"");
                if (match.Success)
                {
                    programName = $"\"{match.Groups[1].Value}\"";
                    args = startCommand.Substring(programName.Length);
                }
            }
            if (programName.Length == 0)
            {
                List<String> splits = startCommand.Split(' ').ToList();
                if (splits.Count == 0)
                {
                    //todo: custom exception
                }

                programName = splits[0];
                splits.RemoveAt(0);
                args = "";
                if (splits.Count > 0)
                {
                    args = string.Join(" ", splits);
                }
            }

            // todo: handle spaces in path
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = programName;
            startInfo.Arguments = args;
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            Process process = Process.Start(startInfo);

            return process.Handle.ToInt32();
        }

        public bool GetDoesProcessExist(int handle)
        {
            uint exitCode;
            if (WinApiWrapper.GetExitCodeProcess( new IntPtr(handle), out exitCode))
            {
                return exitCode == 259;// STILL_ACTIVE; 
            }
            return false;
        }

        public void TerminateProcess(int handle)
        {
            IntPtr exitCode;
            WinApiWrapper.TerminateProcess(new IntPtr(handle), 0);
        }



        public int FindWindowByName(string name)
        {
           return (int)WinApiWrapper.FindWindowA(null,name);
        }

        public Vector2i GetWindowPositon(int handle)
        {
            WinApiWrapper.RECT rect;
            WinApiWrapper.GetWindowRect(new IntPtr(handle), out rect);
            return new Vector2i(rect.Left, rect.Top);
        }

        public Vector2i GetWindowSize(int handle)
        {
            WinApiWrapper.RECT rect;
            WinApiWrapper.GetWindowRect(new IntPtr(handle), out rect);
            return new Vector2i(rect.Right- rect.Left,rect.Bottom- rect.Top);
        }

        public void CloseWindow(int handle)
        {
            WinApiWrapper.CloseWindow(new IntPtr(handle) );
        }

        public bool DoesWindowExist(int handle)
        {
           return WinApiWrapper.IsWindow(new IntPtr(handle));
        }

        public int GetWindowThreadProcessId(int handle)
        {
            uint ProcessId;
            WinApiWrapper.GetWindowThreadProcessId(new IntPtr(handle), out ProcessId);
            return (int)ProcessId;
        }


        public int GetProcessHandleFromId(int id)
        {
            IntPtr processHandle = WinApiWrapper.OpenProcess(WinApiWrapper.ProcessAccessRights. PROCESS_QUERY_INFORMATION | WinApiWrapper.ProcessAccessRights.PROCESS_VM_READ | ProcessAccessRights.PROCESS_TERMINATE, false, id);
            return processHandle.ToInt32();
        }

        public void MinimizeWindow(int handle)
        {
            WinApiWrapper.ShowWindow(new IntPtr(handle),
                NCmdShow.SW_MINIMIZE
            );
        }

        public bool IsWindowsMinimized(int handle)
        {
            return WinApiWrapper.IsIconic(new IntPtr(handle));
        }

        public void BringWindowUpFront(int handle)
        {
            WinApiWrapper.ShowWindow(new IntPtr(handle),
                NCmdShow.SW_RESTORE
            );
            bool returnVal = WinApiWrapper.ShowWindow(new IntPtr(handle),
                NCmdShow.SW_SHOW
            );
            WinApiWrapper.BringWindowToTop(new IntPtr(handle));
        }

        public void MaximizeWindow(int handle)
        {

            WinApiWrapper.ShowWindow(new IntPtr(handle),
                NCmdShow.SW_SHOWMAXIMIZED   
            );
        }

        public Vector2i GetMaximizedWindowSize()
        {
          return  new Vector2i(
                WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXMAXIMIZED),
                WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYMAXIMIZED)
            );
        }

        public void SetWindowPostion(int handle, Vector2i vector2i)
        {
            WinApiWrapper.SetWindowPos(new IntPtr(handle), 0, vector2i.x, vector2i.y, 0, 0, UFlags.SWP_NOSIZE);
        }

        public void SetWindowSize(int handle, Vector2i vector2i)
        {
            WinApiWrapper.SetWindowPos(new IntPtr(handle), 0, 0, 0, vector2i.x, vector2i.y, UFlags.SWP_NOMOVE);
        }

        public void SetMousePostion(Vector2i position)
        {
            WinApiWrapper.SetCursorPos(position.x, position.y);
        }

        public Vector2i GetMousePosition()
        {
            WinApiWrapper.GetCursorPos(out POINT pos);
            return new Vector2i((int)pos.x, (int)pos.y);
        }

        public string GetWindowName(int handle)
        {
            StringBuilder stringBuilder = new StringBuilder();
            WinApiWrapper.GetWindowText(new IntPtr(handle) , stringBuilder, 512);
            return stringBuilder.ToString();
        }

        void ISystemCalls.ClickLeft()
        {
            _inputSimulator.Mouse.LeftButtonClick();


        }
    }
}
