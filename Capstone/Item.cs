using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone
{
    public class Item
    {
        //public List<Item> items = new List<Item>();

        Dictionary<string, string> typeMessages = new Dictionary<string, string>()
        {
            {"Duck", "Quack, Quack, Splash!" },
            {"Penguin","Squawk, Squawk, Whee!" },
            {"Cat", "Meow, Meow, MEOW!" },
            {"Pony", "Neigh, Neigh, Yay!" }
        };
        public string Name { get; private set; }
        public decimal Price { get; private set; } = 2.50M;
        public string Type { get; private set; }
        public string ID { get; private set; }
        public virtual int Quantity()
        {
        return 0;
        }
        public string Message
        {
            get { return typeMessages[Type]; }
        }
        public Item(string id, string name, decimal price, string type)
        {
            Name = name;
            Type = type;
            ID = id;
            Price = price;
        }
        public Item(string id, string name, string type)
        {
            Name = name;
            Type = type;
            ID = id;
        }
        public void printMessage()
        {
            Console.WriteLine(Message);
        }

        //public List<Item> ItemList()
        //{
        //    string directory = Directory.GetCurrentDirectory();
        //    string fileName = "vendingmachine.csv";
        //    string fullPath = Path.Combine(directory, fileName);
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(fullPath))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                string[] line = (sr.ReadLine().Split("|"));
        //                Item item = new Item(line[0], line[1], int.Parse(line[2]), line[3]);
                        
        //                items.Add(item);

        //            }
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine("Can't compute");
        //    }
        //    return items;
        //}
        
        //{"1A", $"{item.Name}, ${item.Price}, {item.Type}"}
    }
}
