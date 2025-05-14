using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace gui_tesing_library.Components
{
    public class GTProcess : IGTProcess
    {
        private GTProcess_CS gTProcess_CS;

        public GTProcess(GTProcess_CS gTProcess_CS)
        {
            this.gTProcess_CS = gTProcess_CS;
        }

        public string Name
        {
            get
            {
                return gTProcess_CS.GetName();
            }
        }
        public bool IsAlive { get { return gTProcess_CS.IsAlive(); } }

        public IEnumerable<IGTWindow> GetWindowsOfProcess()
        {
           return gTProcess_CS.GetWindowsOfProcess().Select(x=>new GTWindow(x));
        }

        public long GetRamUsage()
        {
            return gTProcess_CS.GetRamUsage();
        }

        public void kill()
        {
            gTProcess_CS.kill();
        }
    }
}
