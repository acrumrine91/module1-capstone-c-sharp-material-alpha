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
        private Catering catering = new Catering();

        public void RunInterface()
        {
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
                //Current Account Balance
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": //Add Money
                        break;

                    case "2": //Select Products
                        break;

                    case "3": //Complete Transaction
                        done = true;
                        break;
                }
            }
        }
    }
}
