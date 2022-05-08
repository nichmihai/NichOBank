using System;
using System.Collections.Generic;
using System.Text;

namespace NichOnBank
{
    class BankAccountInteract
    {
        public BankAccount CreateBankAccount()
        {
            BankAccount bka = new BankAccount();
            User user = CreateUser();

            if (user != null)
            {
                Console.Clear();
                user.PrintUserDetails();
            }



            return bka;
        }

        public User CreateUser()
        {
            User user = null;
            try
            {
                Random r = new Random();
                int id = r.Next(1000000, 10000000);
                Console.WriteLine("Please insert First Name:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Please insert Last Name:");
                string lastName = Console.ReadLine();
                Console.WriteLine("Please insert your date of birth: mm/dd/yyyy");
                DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

                user = new User(id, firstName, lastName, birthDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return user;
        }


        public Account CreateAccount()
        {
            Console.Clear();
            Account acc = null;
            try
            {
                Random r = new Random();
                int id = r.Next(1000000, 10000000);
                Console.WriteLine("Type of account:");
                Console.WriteLine("1.Debit 2.Credit 3.CD 4.Loan");
                int accType = Convert.ToInt32(Console.ReadLine());

                if (accType <= 4 && (accType == 1 || accType == 3))
                {
                    DateTime creation = DateTime.Now;
                    Console.WriteLine("Amount to insert into account: $");
                    double amountInsert = Convert.ToDouble(Console.ReadLine());

                    acc = new Account(id, accType, creation, amountInsert);
                    acc.AccountDetails();
                }
                else if (accType <= 4 && (accType == 2 || accType == 4))
                {
                    DateTime creation = DateTime.Now;
                    Console.WriteLine("Amount available: \n\t1. $250  2. $500  3. $750  4. $1000");
                    int option = Convert.ToInt32(Console.ReadLine());
                    double amount = AmountChose(option);
                    Console.WriteLine("Chose time for credit/loan: 1) 1 Month 2) 1.5 Month 3) 2 Month 4) 3 Month");

                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid account type choosed.");
                    Console.Clear();
                    CreateAccount();
                }

            }
            catch (Exception ex)
            {
                
            }

            return acc;
        }

        public double AmountChose(int option)
        {
            double amountReturn = 0;
            switch (option)
            {
                case 1:
                    amountReturn = 250;
                    break;
                case 2:
                    amountReturn = 500;
                    break;
                case 3:
                    amountReturn = 750;
                    break;
                case 4:
                    amountReturn = 1000;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            return amountReturn;
        }
    }
}
