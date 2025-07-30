using System;
using BankAppAssignment.Bank_Service;
using BankAppAssignment.Bank_Model;
using BankAppAssignment.Bank_Interface;


namespace BankAppAssignment
{
    /// <summary>
    /// Represents the main program class for the Bank Application.
    /// This class handles user interaction, login, and various banking operations
    /// such as deposit, withdrawal, transfer, and viewing account details.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the Bank Application.
        /// This method initializes the bank account manager, handles user login,
        /// and presents a menu for banking operations.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this application).</param>
        public static void Main(string[] args)
        {
            var manager = new BankAccountManager("Bank Data/Bank Database.json");
            BankCustomer bankCustomer = null;
            while (bankCustomer == null)
            {
                Console.Clear();
                Console.WriteLine("==== Login ====");
                Console.WriteLine("Enter Account Number: ");
                string account = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();
                bankCustomer = manager.Login(account, password);
                if (bankCustomer == null)
                {
                    Console.WriteLine("Invalid Credentials.\n Try Again.");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine($"Welcome, {bankCustomer.Name}");
            while (true)
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. View Account details");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmt))
                        {
                            if (depositAmt <= 0)
                            {
                                Console.WriteLine(" Amount must be greater than zero!!!!.");
                            }
                            else
                            {
                                var oldBalance = bankCustomer.Account.Balance;

                                manager.Deposit(bankCustomer.Account.AccountNumber, depositAmt);

                                var newBalance = bankCustomer.Account.Balance;

                                Console.WriteLine($"Deposit of £{depositAmt:0.00} successful.");
                                Console.WriteLine($"Old Balance: £{oldBalance:0.00}");
                                Console.WriteLine($"New Balance: £{newBalance:0.00}");

                            }
                        }
                        else
                        {
                            Console.WriteLine(" Invalid amount entered!!!!!!!!.");
                        }
                        break;
                    case "2":
                        Console.Write("Enter amount to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmt))
                        {
                            if (bankCustomer.Account.IsFrozen)
                            {
                                Console.WriteLine("This account is frozen.");
                            }
                            else if (withdrawAmt <= 0)
                            {
                                Console.WriteLine("Please enter a positive amount.");
                            }
                            else if (withdrawAmt > bankCustomer.Account.Balance)
                            {
                                Console.WriteLine($"Insufficient funds. Current Balance: {bankCustomer.Account.Balance}");
                            }
                            else
                            {
                                var oldBalance = bankCustomer.Account.Balance;

                                manager.Withdrawal(bankCustomer.Account.AccountNumber, withdrawAmt);

                                var newBalance = bankCustomer.Account.Balance;

                                Console.WriteLine($"Withdrawal of £{withdrawAmt:0.00} successful.");
                                Console.WriteLine($"Old Balance: £{oldBalance:0.00}");
                                Console.WriteLine($"New Balance: £{newBalance:0.00}");

                            }
                        }
                        else
                        {
                            Console.WriteLine(" Invalid amount entered.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter recipient Account Number: ");
                        string toAccount = Console.ReadLine();

                        Console.Write("Enter amount to transfer: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal transferAmt))
                        {
                            if (bankCustomer.Account.IsFrozen)
                            {
                                Console.WriteLine("Your account is frozen.");
                            }
                            else if (transferAmt <= 0)
                            {
                                Console.WriteLine("Amount must be greater than zero.");
                            }
                            else if (transferAmt > bankCustomer.Account.Balance)
                            {
                                Console.WriteLine($"Insufficient funds. You only have {bankCustomer.Account.Balance:C}");
                            }
                            else
                            {
                                var oldBalance = bankCustomer.Account.Balance;

                                manager.Transfer(bankCustomer.Account.AccountNumber, toAccount, transferAmt);

                                var newBalance = bankCustomer.Account.Balance;

                                Console.WriteLine($"Transferred £{transferAmt:0.00} to {toAccount}");
                                Console.WriteLine($"Old Balance: £{oldBalance:0.00}");
                                Console.WriteLine($"New Balance: £{newBalance:0.00}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "4":
                        Console.WriteLine($"\n--- Account Details ---");
                        Console.WriteLine($"Name: {bankCustomer.Name}");
                        Console.WriteLine($"Account Number: {bankCustomer.Account.AccountNumber}");
                        Console.WriteLine($"Account Type: {bankCustomer.Account.Type}");
                        Console.WriteLine($"Balance: £{bankCustomer.Account.Balance}");
                        Console.WriteLine($"Status: {(bankCustomer.Account.IsFrozen ? "Frozen" : "Active")}");
                        Console.WriteLine($"Date Created: {bankCustomer.Account.DateCreated}");

                        Console.WriteLine("\nRecent Transactions:");

                        foreach (var tx in bankCustomer.Account.Transactions)
                        {
                            Console.WriteLine($"{tx.DateCreated}: {tx.Type} - {tx.Status}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Logged out. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid menu option.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}