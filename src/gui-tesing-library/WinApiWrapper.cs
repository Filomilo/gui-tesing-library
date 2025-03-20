using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library
{
    public static class WinApiWrapper
    {
        public static Process CreateProcess(string startCommand)
        {

            List< String> splits = startCommand.Split(' ').ToList();
            if (splits.Count == 0)
            {
//todo: custom exception
            }

            String programName = splits[0];
            splits.RemoveAt(0);
            string args = "";
            if (splits.Count > 0)
            {
                args = string.Join(" ",splits);
            }
            // todo: handle spaces in path
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = programName;
            startInfo.Arguments = args;
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            Process process = Process.Start(startInfo);
            
            return process;
        }


        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    [DllImport("user32.dll")]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("kernel32.dll")]
    public static extern uint GetProcessIdOfThread(IntPtr ThreadHandle);


    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }


    }
}
