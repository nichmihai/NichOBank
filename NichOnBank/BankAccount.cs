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
                Console.WriteLine("No Transactions logged yet.");
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
                        if (acc.Type != AccountType.Loan)
                        {
                            acc.Deposit(amount);
                            transaction = new Transaction(accountId, option, amount, trCreation, acc.ID, acc.Type, acc.Amount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid operation for a Loan account.");
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

        public void LoanPay()
        {
            ListAccounts();
            Console.WriteLine("Please choos account ID you would like to withdraw:");
            Console.Write("ID #");
            int accountId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Amount to withdraw: $");
            double amount= Convert.ToDouble(Console.ReadLine());
            Account acc = Accoounts.Single(i => i.Key == accountId).Value;
            
            if (acc.Type == AccountType.Loan)
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
