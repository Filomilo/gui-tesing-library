using GregsStack.InputSimulatorStandard;
using gui_tesing_library.Controllers;
using gui_tesing_library.Interfaces;
using gui_tesing_library.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Color = gui_tesing_library.Models.Color;
namespace gui_tesing_library.SystemCalls
{
    public class WindowsSystemCalls : ISystemCalls
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
            if (WinApiWrapper.GetExitCodeProcess(new IntPtr(handle), out exitCode))
            {
                return exitCode == 259; // STILL_ACTIVE;
            }
            return false;
        }

        public void TerminateProcess(int handle)
        {
            WinApiWrapper.TerminateProcess(new IntPtr(handle), 0);
        }

        public int FindWindowByName(string name)
        {
            return (int)WinApiWrapper.FindWindowA(null, name);
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
            return new Vector2i(rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        public void CloseWindow(int handle)
        {
            WinApiWrapper.CloseWindow(new IntPtr(handle));
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
            IntPtr processHandle = WinApiWrapper.OpenProcess(
                WinApiWrapper.ProcessAccessRights.PROCESS_QUERY_INFORMATION
                    | WinApiWrapper.ProcessAccessRights.PROCESS_VM_READ
                    | WinApiWrapper.ProcessAccessRights.PROCESS_TERMINATE,
                false,
                id
            );
            return processHandle.ToInt32();
        }

        public void MinimizeWindow(int handle)
        {
            WinApiWrapper.ShowWindow(new IntPtr(handle), WinApiWrapper.NCmdShow.SW_MINIMIZE);
        }

        public bool IsWindowsMinimized(int handle)
        {
            return WinApiWrapper.IsIconic(new IntPtr(handle));
        }

        public void BringWindowUpFront(int handle)
        {
            WinApiWrapper.ShowWindow(new IntPtr(handle), WinApiWrapper.NCmdShow.SW_RESTORE);
            bool returnVal = WinApiWrapper.ShowWindow(new IntPtr(handle), WinApiWrapper.NCmdShow.SW_SHOW);
            WinApiWrapper.SetWindowPos(
                new IntPtr(handle),
                WinApiWrapper.HwndInsertAfter.HWND_TOPMOST,
                0,
                0,
                0,
                0,
                WinApiWrapper.UFlags.SWP_NOMOVE | WinApiWrapper.UFlags.SWP_NOSIZE
            );
            WinApiWrapper.BringWindowToTop(new IntPtr(handle));
        }

        public void MaximizeWindow(int handle)
        {
            WinApiWrapper.ShowWindow(new IntPtr(handle), WinApiWrapper.NCmdShow.SW_SHOWMAXIMIZED);
        }

        public Vector2i GetMaximizedWindowSize()
        {
            return new Vector2i(
                WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXMAXIMIZED),
                WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYMAXIMIZED)
            );
        }

        public void SetWindowPostion(int handle, Vector2i vector2i)
        {
            WinApiWrapper.SetWindowPos(
                new IntPtr(handle),
                0,
                vector2i.x,
                vector2i.y,
                0,
                0,
                    WinApiWrapper.UFlags.SWP_NOSIZE
            );
        }

        public void SetWindowSize(int handle, Vector2i vector2i)
        {
            WinApiWrapper.SetWindowPos(
                new IntPtr(handle),
                0,
                0,
                0,
                vector2i.x,
                vector2i.y,
                 WinApiWrapper.UFlags.SWP_NOMOVE
            );
        }

        public void SetMousePostion(Vector2i position)
        {
            WinApiWrapper.SetCursorPos(position.x, position.y);
        }

        public Vector2i GetMousePosition()
        {
            WinApiWrapper.GetCursorPos(out WinApiWrapper.POINT pos);
            return new Vector2i((int)pos.x, (int)pos.y);
        }

        public string GetWindowName(int handle)
        {
            StringBuilder stringBuilder = new StringBuilder();
            WinApiWrapper.GetWindowText(new IntPtr(handle), stringBuilder, 512);
            return stringBuilder.ToString();
        }

        void ISystemCalls.ClickLeft()
        {
            _inputSimulator.Mouse.LeftButtonClick();
        }

        public void ClickMiddle()
        {
            _inputSimulator.Mouse.XButtonClick(0x0010);
        }

        public void ClickRight()
        {
            _inputSimulator.Mouse.RightButtonClick();
        }

        public void PressLeft()
        {
            _inputSimulator.Mouse.LeftButtonDown();
        }

        public void PressMiddle()
        {
            _inputSimulator.Mouse.XButtonDown(0x0010);
        }

        public void PressRight()
        {
            _inputSimulator.Mouse.RightButtonDown();
        }

        public void ReleaseLeft()
        {
            _inputSimulator.Mouse.LeftButtonUp();
        }

        public void ReleaseMiddle()
        {
            _inputSimulator.Mouse.XButtonUp(0x0010);
        }

        public void ReleaseRight()
        {
            _inputSimulator.Mouse.RightButtonUp();
        }

        public void Scroll(int scrollValue)
        {
            _inputSimulator.Mouse.VerticalScroll(scrollValue);
        }

        public int GetWindowTitleBarHeight()
        {
            return WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYCAPTION);
        }

        public int GetWindowBorderWidth()
        {
            return WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXFRAME);
        }

        public int GetWindowBorderHeight()
        {
            return WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYFRAME);
        }

        public int GetWindowPadding()
        {
            return WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXPADDEDBORDER);
        }

        public ScreenShot GetScreenShotFromHandle(int handle, Vector2i StartPosition, Vector2i Size)
        {
            IntPtr hdcScreen = WinApiWrapper.GetDC(new IntPtr(handle));
            int hdcMemDC = WinApiWrapper.CreateCompatibleDC(hdcScreen);

            int hBitmap = WinApiWrapper.CreateCompatibleBitmap(hdcScreen, Size.x, Size.y);
            int hOld = WinApiWrapper.SelectObject(new IntPtr(hdcMemDC), new IntPtr(hBitmap));

            bool res = WinApiWrapper.BitBlt(
                new IntPtr(hdcMemDC),
                StartPosition.x,
                StartPosition.y,
                Size.x,
                Size.y,
                hdcScreen,
                0,
                0,
                WinApiWrapper.SRCCOPY
            );

            if (!res)
            {
                WinApiWrapper.SelectObject(new IntPtr(hdcMemDC), new IntPtr(hOld));
                WinApiWrapper.DeleteObject(new IntPtr(hBitmap));
                WinApiWrapper.DeleteDC(new IntPtr(hdcMemDC));
                WinApiWrapper.ReleaseDC(new IntPtr(handle), hdcScreen);
                throw new InvalidOperationException("BitBlt failed");
            }

            Bitmap bitmap = null;
            try
            {
                bitmap = Image.FromHbitmap(new IntPtr(hBitmap));
            }
            catch (Exception e)
            {
                WinApiWrapper.SelectObject(new IntPtr(hdcMemDC), new IntPtr(hOld));
                WinApiWrapper.DeleteObject(new IntPtr(hBitmap));
                WinApiWrapper.DeleteDC(new IntPtr(hdcMemDC));
                WinApiWrapper.ReleaseDC(new IntPtr(handle), hdcScreen);
                int error = Marshal.GetLastWin32Error();
                throw new InvalidOperationException($"Marshal copy error code: {error} -- {e.Message}");
            }

            WinApiWrapper.SelectObject(new IntPtr(hdcMemDC), new IntPtr(hOld));
            WinApiWrapper.DeleteObject(new IntPtr(hBitmap));
            WinApiWrapper.ReleaseDC(IntPtr.Zero, hdcScreen);
            WinApiWrapper.ReleaseDC(IntPtr.Zero, hdcMemDC);

            return new ScreenShot(bitmap);
        }

        public Vector2i GetScreenSize()
        {
            return new Vector2i(
                WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXSCREEN),
                WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYSCREEN)
            );
        }

        public Models.Color GetPixelColorAt(Vector2i postion, int handle)
        {
            IntPtr hdc = WinApiWrapper.GetDC(new IntPtr(handle));
            uint pixel = WinApiWrapper.GetPixel(hdc, postion.x, postion.y);
            WinApiWrapper.ReleaseDC(new IntPtr(handle), hdc);

            int red = (int)(pixel & 0x000000FF);
            int green = (int)((pixel & 0x0000FF00) >> 8);
            int blue = (int)((pixel & 0x00FF0000) >> 16);

            return new Color(red, green, blue);
        }

        public void MoveMouse(Vector2i offset)
        {
            _inputSimulator.Mouse.MoveMouseBy(offset.x, offset.y);
        }

        public void MoveMouseTo(Vector2i newPos)
        {
            //Vector2f aboslutePostion =
            //    new Vector2f((newPos.x * 65535f / WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CXSCREEN)),
            //        (newPos.y * 65535f / WinApiWrapper.GetSystemMetrics(WinApiWrapper.SystemMetrics.SM_CYSCREEN)));
            //aboslutePostion = new Vector2f(newPos.x, newPos.y);
            _inputSimulator.Mouse.MoveMouseTo(
                newPos.x, newPos.y
            );
        }

        public void TypeText(string text)
        {
            _inputSimulator.Keyboard.TextEntry(text);
        }

        public void ClickKey(Key key)
        {
            _inputSimulator.Keyboard.KeyPress(DataMapper.KeyToVirtualKey(key));
        }

        public void ReleaseKey(Key key)
        {
            _inputSimulator.Keyboard.KeyUp(DataMapper.KeyToVirtualKey(key));
        }

        public void PressKey(Key key)
        {
            _inputSimulator.Keyboard.KeyDown(DataMapper.KeyToVirtualKey(key));
        }

        public string GetClipBoardData()
        {
            string text = "";

            if (WinApiWrapper.IsClipboardFormatAvailable(WinApiWrapper.CF_UNICODETEXT))
            {
                if (WinApiWrapper.OpenClipboard(IntPtr.Zero))
                {
                    var data = WinApiWrapper.GetClipboardData(WinApiWrapper.CF_UNICODETEXT);
                    if (data != IntPtr.Zero)
                    {
                        data = WinApiWrapper.GlobalLock(data);
                        text = Marshal.PtrToStringUni(data);
                        WinApiWrapper.GlobalUnlock(data);
                        return text;
                    }
                }
            }

            WinApiWrapper.CloseClipboard();

            return "";
        }
    }
}
