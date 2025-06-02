using System;

namespace gui_tesing_library_CS.Controllers;

public static class ErrorController
{
    public static void Throw(Exception ex)
    {
        Console.WriteLine($"Exception occured: [{ex.Message}]");
        throw ex;
    }

    public static void Throw(string s, Exception ex)
    {
        Console.WriteLine($"{s}: [{ex.Message}]");
        throw ex;
    }
}