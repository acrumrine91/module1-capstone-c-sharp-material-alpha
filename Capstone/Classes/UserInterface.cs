using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;
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
                            files.AccountPurchasesLog(accounting, "Added", amountToAdd);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Please use whole number values only. " + "(" + ex.Message + ")");
                        }
                        break;

                    case "2": //Select Products
                        Console.WriteLine("Which product would you like to add to your cart? ");
                        string userProductCode = Console.ReadLine().ToUpper();
                        this.SelectProduct(userProductCode);
                        break;

                    case "3": //Complete Transaction
                        DisplayPurchaseReport();
                        files.AccountPurchasesLog(accounting, "Change", 0);
                        accounting.ResetBalance();
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

        private void DisplayPurchaseReport()
        {
            decimal sum = 0M;
            foreach (CateringItem cateringItem in this.catering.AllPurchasedItems)
            {
                Console.WriteLine(cateringItem.PurchasedFormat());
                sum += cateringItem.PurchasedQuantity * cateringItem.Price;
            }

            int[] change = accounting.MostEfficientChange(accounting.DisplayMoney());

            Console.WriteLine();
            Console.WriteLine($"Total: {sum.ToString("C")}");
            Console.WriteLine();
            Console.WriteLine($"Your cash is {change[0]} twenty(ies), {change[1]} ten(s), {change[2]} fives, and {change[3]} one(s). Your change is {change[4]} quarter(s), {change[5]} dime(s), and {change[6]} nickel(s).");
            Console.WriteLine();
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
                Console.WriteLine("Sorry, the product you requested is not in our inventory. Please try again.");
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
                else if (catering.ProductIsInStock(userInput).Price*userQuantityWanted > accounting.DisplayMoney())
                {
                    Console.WriteLine("We're sorry, but you have insufficient funds to complete this transaction.");
                }
                else
                {
                    CateringItem itemPurchased = catering.SearchProductCode(userInput);
                    decimal totalCost = itemPurchased.Price * userQuantityWanted;
                    accounting.SubtractPurchase(catering, itemPurchased, userQuantityWanted);
                    files.PurchasesLog(itemPurchased, accounting, userQuantityWanted);
                }
            }
        }
    }
}
