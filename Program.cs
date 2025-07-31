using System;

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

        // button pressed test хули я вообще на английском пишу 

        while (true)
        {
            var pressedKey = Console.ReadKey(intercept: true);

            // if (pressedKey.Key == ConsoleKey.Escape)
            //     break;

            if (pressedKey.Key == BindKey)
                Console.WriteLine("Действие выполнено!");
            else
                Console.WriteLine("Error");
        }
    }
}