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
    }
}
