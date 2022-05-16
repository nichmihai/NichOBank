using System;
using System.Collections.Generic;
using System.Text;

namespace NichOnBank
{
    public enum TransactionType { Deposit = 1, Withdraw = 2, Transfer = 3}
    class Transaction
    {
        public int ID { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public DateTime CreationTime { get; set; }
        public int AccountId { get; set; }
        public AccountType AccountType { get; set; }
        public double AccountBalance { get; set; }
        public int AccountId2 { get; set; }
        public double Amount2 { get; set; }
        public AccountType AccountType2 { get; set; }
        public double AmountTransfered { get; set; }



        public Transaction()
        {

        }

        public Transaction(int tId, int tType, double tAmount, DateTime tCeation, int accId, AccountType accType, double accBalance)
        {
            this.ID = tId;
            this.Type = (TransactionType)tType;
            this.Amount = tAmount;
            this.CreationTime = tCeation;
            this.AccountId = accId;
            this.AccountType = accType;
            this.AccountBalance = accBalance;
        }

        public Transaction(int tId, int tType, double tAmount, DateTime tCreation, int accId, AccountType accType, double accBalance, int accId2, AccountType accType2, double accBalance2)
        {
            this.ID = tId;
            this.Type = (TransactionType)tType;
            this.AmountTransfered = tAmount;
            this.CreationTime = tCreation;
            this.AccountId = accId;
            this.AccountType = accType;
            this.AccountBalance = accBalance;
            this.AccountId2 = accId2;
            this.AccountType2 = accType2;
            this.Amount2 = accBalance2;
        }

    }
}
