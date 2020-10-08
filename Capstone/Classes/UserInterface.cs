using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// ALL instances of Console.ReadLine and Console.WriteLine should 
    /// be in this class.
    /// </summary>
    public class UserInterface
    {
        private Catering catering;
        private FileAccess files;
        private Accounting accounting;

        public UserInterface()
        {
            this.catering = new Catering();
            this.files = new FileAccess();
            this.accounting = new Accounting();
        }

        public void RunInterface()
        {
            this.files.ReadingCateringInventory(this.catering);
            
            bool done = false;
            while (!done)
            {
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");
               
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": //Display Catering Items
                        DisplayCateringItems();
                        break;
                    
                    case "2": //Order
                        PurchasingMenu();
                        break;
                    
                    case "3":
                        done = true;
                        break;
                }
            }

        }
        public void PurchasingMenu()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                Console.WriteLine($"Current Account Balance: ${this.accounting.DisplayMoney()}");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": //Add Money
                        Console.Write("How much money would you like to add to your account: ");
                        try
                        {
                            int amountToAdd = int.Parse(Console.ReadLine());
                            if ((this.accounting.DisplayMoney() + amountToAdd) > 5000)
                            {
                                Console.WriteLine("Your account cannot exceed $5000.");
                            }
                            this.accounting.AddMoney(amountToAdd);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Please use whole number values only. " + "(" + ex.Message + ")");
                        }      
                        break;

                    case "2": //Select Products
                        
                        break;

                    case "3": //Complete Transaction
                        done = true;
                        break;
                }
            }
        }

        private void DisplayCateringItems()
        {
            foreach (CateringItem cateringItem in this.catering.AllCateringItems)
            {
                Console.WriteLine(cateringItem);
            }
        }
    }
}
