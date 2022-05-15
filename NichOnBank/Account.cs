using System;
using System.Collections.Generic;
using System.Text;

namespace NichOnBank
{
    public enum AccountType { Debit = 1, Credit = 2, CD = 3, Loan = 4} 
    
    class Account
    {
        public int ID { get; set; }
        public AccountType Type { get; set; }
        public DateTime CreationTime { get; set; }
        public double Amount { get; set; }
        public double Pending { get; set; }
        public DateTime Time { get; set; }
        public double Interest { get; set; }
        public double InitialBalance { get; set; }
        public bool Lock { get; set; }

        public Account()
        {
           
        }

        public Account(int aId, int aType, DateTime aCreation, double aAmount)
        {
            this.ID = aId;
            this.Type = (AccountType)aType;
            this.CreationTime = aCreation;
            this.Amount = aAmount;
        }

        public Account(int aId, int aType, DateTime aCreation, double aAmount, DateTime aTime, double aInterest)
        {
            this.ID = aId;
            this.Type = (AccountType)aType;
            this.CreationTime = aCreation;
            this.Amount = aAmount;
            this.Time = aTime;
            this.Interest = aInterest;
            this.InitialBalance = aAmount;
        }

        public double SetInterest(DateTime time, double amountInsert, double rate)
        {
            double interest = 0;
            double t = Convert.ToSingle(time.ToOADate());
            return interest = amountInsert * (rate/100) * t;
        }

        public void AccountDetails()
        {
            Console.Clear();
            Console.WriteLine($"Account ID: {this.ID}");
            Console.WriteLine($"Account Type: {this.Type}");
            if (this.Type == AccountType.Credit || this.Type == AccountType.Loan)
            {
                Console.WriteLine($"Account Interest: {this.Interest}");
            }
            Console.WriteLine($"Account Creation: {this.CreationTime}");
            Console.WriteLine($"Account Balance: ${this.Amount}");
            if (this.Type == AccountType.CD)
            {
                Console.WriteLine($"CD till: ${this.Time.ToString("hh:mm:ss")}");
            }
        }

        public void Deposit(double amount)
        {
            if (this.Type != AccountType.Loan && this.Type != AccountType.Credit)
            {
                this.Amount += amount;
            }
            else
            {
                Console.WriteLine("You can't deposit in Loan account.");
            }
        }

        public void Withdraw(double amount)
        {
            
            if (this.Amount >= amount)
            {
                if (this.Type == AccountType.Loan &&  (amount+this.Pending) <= this.Amount)
                {
                    this.Pending += amount;
                    this.Amount -= amount;
                }
                else
                {
                    this.Amount -= amount;
                }    
            }
            else
            {
                Console.WriteLine("Not enough resources on account.");
            }
        }

        public void CDLock()
        {
            Console.Clear();
            bool isSet = false;
            Console.WriteLine("Chose time to lock the CD account:");
           
            while (!isSet)
            {
                Console.WriteLine("1. 1 min     2. 2 min    3. 3 min");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option >= 1 && option <= 3)
                {
                    this.Time = DateTime.Now.AddMinutes(option);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("Please chose a correct option.");
                }
            }
            
        }
    }
}
