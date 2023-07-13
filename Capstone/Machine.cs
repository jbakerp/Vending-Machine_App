using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class Machine
    {

        public List<Inventory> ItemInventory = new List<Inventory>();
        public Dictionary<string, int> quantityAvailable = new Dictionary<string, int>();
        public Menu newMenu = new Menu();
        public WriteLog writeLog = new WriteLog();
        public decimal Balance { get; set; } = 0M;
        public string Date()
        {
            return $"{DateTime.Now}";
        }
        public void LoadItemsFromFile()
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = (sr.ReadLine().Split("|"));
                        Inventory item = new Inventory(line[0], line[1], decimal.Parse(line[2]), line[3]);

                        ItemInventory.Add(item);

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Can't compute");
            }

        }
        public void DictionaryQuantities(Inventory input)
        {
            quantityAvailable.Add($"{input.ID}", input.ItemQuantity);
        }
        public void FeedMoney(Menu screen)
        {
            //bool menu = true;
            //while (menu)
            //{
            Console.WriteLine("\n");
            Console.Write("Here is your current balance: $");
            Console.WriteLine(this.Balance);
            decimal amountInput = 0;
            Console.WriteLine("Please Insert money, $1 $5 $10 $20");
            int userInput = screen.Parse();
            if (userInput == 1)
            {
                Balance += userInput;
                amountInput = userInput;
            }
            else if (userInput == 5)
            {
                Balance += userInput;
                amountInput = userInput;
                //menu = ReturnToPurchaseMenu();
            }
            else if (userInput == 10)
            {
                Balance += userInput;
                amountInput = userInput;
                //menu = ReturnToPurchaseMenu();
            }
            else if (userInput == 20)
            {
                Balance += userInput;
                amountInput = userInput;
                //menu = ReturnToPurchaseMenu();
            }
            //else if (userInput == 6)
            //{
            //    Console.Clear();
            //    screen.PurchaseMenu(vend, screen);

            //}
            else
            {
                Console.WriteLine("Please select a valid option");
            }
            Console.Write("Here is your updated balance: $");
            Console.WriteLine(Balance);
            TransactionLog log = new TransactionLog("Feed Money", amountInput, Balance);
            writeLog.WriteTransactionLog(log);





            //}
        }
        public bool ReturnToPurchaseMenu()
        {
            Console.WriteLine("Do you want to enter more money? Y/N");
            string userInput = Console.ReadLine();
            if (userInput.ToUpper() == "Y")
            {
                return true;
            }
            newMenu.FrontScreen();
            return false;

        }

        public void PurchaseMenu()
        {
            Console.WriteLine(Date());
            Console.Write("Current Balance: ");
            Console.Write("$" + Balance);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Purchase Menu");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("Please Select an option");
            Console.WriteLine("1. Feed Money");
            Console.WriteLine("2. Select Product");
            Console.WriteLine("3. Finish Transaction");


        }
        public bool InputValidity(string id)
        {
            for (int i = 0; i < ItemInventory.Count; i++)
            {
                if (ItemInventory[i].ID == id)
                {
                    return true;
                }
            }
            return false;
        }
        public int ItemNumber(string id)
        {
            for (int i = 0; i < ItemInventory.Count; i++)
            {
                if (ItemInventory[i].ID == id)
                {
                    return i;
                }
            }
            return 0;
        }
        public bool Availability(string id, Inventory bob)
        {

            if (bob.ItemQuantity != 0)
            {
                return true;
            }
            Console.WriteLine("Item Sold Out. Try again next time.");
            return false;

        }

        public void Transaction(decimal bal, Inventory listItem)
        {
            bal = Balance;
            if (bal >= listItem.Price)
            {
                listItem.UpdateQuantity();
                Balance -= listItem.Price;
                listItem.printMessage();
                TransactionLog log = new TransactionLog(listItem.Name, listItem.Price, Balance);
                writeLog.WriteTransactionLog(log);
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }

        }
        public void FinishTransaction()
        {
            decimal endBalance = Balance;
            int quarterCount = 0;
            int dimeCount = 0;
            int nickelCount = 0;

            while (Balance > 0M)
            {
                if (Balance >= .25M)
                {
                    Balance -= .25M;
                    quarterCount++;
                }
                else if (Balance >= 0.10M)
                {
                    Balance -= .10M;
                    dimeCount++;
                }
                else if (Balance >= .05M)
                {
                    Balance -= .05M;
                    nickelCount++;
                }
            }
            Console.WriteLine($"Here is your change ${endBalance} in: {quarterCount} quarters, {dimeCount} dimes, {nickelCount} nickels.");
            Console.WriteLine("\n");
            TransactionLog log = new TransactionLog("Gave Change", endBalance, Balance);
            writeLog.WriteTransactionLog(log);
        }




    }
}
