    using System.Collections.Concurrent;

    namespace Librarian
    {
        public class Library
        {
            public ConcurrentDictionary<string, int> BooksList = new();

            public Library()
            {
                Task.Run(UpdateBooksProgress);
            }

            public void Add(string name)
            {
                BooksList.TryAdd(name, 0);
            }

            public bool Contains(string name)
            {
                return BooksList.ContainsKey(name);
            }

            private void UpdateBooksProgress()
            {
                while (true)
                {
                    foreach (var book in BooksList)
                    {
                        BooksList.AddOrUpdate(book.Key, 0, (key, value) => book.Value < 100 ? book.Value + 1 : 100);
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
