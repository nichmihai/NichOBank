using System;
using System.Collections.Generic;
using System.Text;

namespace NichOnBank
{
    class MainMenu
    {
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("|---------------------------------  Menu --------------------------------|");
            Console.WriteLine("| 1. Create Account  2. Account activities   0. Exit|");
        }

        public static void AccountTypesMenu()
        {
            Console.Clear();
            Console.WriteLine("|---------------------------------  Account Types --------------------------------|");
            Console.WriteLine("|        1. Debit           2. Credit              3. CD              4. Loan     |");
        }

        public static void AccountActivities()
        {
            Console.Clear();
            Console.WriteLine("|-------------- Account activities -------------------|");
            Console.WriteLine("|------ 1. Deposit   2. Withdraw  3. List All Accounts  4. List all transactions  5. Pay Loan 6. Close Account  7. Transfer ---|");
        }
    }
}
