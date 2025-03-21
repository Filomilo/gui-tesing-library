using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lombok.NET;
using static gui_tesing_library.WinApiWrapper;

namespace gui_tesing_library.Components
{
    [AllArgsConstructor]
    [With]
    public class GTProcess
    {
        private Process _Process;
        public int ProcesId
        {
            get { return this._Process.Id; }
        }

        public int kill()
        {
            this._Process.Kill();
            Helpers.AwaitTrue(() =>
            {
                return this._Process.HasExited;
            });
            return 0;
            // add exception handling
        }

        public GTProcess(Process process)
        {
            this._Process = process;
        }

        public List<GTWindow> getPrcoessWindow()
        {
            
            List<IntPtr> windowHandles = new List<IntPtr>();
            Console.WriteLine($"This Peocesss: {this.ProcesId}");
            WinApiWrapper.EnumWindows((hwnd, param) =>
               {

                   StringBuilder title = new StringBuilder(256);
                   WinApiWrapper.GetWindowText(hwnd, title, title.Capacity);

                   if (title.Length > 0) // Ignore empty titles
                   {
                       Console.WriteLine($"Window Handle: {hwnd}, Title: {title}");
                   }

                   GetWindowThreadProcessId(hwnd, out uint parentProcessId);

                   Console.WriteLine($"Window Handle: {hwnd}, Process ID: {parentProcessId}");

                   return true; // Continue enumeration
               }, IntPtr.Zero);



               return null;

        }

    }
}
