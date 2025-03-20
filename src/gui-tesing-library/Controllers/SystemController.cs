﻿using gui_tesing_library.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library
{
     public class SystemController
    {
        private static readonly SystemController _instance = new SystemController();
        private SystemController() { }
        public static SystemController Instance => _instance;

        public OperatingSystem GetOSVersion()
        {
            return Environment.OSVersion;
        }

        public GTProcess StartProcess(string v)
        {
            GTProcess gtProcess = new GTProcess(WinApiWrapper.CreateProcess(v));
            return gtProcess;
        }

        public GTWindow GetWindowByName(string name)
        {
            GTWindow window = null;
            WinApiWrapper.EnumWindows((hwnd, param) =>
            {

                StringBuilder title = new StringBuilder(256);
                WinApiWrapper.GetWindowText(hwnd, title, title.Capacity);
                Console.WriteLine($"Window Handle: {hwnd}, Title: {title}");
                if (title.Length > 0 && name==title.ToString())
                {
          
                    window=new GTWindow(hwnd.ToInt64());
                    return false;
                }

                return true; 
            }, IntPtr.Zero);



            return window;
        }

        
    }
}
