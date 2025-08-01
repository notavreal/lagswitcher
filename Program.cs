using System;
using System.Threading;
class Program
{
    static ConsoleKey BindKey;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Lag Switcher 1.0 by notav");
        Console.WriteLine("Press a key which you want to bind ur lag switcher to: ");

        var keyInfo = Console.ReadKey(intercept: true);
        BindKey = keyInfo.Key;
        Console.WriteLine($"\nYou pressed: {BindKey}");
        Console.WriteLine("Time of network sleep: (In milliseconds)");
        int time = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Press escape to break");


        while (true) //Проверка нажатой кнопки zzz
        {
            var pressedKey = Console.ReadKey(intercept: true);

            if (pressedKey.Key == ConsoleKey.Escape)
                break;

            if (pressedKey.Key == BindKey)
            {
                try
                {
                    InternetController.DisableInternet();
                    Thread.Sleep(time);

                    InternetController.EnableInternet();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}