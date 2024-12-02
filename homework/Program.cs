
namespace Homework
{
    internal class Program
    {
        static void Main()
        {
            string enteredCommand = "";
            string name = "";

            PrintGreeting(name, []);
            while (enteredCommand != Commands.Exit)
            {
                enteredCommand = Console.ReadLine() ?? "";

                if (name != "" && enteredCommand.StartsWith(Commands.Echo))
                {
                    Console.WriteLine(enteredCommand.Substring(Commands.Echo.Length + 1));
                    PrintGreeting(name, []);
                    continue;
                }

                switch (enteredCommand)
                {
                    case Commands.Start:
                        if (name == "")
                        {
                            Console.Write("\nВведите ваше имя: ");
                            name = Console.ReadLine() ?? "";
                        }
                        else
                        {
                            Console.WriteLine("\nПрограмма уже запущена");
                        }
                        PrintGreeting(name, []);
                        break;
                    case Commands.Info:
                        PrintInfo();
                        PrintGreeting(name, []);
                        break;
                    case Commands.Help:
                        PrintHelp();
                        PrintGreeting(name, []);
                        break;
                    case Commands.Exit:
                        break;
                    default:
                        Commands.PrintNotAvailableCommandError();
                        break;
                }
            }
        }

        private static void PrintGreeting(string name, string[] commands)
        {
            bool hasName = name != "";
            string nameOrHello = hasName ? $"{name}" : "Привет";
            Console.WriteLine($"{nameOrHello}, введите команду из списка доступных:");
            Commands.PrintAvailableCommands(hasName);
        }



        private static void PrintInfo()
        {
            Console.WriteLine("v.1.0, Release: 18.11.2024\n");
        }

        private static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/start");
            Console.ResetColor();
            Console.WriteLine(" - Начало программы, нужно будет ввести свое имя");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/info");
            Console.ResetColor();
            Console.WriteLine(" - предоставляет информацию о версии программы и дате её создания");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/echo");
            Console.ResetColor();
            Console.WriteLine(" - При вводе этой команды с аргументом, программа возвращает введенный текст");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/exit");
            Console.ResetColor();
            Console.WriteLine(" - Выход\n");
        }
    }
}
