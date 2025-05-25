namespace GuiTestingLibrary_Tets;

public class Configuration
{
    public static long _ProcesAwaitTime = 1000;

    public static long ProcesAwaitTime
    {
        get => _ProcesAwaitTime;
        set => _ProcesAwaitTime = value;
    }
}
