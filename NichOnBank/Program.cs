using System;

namespace NichOnBank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountInteract bkai = new BankAccountInteract();
            BankAccount bka = null;


            if (bka == null)
            {
                bka = bkai.CreateBankAccount();
                Console.WriteLine("\n\n******* Press Enter to continue ******");
                Console.ReadLine();
            }

            if (bka != null)
            {
                MainMenu.ShowMainMenu();

                try
                {
                    var option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            var acc = bkai.CreateAccount();
                            bka.Accoounts.Add(acc.ID, acc);
                            Console.WriteLine("\n\n******* Press Enter to continue ******");
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                    MainMenu.ShowMainMenu();   
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            }
           
        }
    }
}
