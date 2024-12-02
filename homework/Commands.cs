namespace Homework
{
    public class Commands
    {
        public const string Start = "/start";
        public const string Info = "/info";
        public const string Help = "/help";
        public const string Echo = "/echo";
        public const string AddTask = "/addtask";
        public const string ShowTask = "/showtask";
        public const string RemoveTask = "/removetask";
        public const string Exit = "/exit";

        public static readonly string[] availableWithoutNameCommands = [Start, Info, Help, Exit];
        public static readonly string[] availableWithNameCommands = [Info, Help, Echo, AddTask, ShowTask, RemoveTask, Exit];

        public static void PrintAvailableCommands(bool hasName)
        {
            string[] availableCommands = hasName ? availableWithNameCommands : availableWithoutNameCommands;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Join(" ", availableCommands));
            Console.ResetColor();
        }

        public static void PrintNotAvailableCommandError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Такой команды нет в списке доступных!");
            Console.ResetColor();
        }
    }
}
