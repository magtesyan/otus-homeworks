namespace Classes
{
    internal class Program
    {
        static void Main()
        {
            var s = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
        }
    }
}
