using System.Collections.Generic;

namespace gui_tesing_library
{
    public interface IGTProcess
    {
        string Name { get; }
        bool IsAlive { get; }
        IEnumerable<IGTWindow> GetWindowsOfProcess();
        long GetRamUsage();
        void kill();
    }
}