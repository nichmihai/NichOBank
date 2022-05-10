using System;
using System.Collections.Generic;
using System.Text;

namespace NichOnBank
{
    public enum TransactionType { Deposit = 1, Withdraw = 2}
    class Transaction
    {
        public int ID { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public DateTime CreationTime { get; set; }
        public int AccountId { get; set; }
        public AccountType AccountType { get; set; }


        public Transaction()
        {

        }

        public Transaction(int tId, int tType, double tAmount, DateTime tCeation, int accId, AccountType accType)
        {
            this.ID = tId;
            this.Type = (TransactionType)tType;
            this.Amount = tAmount;
            this.CreationTime = tCeation;
            this.AccountId = accId;
            this.AccountType = accType;
        }
    }
}
