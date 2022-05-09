using System;
using System.Collections.Generic;
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
                        Console.WriteLine($"| Account ID: {acc.Key} || Type: {acc.Value.Type}  ||  Creation Time: {acc.Value.CreationTime.ToString("MM/dd/yyyy")}  || Balance: ${acc.Value.Amount} Interest: {acc.Value.Interest}|");
                    }
                    else
                    {
                        Console.WriteLine($"| Account ID: {acc.Key} || Type: {acc.Value.Type}  ||  Creation Time: {acc.Value.CreationTime.ToString("MM/dd/yyyy")}  || Balance: ${acc.Value.Amount} Expiration Date: {acc.Value.Time} |");
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
    }
}
