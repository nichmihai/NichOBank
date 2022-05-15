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
                MainMenu.AccountTypesMenu();
                Console.Write("Type #");

                var option = Convert.ToInt32(Console.ReadLine());
                if (option <= 4 && (option == 1 || option == 3))
                {
                    DateTime creation = DateTime.Now;
                    Console.Write("Amount to insert into account: $");
                    double amountInsert = Convert.ToDouble(Console.ReadLine());

                    acc = new Account(id, option, creation, amountInsert);

                    if (acc.Type == AccountType.CD)
                    {
                        acc.CDLock();
                    }

                }
                else if (option <= 4 && (option == 2 || option == 4))
                {
                    DateTime creation = DateTime.Now;
                    Console.WriteLine("Amount available: \n\t1. $250  2. $500  3. $750  4. $1000");
                    Console.Write("Option #");
                    int opt = Convert.ToInt32(Console.ReadLine());
                    double amount = AmountChose(opt);
                    var interest = 25;
                    Console.WriteLine("Chose time for credit/loan: 1) 1 Month 2) 2 month 3) 3 Month 4) 4 Month");
                    opt = Convert.ToInt32(Console.ReadLine());
                    DateTime t = MonthChose(opt);

                    acc = new Account(id, option, creation, amount, t, interest);

                    if (acc.Type == AccountType.Loan)
                    {
                        acc.Amount = amount;
                        acc.Pending += acc.SetInterest(acc.Time, acc.Amount, interest);
                    }
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid account type choosed.");
                    Console.Clear();
                      
                }

            }
            catch (Exception ex)
            {
                
            }

            return acc;
        }

        public bool AccountAction(int option, BankAccount bankAccount)
        {
            var res = false;

            if (option == 1)
            {
                
            }

            return res;
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

        public DateTime MonthChose(int option)
        {
            DateTime res = DateTime.Now;
            switch (option)
            {
                case 1:
                    res = DateTime.Now.AddMinutes(1);
                    break;
                case 2:
                    res = DateTime.Now.AddMinutes(2);
                    break;
                case 3:
                    res = DateTime.Now.AddMinutes(3);
                    break;
                case 4:
                    res = DateTime.Now.AddMinutes(4);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            return res;
        }

        public double ApplyInterest(double amount, double interest, double time)
        {
            double res = 0;
            var I = (interest / 100);
            double inter = amount * I * time;
            res = inter;
            return res;
        }
    }
}
