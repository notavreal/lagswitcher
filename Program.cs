using System.Diagnostics;
using System.Reflection;
using System;

class Program
{
    private static ConsoleKey _bindedKey;

    private static void Main(string[] args)
    {
        Console.Title = "Lag Switcher";
        
        Console.WriteLine($"Lag Switcher {Assembly.GetExecutingAssembly().GetName().Version} by niger");
        Console.WriteLine("Press a key which you want to bind ur lag switcher to: ");

    keyinfomark:
        try
        {
            _bindedKey = Console.ReadKey(true).Key;
            Console.WriteLine($"\nNew bind: {_bindedKey}");
        }
        catch
        {
            Console.WriteLine("\nInvalid key. Press a other key:");
            goto keyinfomark;
        }


    timestampmark:
        Console.WriteLine("Time of network sleep: (In seconds)");
        int time;
        try { time = Convert.ToInt32(Console.ReadLine()); }
        catch { Console.WriteLine("\n Invalid type format. Write other time:"); goto timestampmark; }

        time *= 1000;

        if (time < 0)
        {
            Console.WriteLine("\nTime can`t be negative. Write other time:");
            goto timestampmark;
        }
        Console.WriteLine("Press escape to exit...");

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                InternetController.Enable();
                break;
            }

            if (key == _bindedKey)
            {
                try
                {
                    InternetController.Disable();
                    Thread.Sleep(time);
                    InternetController.Enable();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    InternetController.Enable();
                }
            }
        }
    }
}