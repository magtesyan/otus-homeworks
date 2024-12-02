namespace Homework
{
    public class Tasks
    {
        public static readonly List<string> TaskList = [];

        public static void AddToTaskList()
        {
            Console.Write("\nВведите описание задачи: ");
            var description = Console.ReadLine() ?? "";
            TaskList.Add(description);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nЗадача добавлена! ");
            Console.ResetColor();
        }

        public static void ShowTaskList()
        {
            if (TaskList.Count == 0)
            {
                Console.WriteLine("\nСписок задач пуст");
                return;
            }

            Console.WriteLine("------------------------------");
            for (var i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {TaskList[i]}");
            }
            Console.WriteLine("------------------------------");
        }

        public static void RemoveTaskFromList()
        {
            ShowTaskList();
            if (TaskList.Count == 0)
            {
                return;
            }

            var removeTaskIndex = 0;
            var parsedTaskIndex = 0;

            while (removeTaskIndex == 0)
            {
                Console.Write("\nВведите номер задачи для удаления: ");
                var enteredIndex = Console.ReadLine() ?? "0";
                if (!int.TryParse(enteredIndex, out parsedTaskIndex) || parsedTaskIndex > TaskList.Count || parsedTaskIndex < 1)
                {
                    Console.Write("\nТакой номер задачи отсутствует");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nЗадача {TaskList[parsedTaskIndex - 1]} удалена! ");
                    Console.ResetColor();
                    TaskList.RemoveAt(parsedTaskIndex - 1);
                    removeTaskIndex = parsedTaskIndex;
                }
            }
        }
    }
}
