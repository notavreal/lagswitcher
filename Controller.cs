using System.Diagnostics;
using System.Threading;

public class InternetController
{
    public static void DisableInternet()
    {
        ExecuteNetshCommand("disable");
    }

    public static void EnableInternet()
    {
        ExecuteNetshCommand("enable");
    }

    private static void ExecuteNetshCommand(string action)
    {
        var process = new Process
        {
            StartInfo = 
            {
                FileName = "netsh",
                Arguments = $"interface set interface \"Ethernet\" {action}",
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas"
            }
        };
        
        process.Start();
        process.WaitForExit();
        
        if (process.ExitCode != 0)
            throw new Exception($"Ошибка (код: {process.ExitCode}). Запустите от имени администратора!");
    }
}