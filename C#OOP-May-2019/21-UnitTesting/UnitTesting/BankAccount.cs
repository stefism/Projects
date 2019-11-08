using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class BankAccount
    {
        private decimal balance;

        public decimal Balance 
        { 
          get => balance;

          private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative.");
                }

                balance = value;
            }
        }

        public BankAccount(decimal balance)
        {
            Balance = balance;
        }

        public void Deposit(decimal sum)
        {
            CheckSumIsPositive(sum);

            Balance += sum;
        }

        public void Withdraw(decimal sum)
        {
            CheckSumIsPositive(sum);

            Balance -= sum;
        }

        private static void CheckSumIsPositive(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be bigger than zero.");
            }
        }
    }
}
