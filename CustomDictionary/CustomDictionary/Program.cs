namespace CustomDictionary
{
    internal class Program
    {
        static void Main()
        {
            CustomDictionary dictionary = new();

            dictionary.Add(3, "three");
            dictionary.Add(5, "five");
            dictionary.Add(5, "six");

            dictionary[1] = "index: one";

            Console.WriteLine(dictionary.Get(5));
            Console.WriteLine(dictionary[1]);
        }
    }
}
