﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace gui_tesing_library_CS.SystemCalls;

public static class WinApiWrapper
{
    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    public enum HwndInsertAfter
    {
        HWND_TOP = 0,
        HWND_BOTTOM = 1,
        HWND_TOPMOST = -1,
        HWND_NOTOPMOST = -2
    }

    public enum INPUT_TYPE
    {
        INPUT_MOUSE = 0,
        INPUT_KEYBOARD = 1,
        INPUT_HARDWARE = 2
    }

    [Flags]
    public enum MouseEventFlags : uint
    {
        MOUSEEVENTF_MOVE = 0x0001, // Movement occurred
        MOUSEEVENTF_LEFTDOWN = 0x0002, // The left button was pressed
        MOUSEEVENTF_LEFTUP = 0x0004, // The left button was released
        MOUSEEVENTF_RIGHTDOWN = 0x0008, // The right button was pressed
        MOUSEEVENTF_RIGHTUP = 0x0010, // The right button was released
        MOUSEEVENTF_MIDDLEDOWN = 0x0020, // The middle button was pressed
        MOUSEEVENTF_MIDDLEUP = 0x0040, // The middle button was released
        MOUSEEVENTF_XDOWN = 0x0080, // An X button was pressed
        MOUSEEVENTF_XUP = 0x0100, // An X button was released
        MOUSEEVENTF_WHEEL = 0x0800, // The wheel was moved
        MOUSEEVENTF_HWHEEL = 0x1000, // The wheel was moved horizontally
        MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000, // The WM_MOUSEMOVE messages will not be coalesced
        MOUSEEVENTF_VIRTUALDESK = 0x4000, // Maps coordinates to the entire desktop
        MOUSEEVENTF_ABSOLUTE = 0x8000 // The dx and dy members contain normalized absolute coordinates
    }

    public enum NCmdShow
    {
        SW_HIDE = 0,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11
    }

    [Flags]
    public enum ProcessAccessRights : uint
    {
        PROCESS_TERMINATE = 0x0001,
        PROCESS_CREATE_THREAD = 0x0002,
        PROCESS_SET_INFORMATION = 0x0200,
        PROCESS_QUERY_INFORMATION = 0x0400,
        PROCESS_SET_QUOTA = 0x0100,
        PROCESS_SUSPEND_RESUME = 0x0800,
        PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
        PROCESS_VM_OPERATION = 0x0008,
        PROCESS_VM_READ = 0x0010,
        PROCESS_VM_WRITE = 0x0020,
        PROCESS_DUP_HANDLE = 0x0040,
        PROCESS_CREATE_PROCESS = 0x0080,
        SYNCHRONIZE = 0x00100000,
        PROCESS_ALL_ACCESS = 0x1F0FFF
    }

    public enum SystemMetrics
    {
        SM_ARRANGE = 56,
        SM_CLEANBOOT = 67,
        SM_CMOUSEBUTTONS = 43,
        SM_HMOUSEBUTTONS = 0x2003,
        SM_CXBORDER = 5,
        SM_CXCURSOR = 13,
        SM_CXDLGFRAME = 7,
        SM_CXDOUBLECLK = 36,
        SM_CXDRAG = 68,
        SM_CXEDGE = 45,
        SM_CXFIXEDFRAME = 7,
        SM_CXFOCUSBORDER = 83,
        SM_CXFRAME = 32,
        SM_CXFULLSCREEN = 16,
        SM_CXHSCROLL = 21,
        SM_CXHTHUMB = 10,
        SM_CXICON = 11,
        SM_CXICONSPACING = 38,
        SM_CXMAXIMIZED = 61,
        SM_CXMAXTRACK = 59,
        SM_CXMENUCHECK = 71,
        SM_CXMENUSIZE = 54,
        SM_CXMIN = 28,
        SM_CXMINIMIZED = 57,
        SM_CXMINSPACING = 47,
        SM_CXMINTRACK = 34,
        SM_CXPADDEDBORDER = 92,
        SM_CXSCREEN = 0,
        SM_CXSIZE = 30,
        SM_CXSIZEFRAME = 32,
        SM_CXSMICON = 49,
        SM_CXSMSIZE = 52,
        SM_CXVSCROLL = 2,
        SM_CYBORDER = 6,
        SM_CYCAPTION = 4,
        SM_CYCURSOR = 14,
        SM_CYDLGFRAME = 8,
        SM_CYDOUBLECLK = 37,
        SM_CYDRAG = 69,
        SM_CYEDGE = 46,
        SM_CYFIXEDFRAME = 8,
        SM_CYFOCUSBORDER = 84,
        SM_CYFRAME = 33,
        SM_CYFULLSCREEN = 17,
        SM_CYHSCROLL = 3,
        SM_CYICON = 12,
        SM_CYICONSPACING = 39,
        SM_CYKANJIWINDOW = 18,
        SM_CYMAXIMIZED = 62,
        SM_CYMAXTRACK = 60,
        SM_CYMENU = 15,
        SM_CYMENUCHECK = 72,
        SM_CYMENUSIZE = 55,
        SM_CYMIN = 29,
        SM_CYMINIMIZED = 58,
        SM_CYMINSPACING = 48,
        SM_CYMINTRACK = 35,
        SM_CYSCREEN = 1,
        SM_CYSIZE = 31,
        SM_CYSIZEFRAME = 33,
        SM_CYSMCAPTION = 51,
        SM_CYSMICON = 50,
        SM_CYSMSIZE = 53,
        SM_CYVSCROLL = 20,
        SM_CYVTHUMB = 9,
        SM_DBCSENABLED = 42,
        SM_DEBUG = 22,
        SM_MENUDROPALIGNMENT = 40,
        SM_MOUSEPRESENT = 19,
        SM_PENWINDOWS = 41,
        SM_RESERVED1 = 24,
        SM_RESERVED2 = 25,
        SM_RESERVED3 = 26,
        SM_RESERVED4 = 27,
        SM_SECURE = 44,
        SM_SHOWSOUNDS = 70,
        SM_SLOWMACHINE = 73,
        SM_SWAPBUTTON = 23,
        SM_XVIRTUALSCREEN = 76,
        SM_YVIRTUALSCREEN = 77,
        SM_CXVIRTUALSCREEN = 78,
        SM_CYVIRTUALSCREEN = 79,
        SM_CMONITORS = 80,
        SM_SAMEDISPLAYFORMAT = 81,
        SM_IMMENABLED = 82,
        SM_REMOTESESSION = 4096,
        SM_SHUTTINGDOWN = 8192,
        SM_REMOTECONTROL = 8193,
        SM_CARETBLINKINGENABLED = 8194
    }

    [Flags]
    public enum UFlags
    {
        SWP_ASYNCWINDOWPOS = 0x4000,
        SWP_DEFERERASE = 0x2000,
        SWP_DRAWFRAME = 0x0020,
        SWP_FRAMECHANGED = 0x0020,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOACTIVATE = 0x0010,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOMOVE = 0x0002,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOREDRAW = 0x0008,
        SWP_NOREPOSITION = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_NOSIZE = 0x0001,
        SWP_NOZORDER = 0x0004,
        SWP_SHOWWINDOW = 0x0040
    }

    public const uint CF_TEXT = 1;
    public const uint CF_UNICODETEXT = 13;

    public const uint SRCCOPY = 0x00CC0020;
    public const int CAPTUREBLT = 0x40000000;

    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern IntPtr SetWindowPos(
        IntPtr hWnd,
        HwndInsertAfter hWndInsertAfter,
        int x,
        int Y,
        int cx,
        int cy,
        UFlags wFlags
    );

    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll")]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("kernel32.dll")]
    public static extern uint GetProcessIdOfThread(IntPtr ThreadHandle);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("kernel32.dll")]
    public static extern bool GetExitCodeProcess(IntPtr hProcess, out uint lpExitCode);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, NCmdShow nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool BringWindowToTop(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool IsWindow(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern int GetLastError();

    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(SystemMetrics nIndex);

    [DllImport("user32.dll")]
    public static extern bool CloseClipboard();

    [DllImport("user32.dll")]
    public static extern bool OpenClipboard(IntPtr WndNewOwner);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetClipboardData(uint uFormat);

    [DllImport("user32.dll", SetLastError = false)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsClipboardFormatAvailable(uint uFormat);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GlobalLock(IntPtr hMem);

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GlobalUnlock(IntPtr hMem);

    [DllImport("user32.dll")]
    public static extern bool CloseWindow(IntPtr hwnd);

    [DllImport("user32.dll")]
    public static extern bool DestroyWindow(IntPtr hwnd);

    [DllImport("user32.dll")]
    public static extern long FindWindowA(string lpClassName, string lpWindowName);

    [DllImport("kernel32.dll")]
    public static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(
        ProcessAccessRights dwDesiredAccess,
        bool bInheritHandle,
        int dwProcessId
    );

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    [DllImport("gdi32.dll")]
    public static extern uint GetPixel(IntPtr hdc, int x, int y);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDC(IntPtr hwnd);

    [DllImport("user32.dll")]
    public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

    [DllImportAttribute("gdi32.dll")]
    public static extern bool BitBlt(
        IntPtr hdcDest,
        int nXDest,
        int nYDest,
        int nWidth,
        int nHeight,
        IntPtr hdcSrc,
        int nXSrc,
        int nYSrc,
        uint dwRop
    );

    [DllImport("user32.dll")]
    public static extern int ReleaseDC(IntPtr hWnd, int hDC);

    [DllImport("gdi32.dll")]
    public static extern int CreateCompatibleDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    public static extern int CreateCompatibleBitmap(IntPtr hdc, int width, int height);

    [DllImport("gdi32.dll")]
    public static extern int SelectObject(IntPtr hdc, IntPtr hObject);

    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);

    [DllImport("gdi32.dll")]
    public static extern bool DeleteDC(IntPtr hdc);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDesktopWindow();

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct tagKEYBDINPUT
    {
        public long dx;
        public long dy;
        public IntPtr mouseData;
        public MouseEventFlags dwFlags;
        public IntPtr time;
        public ulong dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct tagHARDWAREINPUT
    {
        private IntPtr uMsg;
        private IntPtr wParamL;
        private IntPtr wParamH;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct tagMOUSEINPUT
    {
        public int dx;
        public int dy;
        public int mouseData;
        public MouseEventFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT
    {
        [FieldOffset(0)] public INPUT_TYPE type;

        [FieldOffset(4)] public tagMOUSEINPUT MOUSEINPUT;

        [FieldOffset(4)] public tagKEYBDINPUT KEYBDINPUT;

        [FieldOffset(4)] public tagHARDWAREINPUT HARDWAREINPUT;
    }
}