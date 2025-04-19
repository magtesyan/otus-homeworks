
using SalaryTree;

static void AddEmployees(Tree tree)
{
    string name;
    int salary;

    do
    {
        Console.WriteLine("Add employee details");
        Console.Write("Name: ");
        name = Console.ReadLine() ?? "";

        if (name == "")
        {
            Console.WriteLine("\n");
            break;
        }

        Console.Write("Salery: ");
        salary = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("\n");
        tree.Insert(name, salary);

    } while (name != "");

    tree.DisplayTree();
    Console.WriteLine("\n");
}

static void FindSalary(Tree tree)
{
    Console.WriteLine("Add salary to find: ");
    int neededSalary = int.Parse(Console.ReadLine() ?? "");
    tree.Find(neededSalary);
    CallMenu(tree);
}

static void CallMenu(Tree tree)
{
    Console.WriteLine("What do you want?");
    Console.WriteLine("0. Start again");
    Console.WriteLine("1. Find another salary");
    int userChoice = int.Parse(Console.ReadLine() ?? "");

    if (userChoice == 0)
    {
        Tree newTree = new();
        AddEmployees(newTree);
        FindSalary(newTree);
    }

    if (userChoice == 1)
    {
        FindSalary(tree);
    }
}

Tree tree = new();
AddEmployees(tree);
FindSalary(tree);
