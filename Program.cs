
using System;
using System.IO;

class Program
{
    static bool isRunning = false;

    static string logFile =
        @"C:\LoggerService\StartStopLog.txt";

    static void Main()
    {
        Directory.CreateDirectory(
            @"C:\LoggerService"
        );

        Console.WriteLine("START/STOP LOGGER SERVICE");
        Console.WriteLine("-------------------------");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Start Logger");
            Console.WriteLine("2. Stop Logger");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartLogger();
                    break;

                case "2":
                    StopLogger();
                    break;

                case "3":
                    Console.WriteLine("Program Closed.");
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void StartLogger()
    {
        if (!isRunning)
        {
            isRunning = true;

            WriteLog("LOGGER STARTED");
        }
        else
        {
            Console.WriteLine("Logger is already running.");
        }
    }

    static void StopLogger()
    {
        if (isRunning)
        {
            isRunning = false;

            WriteLog("LOGGER STOPPED");
        }
        else
        {
            Console.WriteLine("Logger is not running.");
        }
    }

    static void WriteLog(string message)
    {
        string log =
            DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
            + " : " + message;

        File.AppendAllText(
            logFile,
            log + Environment.NewLine
        );

        Console.WriteLine(log);
    }
}
