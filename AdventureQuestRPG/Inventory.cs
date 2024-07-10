using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventureQuestRPG
{
    public class Inventory
    {
        public List<Item> Items;
        public Inventory()
        {
            Items = new List<Item>();
        }

        public void addItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($" ** The {item.Name} has been added to player inventory");
        }

        public void removeItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            else
            {
                Console.WriteLine("Item not found in your inventory.");
            }
        }

        public void displayInventory()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Your Inventory Is Empty");
                return;
            }
            int count = 1;
            Console.WriteLine("Your Inventory has:");
            foreach (var item in Items)
            {
                Console.WriteLine($"{count++}- Name: {item.Name}, Description: {item.Description}");
            }
            Console.WriteLine("Please select an item by entering its number:");
        }
    }
}