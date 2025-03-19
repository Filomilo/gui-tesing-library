using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lombok.NET;

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
            return 0;
            // add exception handling
        }

        public GTProcess(Process process)
        {
            this._Process = process;
        }
    }
}
