using Librarian;

Library Library = new();

while (true)
{
    Console.WriteLine("\n1 - добавить книгу\n2 - вывести список\n3 - выйти\n");
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

    if (keyInfo.KeyChar == '1')
    {
        Console.WriteLine("Введите название книги\n");
        string bookName = Console.ReadLine() ?? "";
        if (!Library.Contains(bookName))
        {
            Library.Add(bookName);
        }
    }
    if (keyInfo.KeyChar == '2')
    {
        foreach (var book in Library.BooksList)
        {
            Console.WriteLine($"{book.Key} - {book.Value}%");
        }
    }
    if (keyInfo.KeyChar == '3')
        break;
}