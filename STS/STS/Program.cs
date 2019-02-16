using System;

namespace STS
{
    class Program
    {
        // Global variables
        public static string ApplicationName = "SQL Timing Service";

        static void Main(string[] args)
        {
            
        }

        /* Display the menu */
        private static void DisplayMenu()
        {
            int selectedOption = 0;

            Console.Clear();
            Console.Title = $"{ApplicationName} | Menu";

            Console.WriteLine("STS Menu");
            Console.WriteLine();
            Console.WriteLine("1. Show configuration");
            Console.WriteLine("2. Load configuration");
            Console.WriteLine("3. Edit configuration");
            Console.Write("Select an option: ");

            // Try to parse the option
            if (!int.TryParse(Console.ReadLine(), out selectedOption))
            {
                DisplayError("Seems like an error occurred! Check the error logs for more information");

            }

        }

        #region Console output
        private static void DisplayError(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /* Log the progress on the console screen */
        private static void LogProgress(string text)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"] {text} ...");
        }

        /* Log the confirmation of the progress on the console window */
        private static void LogProgressStatus(bool isSuccess)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" [");
            Console.ForegroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(isSuccess ? "OK" : "FAIL");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("] "); 
        }

        /* Log message with an information tag like this [INFO] */
        private static void LogMessage(string info, LogType type)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = GetColor(type).Item2;
            Console.Write(GetColor(type).Item1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(info);
        }

        /* Return the color of the information tag */
        public static Tuple<string, ConsoleColor> GetColor(LogType type)
        {
            switch (type)
            {
                case LogType.INFO:
                    return Tuple.Create(LogType.INFO.ToString() + " ", ConsoleColor.Cyan);
                case LogType.ERROR:
                    return Tuple.Create(LogType.ERROR.ToString() + " ", ConsoleColor.Red);
                case LogType.STATUS:
                    return Tuple.Create("[+] ", ConsoleColor.White);
                case LogType.RESULT:
                    return Tuple.Create(LogType.RESULT.ToString() + " " , ConsoleColor.Yellow);
                default:
                    return Tuple.Create($"[{DateTime.Now.ToShortTimeString()}] ", ConsoleColor.Magenta);
            }
        }

        public enum LogType
        {
            INFO,
            ERROR,
            STATUS,
            RESULT
        }
        #endregion
    }
}
