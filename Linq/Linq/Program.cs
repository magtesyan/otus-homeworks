namespace Linq
{
    internal static class Program
    {
        private static readonly int[] _arr = [ 1, 2, 3, 4, 5 ];
        private static readonly Person[] _persons = [
                new() { Name = "Alice", Age = 25 },
                new() { Name = "Bob", Age = 32 },
                new() { Name = "Charlie", Age = 19 },
                new() { Name = "Diana", Age = 27 },
                new() { Name = "Eve", Age = 21 },
        ];

        static void Main()
        {
            var changedArr = _arr.Top(40);
            var changedPersons = _persons.Top(41, person => person.Age);

            foreach (int item in changedArr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n-");
            foreach (Person item in changedPersons)
            {
                Console.Write($"{item.Name}-{item.Age} ");
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
        {
            return collection.Where((value, index) => index < count);
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int percent)
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent), "Значение должно быть в диапазоне от 1 до 100");
            }

            double itemsCount = collection.Count() * percent / 100.0;
            int itemsCountRounded = (int)Math.Ceiling(itemsCount);
            IEnumerable<T> sortedDescending = collection.OrderByDescending(x => x);

            return sortedDescending.Take(itemsCountRounded);
        }

        public static IEnumerable<T> Top<T, V>(this IEnumerable<T> collection, int percent, Func<T, V> filter)
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent), "Значение должно быть в диапазоне от 1 до 100");
            }

            double itemsCount = collection.Count() * percent / 100.0;
            int itemsCountRounded = (int)Math.Ceiling(itemsCount);
            IEnumerable<T> sortedDescending = collection.OrderByDescending(filter);

            return sortedDescending.Take(itemsCountRounded);
        }
    }
}
