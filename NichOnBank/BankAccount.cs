using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NichOnBank
{
    class BankAccount
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Dictionary<int, Account> Accoounts { get; set; }
        public Dictionary<int, Transaction> Transactions { get; set; }

        public BankAccount()
        {
            Accoounts = new Dictionary<int, Account>();
            Transactions = new Dictionary<int, Transaction>();
        }


        public bool ListAccounts()
        {
            Console.Clear();
            var res = false;
            if (Accoounts.Count > 0)
            {
                res = true;
                
                foreach (var acc in Accoounts)
                {
                    if (acc.Value.Type == AccountType.Debit)
                    {
                        Console.WriteLine($"| Account ID: {acc.Key} || Type: {acc.Value.Type}  ||  Creation Time: {acc.Value.CreationTime.ToString("MM/dd/yyyy")}  || Balance: ${acc.Value.Amount} |");
                    }
                    else if (acc.Value.Type == AccountType.Credit || acc.Value.Type == AccountType.Loan)
                    {
                        Console.WriteLine($"| Account ID: {acc.Key} || Type: {acc.Value.Type}  ||  Creation Time: {acc.Value.CreationTime.ToString("MM/dd/yyyy")}  || Balance: ${acc.Value.Amount} Interest: {acc.Value.Interest} Pending: {acc.Value.Pending}|");
                    }
                    else
                    {
                        Console.WriteLine($"| Account ID: {acc.Key} || Type: {acc.Value.Type}  ||  Creation Time: {acc.Value.CreationTime.ToString("MM/dd/yyyy")}  || Balance: ${acc.Value.Amount} Expiration Date: {acc.Value.Time.ToString("hh:mm:ss")} |");
                    }

                }
            }
            else 
            {
                res = false;
                Console.WriteLine("You don't have any available accounts.");
            }
            
            return res;
        }

        public void ListAllTransactions()
        {
            Console.Clear();
            if (this.Transactions.Count > 0)
            {
                foreach (var tr in Transactions)
                {
                    Console.WriteLine($"Transaction ID: {tr.Key}    ||  Type: {tr.Value.Type}   || Amount: ${tr.Value.Amount}    || Account ID: {tr.Value.AccountId} || Account Type: {tr.Value.AccountType}    || Account Balance: ${tr.Value.AccountBalance} || Transaction Time: {tr.Value.CreationTime}\n\n");
                }
            }
            else
            {
                Console.WriteLine("No Transactions logged yet.s");
            }
         
        }

        public Transaction AccountWithdrawDeposit(int option)
        {
            Console.Clear();
            Transaction transaction = null;
            Random r = new Random();
            int trId = r.Next(1, 10000000);
            DateTime trCreation = DateTime.Now;
            ListAccounts();

            if (option == 1)
            {
                try
                {
                    Console.WriteLine("Please choos account ID you would like to deposit:");
                    Console.Write("ID #");
                    int accountId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Amount to deposit: $");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    Account acc = Accoounts.Single(i => i.Key == accountId).Value;
                    if (acc != null)
                    {
                        if (acc.Type != AccountType.Loan && acc.Type != AccountType.Credit)
                        {
                            acc.Deposit(amount);
                            transaction = new Transaction(accountId, option, amount, trCreation, acc.ID, acc.Type, acc.Amount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid operation for a Loan/Credit account.");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Invalid account ID.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid amount");
                }
            }
            else if (option == 2)
            {
                try
                {
                    Console.WriteLine("Please choos account ID you would like to withdraw:");
                    Console.Write("ID #");
                    int accountId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Amount to withdraw: $");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    Account acc = Accoounts.Single(i => i.Key == accountId).Value;
                    if (acc != null)
                    {
                        acc.Withdraw(amount);
                        transaction = new Transaction(trId, option, amount, trCreation, acc.ID, acc.Type, acc.Amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid account ID.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid amount");
                }
            }

            return transaction;
        }

        public bool CloseAccount()
        {
            Console.Clear();
            bool isClosed = false;
            ListAccounts();
            Console.WriteLine("Please choos account ID you would like to close:");
            Console.Write("ID #");
            int accountId = Convert.ToInt32(Console.ReadLine());
            Account acc = Accoounts.Single(i => i.Key == accountId).Value;

            if (acc != null)
            {
                
                
                if (acc.Type == AccountType.CD && (DateTime.Now < acc.Time || acc.Amount > 0))
                {
                    Console.WriteLine("CD account can't be removed yet. Please make sure time has passed or move Balance to another accoun.");
                }
                else if (acc.Amount > 0 && acc.Pending > 0)
                {
                    Console.WriteLine("Please make sure your balance or pending is 0 before closing your account.");
                    isClosed = false;
                }
                else
                {
                    Accoounts.Remove(acc.ID);
                    isClosed = true;
                }
            }

            return isClosed;
        }

        public bool Transfer()
        {
            bool isTransfered = false;
            Console.Clear();
            ListAccounts();
            Console.WriteLine("Please chose account ID from: ");
            Console.Write("ID #");
            int accId1 = Convert.ToInt32(Console.ReadLine());
            var acc1 = Accoounts.Single(a => a.Key == accId1).Value;
           
            Console.WriteLine("Please chose account ID to: ");
            Console.Write("ID #");
            int accId2 = Convert.ToInt32(Console.ReadLine());
            var acc2 = Accoounts.Single(a => a.Key == accId2).Value;
           
            if (acc1 != null)
            {
                Console.WriteLine($"Please chose the amount you would like to withdraw from account 1: Account Balance: ${acc1.Amount}");
                Console.Write("Amount to transfer: $");
                double amount = Convert.ToDouble(Console.ReadLine());
                acc1.Withdraw(amount);

                if ((acc2.Type == AccountType.Credit || acc2.Type == AccountType.Loan) && acc2 != null)
                {
                    LoanCreditPay(amount, ref acc2);
                    isTransfered = true;
                }
                else
                {
                    acc2.Withdraw(amount);
                    isTransfered = true;
                }
            }

            return isTransfered;
        }

        public void LoanCreditPay()
        {
            ListAccounts();
            Console.WriteLine("Please choos account ID you would like to make a payment:");
            Console.Write("ID #");
            int accountId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Amount to withdraw: $");
            double amount= Convert.ToDouble(Console.ReadLine());
            Account acc = Accoounts.Single(i => i.Key == accountId).Value;
            
            if (acc.Type == AccountType.Loan || acc.Type == AccountType.Credit)
            {
                if (amount > acc.Amount || amount < 0)
                {
                    Console.WriteLine("Ivalid operation.");
                }
                else
                {
                    acc.Pending -= amount;
                    if (acc.InitialBalance >= amount || (amount + acc.Amount) <= acc.InitialBalance)
                    {
                        acc.Amount += amount;
                    }
                    else
                    {
                        Console.WriteLine("Trying to pay to much.");
                    }
                }
            }
        }

        public void LoanCreditPay(double amount, ref Account acc)
        {
            if (acc.Type == AccountType.Loan || acc.Type == AccountType.Credit)
            {
                if (amount > acc.Amount || amount < 0)
                {
                    Console.WriteLine("Ivalid operation.");
                }
                else
                {
                    acc.Pending -= amount;
                    if (acc.InitialBalance >= amount || (amount + acc.Amount) <= acc.InitialBalance)
                    {
                        acc.Amount += amount;
                    }
                    else
                    {
                        Console.WriteLine("Trying to pay to much.");
                    }
                }
            }
        }
    }
}
