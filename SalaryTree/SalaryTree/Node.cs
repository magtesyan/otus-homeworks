namespace SalaryTree
{
    public class Node(string name, int salary)
    {
        public int Salary { get; set; } = salary;
        public string Name { get; set; } = name;
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }
}
