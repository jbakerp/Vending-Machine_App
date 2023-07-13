using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Inventory:Item
    {

        
        public int ItemQuantity { get; set; } = 5;

        public Inventory(string name, string type, string id): base(name, type, id) { }
        public Inventory(string id, string name, decimal price, string type) : base(id, name, price, type) { }

        public override int Quantity()
        {
            return ItemQuantity;
        }

        //public void AddToInventory(string item )
        //{
        //    itemInventory.Add(item);
        //}

        public void UpdateQuantity()
        {
            ItemQuantity--;
        }












    }
}
