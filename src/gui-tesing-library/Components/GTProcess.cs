using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_tesing_library.Components
{
    public class GTProcess : IGTProcess
    {
        private GTProcess_CS gTProcess_CS;

        public GTProcess(GTProcess_CS gTProcess_CS)
        {
            this.gTProcess_CS = gTProcess_CS;
        }

        public string Name { get; }
        public bool IsAlive { get; }

        public IEnumerable<IGTWindow> GetWindowsOfProcess()
        {
            throw new NotImplementedException();
        }

        public long GetRamUsage()
        {
            throw new NotImplementedException();
        }

        public void kill()
        {
            throw new NotImplementedException();
        }
    }
}
