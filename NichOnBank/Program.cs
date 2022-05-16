using System;

namespace NichOnBank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountInteract bkai = new BankAccountInteract();
            BankAccount bka = null;
            var option = 1;

            if (bka == null)
            {
                bka = bkai.CreateBankAccount();
                Console.WriteLine("\n\n******* Press Enter to continue ******");
                Console.ReadLine();
            }

            if (bka != null)
            {
                while (option != 0)
                {
                    MainMenu.ShowMainMenu();
                    try
                    {
                        Console.Write("Option # ");
                        option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 0:
                                Console.WriteLine("Good bye!");
                                break;
                            case 1:
                                var acc = bkai.CreateAccount();
                                bka.Accoounts.Add(acc.ID, acc);
                                acc.AccountDetails();
                                break;
                            case 2:
                                MainMenu.AccountActivities();
                                Console.Write("Option # ");
                                var opt = Convert.ToInt32(Console.ReadLine());
                                if (opt == 3)
                                {
                                    var isAble = bka.ListAccounts();
                                }
                                else if (opt == 1 || opt == 2)
                                {
                                    Transaction tr = bka.AccountWithdrawDeposit(opt);

                                    if (tr != null)
                                        bka.Transactions.Add(tr.ID, tr);
                                }
                                else if (opt == 4)
                                {
                                    bka.ListAllTransactions();
                                }
                                else if (opt == 5)
                                {
                                    bka.LoanCreditPay();
                                }
                                else if (opt == 6)
                                {
                                    var isClosed = bka.CloseAccount();
                                    if (isClosed)
                                    {
                                        Console.WriteLine("Account successfully closed");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Unsuccessfull action result.");
                                    }
                                }
                                else if (opt == 7)
                                {
                                    Transaction trans = bka.Transfer();

                                    if (trans != null)
                                    {
                                        bka.Transactions.Add(trans.ID, trans);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Transaction failed.");
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                    }
                    Console.WriteLine("\n\n******* Press Enter to continue ******");
                    Console.ReadLine();

                }
            }
           
        }
    }
}
