namespace gui_tesing_library.Components;

public class GTProcess : IGTProcess
{
    private readonly GTProcess_CS gTProcess_CS;

    public GTProcess(GTProcess_CS gTProcess_CS)
    {
        this.gTProcess_CS = gTProcess_CS;
    }

    public string Name => gTProcess_CS.GetName();
    public bool IsAlive => gTProcess_CS.IsAlive();


    public long GetRamUsage()
    {
        return gTProcess_CS.GetRamUsage();
    }

    public void kill()
    {
        gTProcess_CS.kill();
    }
}