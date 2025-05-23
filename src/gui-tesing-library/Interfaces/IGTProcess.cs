using System.Collections.Generic;

namespace gui_tesing_library
{
    public interface IGTProcess
    {
        string Name { get; }
        bool IsAlive { get; }
        long GetRamUsage();
        void kill();
    }
}