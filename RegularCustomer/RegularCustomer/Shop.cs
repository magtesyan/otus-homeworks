using System.Collections.ObjectModel;

namespace RegularCustomer
{
    class Shop
    {
        public ObservableCollection<Item> ItemsList = [];

        private static int Id = 0;
        public void Add() 
        {
            ItemsList.Add(new Item(Id, $"Товар от {DateTime.Now}"));
            Id += 1;
        }
        public void Remove(int id) 
        {
            Item selectedItem = ItemsList.Single(item => item.Id == id);
            if (selectedItem != null)
            {
                ItemsList.Remove(selectedItem);
            }
        }

        public Shop()
        {
            ItemsList.CollectionChanged += Customer.OnItemChanged;
        }
    }
}
