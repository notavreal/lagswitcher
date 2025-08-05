using System.Diagnostics;
class InternetController

{
    public static void Disable() => ToggleInternet(false);
    public static void Enable() => ToggleInternet(true);

    private static void ToggleInternet(bool enable)
    {
        string command = enable ?
        $"Enable-NetAdapter -Name \"Ethernet\" -Confirm:$false" :
        $"Disable-NetAdapter -Name \"Ethernet\" -Confirm:$false";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                Verb = "runas",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }
        };
        process.Start();
        process.WaitForExit();
    }
}