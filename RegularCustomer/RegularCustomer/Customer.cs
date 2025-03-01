using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace RegularCustomer
{
    class Customer
    {
        public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"ADDED: new item with id: {Formatted(e.NewItems)}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"REMOVE: deleted items = {Formatted(e.OldItems)}");
                    break;
            }
        }

        private static string Formatted(IList? values)
        {
            if (values == null || values[0] == null)
            {
                return "";
            }
            return $"{((Item)values[0]).Id}";
        }
    }
}
