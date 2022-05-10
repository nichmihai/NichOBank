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
                    else if (acc.Value.Type == AccountType.Credit)
                    {
                        Console.WriteLine($"| Account ID: {acc.Key} || Type: {acc.Value.Type}  ||  Creation Time: {acc.Value.CreationTime.ToString("MM/dd/yyyy")}  || Balance: ${acc.Value.Amount} Interest: {acc.Value.Interest} |");
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
            foreach (var tr in Transactions)
            {
                Console.WriteLine($"Transaction ID: {tr.Key}    ||  Type: {tr.Value.Type}   || ");
            }
        }

        public Transaction AccountWithdrawDeposit(int option)
        {
            Console.Clear();
            Transaction transaction = null;
            Random r = new Random();
            int trId = r.Next(1, 10000000);
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
                    acc.Deposit(amount);
                    DateTime trCreation = DateTime.Now;
                    transaction = new Transaction(accountId, option,amount, trCreation, acc.ID, acc.Type);
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
                    Console.Write("Amount to deposit: $");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid amount");
                }
            }

            return transaction;
        }
    }
}
