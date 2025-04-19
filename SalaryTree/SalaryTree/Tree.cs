namespace SalaryTree
{
    public class Tree
    {
        private Node? _root;

        public void Insert(string name, int salary)
        {
            Node newNode = new(name, salary);
            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                InsertRecursive(_root, newNode);
            }
        }

        private static void InsertRecursive(Node root, Node newNode)
        {
            if (newNode.Salary < root.Salary)
            {
                if (root.Left == null)
                    root.Left = newNode;
                else
                    InsertRecursive(root.Left, newNode);
            }
            else
            {
                if (root.Right == null)
                    root.Right = newNode;
                else
                    InsertRecursive(root.Right, newNode);
            }
        }

        private static void DisplayTree(Node node)
        {
            if (node == null) return;
            if (node.Left != null)
            {
                DisplayTree(node.Left);
            }
            Console.WriteLine(node.Salary + " " + node.Name);
            if (node.Right != null)
            {
                DisplayTree(node.Right);
            }
        }

        public void DisplayTree()
        {
            if (_root == null) return;
            DisplayTree(_root);
        }

        private static string Find(Node node, int neededSalary)
        {
            if (node.Salary == neededSalary) return node.Name;
            if (node.Salary > neededSalary && node.Left != null) return Find(node.Left, neededSalary);
            if (node.Salary < neededSalary && node.Right != null) return Find(node.Right, neededSalary);

            return "Nobody";
        }

        public void Find(int neededSalary)
        {
            if (_root == null) return;
            Console.WriteLine(Find(_root, neededSalary) + " has this salary\n");
        }
    }
}
