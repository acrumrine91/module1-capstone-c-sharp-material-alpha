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
        private CateringItem cateringItem;

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
                        Console.Write("How much money would you like to add to your account? ");
                        try
                        {
                            int amountToAdd = int.Parse(Console.ReadLine());
                            this.AddMoney(amountToAdd);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Please use whole number values only. " + "(" + ex.Message + ")");
                        }
                        break;

                    case "2": //Select Products
                        Console.WriteLine("Which product would you like to add to your cart? ");
                        string userProductCode = Console.ReadLine();
                        this.SelectProduct(userProductCode);
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

        private void AddMoney(int amountToAdd)
        {
            if (amountToAdd <= 0)
            {
                Console.WriteLine("Must be a positive whole number.");
            }

            if ((this.accounting.DisplayMoney() + amountToAdd) > 5000)
            {
                Console.WriteLine("Your account cannot exceed $5000.");
            }

            this.accounting.AddMoney(amountToAdd);
        }

        private void SelectProduct(string userInput)
        {
            if (catering.SearchProductCode(userInput) == null)
            {
                Console.WriteLine("Sorry, the product you requested is not in our inventory or sold out. Please try again.");
            }
            else if (catering.ProductIsInStock(userInput) == null)
            {
                Console.WriteLine("Sorry, the product you requested is sold out. Please try again.");
            }
            else if (catering.ProductIsInStock(userInput) != null)
            {
                Console.WriteLine("How many do you want to purchase?");
                int userQuantityWanted = int.Parse(Console.ReadLine());


                if (catering.ProductIsInStock(userInput).QuantityInStock < userQuantityWanted)
                {
                    Console.WriteLine("Sorry, we have insufficient stock of that item.");
                }
                else
                {
                    accounting.SubtractPurchase(catering.SearchProductCode(userInput), userQuantityWanted);
                }
            }
        }
    }
}
