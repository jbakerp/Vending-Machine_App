using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Capstone
{
    public class Menu
    {
       public virtual void DisplayItems(List<Inventory> items)
                {
                    for ( int i =0; i <items.Count; i++)
                    {
                        Console.WriteLine($"{items[i].ID}, {items[i].Name}, {items[i].Price}, {items[i].ItemQuantity} ");
                        Console.WriteLine("--------------------------------------");
                    }
                }
        public int Parse()
        {
            
            int result = 0;
            while(result==0)
            {
                string choice = Console.ReadLine();
                bool success = int.TryParse(choice, out result);
                if (!success)
                {
                    Console.WriteLine("Error reading input, please try again.");
                }
            }
            return result;
        }
       
        public void FrontScreen()
        {

            //Console.WriteLine(vend.Date());
            Console.WriteLine("Please select from the following menu (please choose a number):");
            Console.WriteLine("1. Display Items");
            Console.WriteLine("2. Purchase Menu");
            Console.WriteLine("3. Exit");
        }
        public void GetUserInput()
        {
            string userInput = Console.ReadLine();
           

        }
        //public void PurchaseMenu()
        //{
        //    Console.WriteLine(vend.Date());
        //    Console.Write("Current Balance: ");
        //    Console.Write("$"+vend.Balance);
        //    Console.WriteLine("");
        //    Console.WriteLine("--------------------------------------");
        //    Console.WriteLine("Purchase Menu");
        //    Console.WriteLine("--------------------------------------");
        //    Console.WriteLine("\n");
        //    Console.WriteLine("Please Select an option");
        //    Console.WriteLine("1. Feed Money");
        //    Console.WriteLine("2. Select Product");
        //    Console.WriteLine("3. Finish Transaction");
            

        //}




    }
}
