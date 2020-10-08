using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Accounting
    {
        private decimal accountBalance = 0.00M;
        public void AddMoney(int valueToAdd)
        {
            if ((accountBalance + valueToAdd) <= 5000)
            {
                accountBalance += valueToAdd;
            }
        }
        public decimal DisplayMoney()
        {
            return accountBalance;
        }
    }
}
