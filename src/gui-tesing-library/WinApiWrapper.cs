using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
    }
}
