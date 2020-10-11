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

        public UserInterface()
        {
            this.catering = new Catering();
            this.files = new FileAccess();
            this.accounting = new Accounting();
        }

        /// <summary>
        /// This is the main menu method. It contains the Display Catering Items, Order, and Quit options.
        /// </summary>
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
                    // Defaults to this, if userInput is anything but 1, 2, or 3.
                    default:
                        Console.WriteLine("Please select an appropriate option.");
                        break;

                    // Display Catering Items
                    case "1":
                        DisplayCateringItems();
                        break;

                    //Order
                    case "2":
                        PurchasingMenu();
                        break;

                    //Quit
                    case "3":
                        done = true;
                        break;
                }
            }

        }
        
        /// <summary>
        /// This is the Purchasing Menu. It contains Add Money, Select Products, and Complete Transaction options.
        /// </summary>
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
                    // Defaults to this if userInput is anything but 1, 2, or 3.
                    default:
                        Console.WriteLine("Please select an appropriate option.");
                        break;

                    //Add Money
                    case "1": 
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

                    // Select Products
                    case "2":
                        if (accounting.DisplayMoney() == 0.00M)
                        {
                            Console.WriteLine("Please deposit money into your account before trying to make a purchase.");
                            break;
                        }
                        Console.WriteLine("Which product would you like to add to your cart? ");
                        string userProductCode = Console.ReadLine().ToUpper();
                        this.SelectProduct(userProductCode);
                        break;

                    // Complete Transaction
                    case "3": 
                        DisplayPurchaseReport();
                        files.AccountPurchasesLog(accounting, "Change", 0);
                        accounting.ResetBalance();
                        done = true;
                        break;
                }
            }
        }
        
        /// <summary>
        /// Displays the list of Catering Items via a foreach loop and a call to the containing list.
        /// </summary>
        private void DisplayCateringItems()
        {
            foreach (CateringItem cateringItem in this.catering.AllCateringItems)
            {
                Console.WriteLine(cateringItem);
            }
        }

        /// <summary>
        /// Displays the purchase report or receipt.
        /// </summary>
        private void DisplayPurchaseReport()
        {
            // Creates the total cost of the purchase.
            decimal sum = 0M;
            foreach (CateringItem cateringItem in this.catering.AllPurchasedItems)
            {
                Console.WriteLine(cateringItem.PurchasedFormat());
                sum += cateringItem.PurchasedQuantity * cateringItem.Price;
            }

            // Creates the array needed to do the display of change below.
            int[] change = accounting.MostEfficientChange(accounting.DisplayMoney());

            Console.WriteLine();
            Console.WriteLine($"Total: {sum.ToString("C")}");
            Console.WriteLine();
            Console.WriteLine($"Your cash is {change[0]} twenty(ies), {change[1]} ten(s), {change[2]} fives, and {change[3]} one(s). Your change is {change[4]} quarter(s), {change[5]} dime(s), and {change[6]} nickel(s).");
            Console.WriteLine();
            Console.WriteLine($"Due to the national coin shortage, your coinage change has been credited to the National Dr. Pepper and Burrito Fund. Thank you for your wonderful donation! :-D");
            Console.WriteLine();
        }

        /// <summary>
        /// Method that adds money to the account balance. Accepts integer amounts only.
        /// </summary>
        /// <param name="amountToAdd"></param>
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

        /// <summary>
        /// Select product method. Contains catches for not in inventory, sold out, insufficient stock, and insufficent funds. 
        /// </summary>
        /// <param name="userInput"></param>
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
                    accounting.SubtractPurchase(catering, itemPurchased, userQuantityWanted);
                    files.PurchasesLog(itemPurchased, accounting, userQuantityWanted);
                }
            }
        }
    }
}
