
namespace Homework
{
    internal class Program
    {
        static void Main()
        {
            string enteredCommand = "";
            string name = "";

            PrintGreeting(name);
            while (enteredCommand != Commands.Exit)
            {
                enteredCommand = Console.ReadLine() ?? "";

                if (name != "" && enteredCommand.StartsWith(Commands.Echo))
                {
                    Console.WriteLine(enteredCommand[(Commands.Echo.Length)..].Trim());
                    PrintGreeting(name);
                    continue;
                }

                if (name == "" && !Commands.availableWithoutNameCommands.Contains(enteredCommand))
                {
                    Commands.PrintNotAvailableCommandError();
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
                        PrintGreeting(name);
                        break;
                    case Commands.Info:
                        PrintInfo();
                        PrintGreeting(name);
                        break;
                    case Commands.Help:
                        PrintHelp();
                        PrintGreeting(name);
                        break;
                    case Commands.AddTask:
                        Tasks.AddToTaskList();
                        PrintGreeting(name);
                        break;
                    case Commands.ShowTask:
                        Tasks.ShowTaskList();
                        PrintGreeting(name);
                        break;
                    case Commands.RemoveTask:
                        Tasks.RemoveTaskFromList();
                        PrintGreeting(name);
                        break;
                    case Commands.Exit:
                        break;
                    default:
                        Commands.PrintNotAvailableCommandError();
                        break;
                }
            }
        }

        private static void PrintGreeting(string name)
        {
            bool hasName = name != "";
            string nameOrHello = hasName ? $"{name}" : "Привет";
            Console.WriteLine($"\n{nameOrHello}, введите команду из списка доступных:");
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
            Console.WriteLine(" - Предоставляет информацию о версии программы и дате её создания");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/echo");
            Console.ResetColor();
            Console.WriteLine(" - При вводе этой команды с аргументом, программа возвращает введенный текст");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/addtask");
            Console.ResetColor();
            Console.WriteLine(" - Предоставляет возможность добавить задачу с описанием в список");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/showtask");
            Console.ResetColor();
            Console.WriteLine(" - Показывает список добавленных задач");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/removetask");
            Console.ResetColor();
            Console.WriteLine(" - Удаляет задачу с указанным номером");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("/exit");
            Console.ResetColor();
            Console.WriteLine(" - Выход\n");
        }
    }
}
