namespace Classes
{
    public class Stack
    {
        public int Size { get; private set; } = 0;

        private class StackItem(StackItem? stackItem, string item)
        {
            public string CurrentString { get; set; } = item;
            public StackItem? PrevItem { get; set; } = stackItem;
        }

        private StackItem? TopItem = null;

        public Stack(params string[] items)
        {
            foreach (string item in items)
            {
                TopItem = new StackItem(TopItem, item);
                Size++;
            }
        }

        public void Add(string item)
        {
            TopItem = new StackItem(TopItem, item);
            Size++;
        }

        public string? Top
        {
            get
            {
                return TopItem?.CurrentString;
            }
        }

        public string? Pop()
        {
            if (Size == 0)
            {
                throw new OverflowException("Стек пустой");
            }

            string? lastElement = Top;
            TopItem = TopItem?.PrevItem;
            Size--;
            return lastElement;
        }

        public static Stack Concat(params Stack[] stacks)
        {
            int stacksCount = stacks.Length;
            Stack stack = new Stack();
            for (int i = stacksCount - 1; i >= 0; i--)
            {
                stack.Merge(stacks[i]);
            }

            return stack;
        }
    }
}
