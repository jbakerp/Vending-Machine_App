using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
           // public void DictionaryAddList(List<Inventory> input)
            //{
            //    foreach (Inventory element in input)
            //    {

            //    }
            //}



            //Item duck = new Item("Quack", "duck", "1A");
            //  Console.WriteLine(duck.Message);
            //Machine vend = new Machine();
            //vend.LoadItemsFromFile();
            //Console.WriteLine(vend.Date());
            // Menu display = new Menu();
            //display.DisplayItems(vend.ItemInventory);
            //Console.WriteLine(vend.ItemInventory[1].printMessage());
            Machine vend = new Machine();
            Menu userScreen = new Menu();
            for (int i = 0; i < vend.ItemInventory.Count; i++)
            {
                vend.DictionaryQuantities(vend.ItemInventory[i]);
            }
            int userInput = 12345;
            while (userInput == 12345) { 
            Console.WriteLine("Hello, Welcome To Joe's and Corbyn's Vending machine!");
            Console.WriteLine("\n");
            bool screenMenu = true;
            //while (screenMenu)
            {
                userScreen.FrontScreen();
                userInput = userScreen.Parse();
                vend.LoadItemsFromFile();
                Console.WriteLine("\n");
            }
                while (userInput == 1)
                {
                   
                    userScreen.DisplayItems(vend.ItemInventory);
                    Console.WriteLine("Press Enter to return to main menu");
                    Console.ReadLine();
                    userScreen.FrontScreen();
                    userInput = userScreen.Parse();
                  
                }
                while (userInput == 2)
                {
                    
                        
                       vend.PurchaseMenu();
                       int newUserInput = userScreen.Parse();
                        if (newUserInput == 1)
                        {
                            vend.FeedMoney(userScreen);
                            userInput = 2;
                        }
                        if (newUserInput == 2)
                        {
                        
                        userScreen.DisplayItems(vend.ItemInventory);
                        Console.WriteLine("\n");
                        Console.WriteLine("Please select an item.");
                        string itemSelection = Console.ReadLine();
                        
                        if (vend.InputValidity(itemSelection))
                        {
                           int item = vend.ItemNumber(itemSelection);
                        if (vend.Availability(itemSelection,vend.ItemInventory[item]))
                        {
                            vend.Transaction(vend.Balance,vend.ItemInventory[item]);
                        } 
                        }
                        userInput = 2;
                        }
                        if (newUserInput == 3)
                        {
                        vend.FinishTransaction();
                        userInput = 12345;
                        newUserInput = 0;
                        }
                        
                    
                }
                
                if (userInput == 3)
                {
                    screenMenu = false;
                 
                    Environment.Exit(0);
                }
                if (userInput == 4)
                {
                    //screenMenu = false;
                    //userscreen/password/totalsaleslog
                }
            }   
        }
    }
}
