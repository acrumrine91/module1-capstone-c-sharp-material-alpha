using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This is our maths class. Anything related to math goes here.
    /// </summary>
    public class Accounting
    {
        // Our account balance variable. It can only be edited within this class, so methods must be used to get at it.
        private decimal accountBalance = 0.00M;
        
        // Adds money to accountBalance.
        public void AddMoney(int valueToAdd)
        {
            if ((accountBalance + valueToAdd) <= 5000 && valueToAdd > 0)
            {
                accountBalance += valueToAdd;
            }
        }
        
        /// <summary>
        /// Resets accountBalance to 0.00M after completing a purchase.
        /// </summary>
        /// <returns></returns>
        public decimal ResetBalance()
        {
            return accountBalance = 0.00M;
        }
       
        /// <summary>
        /// This is the only way to get accountBalance to display in other classes since accountBalance is private.
        /// </summary>
        /// <returns></returns>
        public decimal DisplayMoney()
        {
            return accountBalance;
        }

        /// <summary>
        /// Method that makes change. Probably could be neater and refactored, but it works. Returns an array that can be picked apart in UserInterface.
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        public int[] MostEfficientChange(decimal cash)
        {
            int[] billsArray = new int[7];
            int cashOnly = (int)Math.Floor(cash);
            decimal changeOnly = (cash - cashOnly) * 100;

            billsArray[0] = cashOnly / 20;
            cashOnly -= billsArray[0] * 20;
            billsArray[1] = cashOnly / 10;
            cashOnly -= billsArray[1] * 10;
            billsArray[2] = cashOnly / 5;
            cashOnly -= billsArray[2] * 5;
            billsArray[3] = cashOnly;

            billsArray[4] = (int)changeOnly / 25;
            changeOnly -= billsArray[4] * 25;
            billsArray[5] = (int)changeOnly / 10;
            changeOnly -= billsArray[5] * 10;
            billsArray[6] = (int)changeOnly / 5;

            return billsArray;
        }
        
        /// <summary>
        /// This method subtract money from the accountBalance. This also adds to the receipt printout. Since we have a built-in summation of products, this also prevents inaccurate repeats.
        /// </summary>
        /// <param name="catering"></param>
        /// <param name="cateringItem"></param>
        /// <param name="userQuantity"></param>
        public void SubtractPurchase(Catering catering, CateringItem cateringItem, int userQuantity)
        {
            accountBalance -= userQuantity * cateringItem.Price;
            if (cateringItem.QuantityInStock - userQuantity >= 0)
            {
                cateringItem.QuantityInStock -= userQuantity;
                if (!catering.AllPurchasedItems.Contains(cateringItem))
                {
                    catering.PurchasedAdd(cateringItem);
                }
            }
        }
    }
}


