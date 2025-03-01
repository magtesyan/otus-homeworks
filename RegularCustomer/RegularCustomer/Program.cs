using RegularCustomer;
using static System.Runtime.InteropServices.JavaScript.JSType;

Shop Store = new();
Customer Mikael = new();


while (true)
{
    Console.WriteLine("\nA - добавить товар\nD - удалить товар\nX - завершить программу\n");
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

    if (keyInfo.KeyChar == 'A')
    {
        Store.Add();
    }
    if (keyInfo.KeyChar == 'D')
    {
        if (Store.ItemsList.Count == 0)
        {
            Console.WriteLine("\nИзвините, все раскупили\n");
        } 
        else
        {
            Console.WriteLine("\nНапишите идентификатор товара, который нужно удалить.\n");
            foreach (var item in Store.ItemsList)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }
            var idEntered = Console.ReadLine();
            bool isIdValid = Int32.TryParse(idEntered, out int idToDelete);
            if (isIdValid)
            {
                try
                {
                    Store.Remove(idToDelete);
                }
                catch
                {
                    Console.WriteLine("Нет товара с таким идентификатором");
                }
            }
        }
    }
    if (keyInfo.KeyChar == 'X')
        break;

}