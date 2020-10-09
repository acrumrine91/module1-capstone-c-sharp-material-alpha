using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public class Accounting
    {
        private decimal accountBalance = 0.00M;
        public void AddMoney(int valueToAdd)
        {
            if ((accountBalance + valueToAdd) <= 5000 && valueToAdd > 0)
            {
                accountBalance += valueToAdd;
            }
        }
        public decimal ResetBalance()
        {
            return accountBalance = 0.00M;
        }
        public decimal DisplayMoney()
        {
            return accountBalance;
        }

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


