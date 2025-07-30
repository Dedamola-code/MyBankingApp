using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppAssignment.Bank_Model;

namespace BankAppAssignment.Bank_Service
{
    /// <summary>
    /// Manages bank account operations such as deposits, withdrawals, transfers, and account freezing.
    /// </summary>
    public class BankAccountManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountManager"/> class.
        /// </summary>

        private readonly BankJsonRepository<BankCustomer> _repo;
        /// <summary>
        /// Path that leads to the json file
        /// </summary>
        /// <param name="dbFile"></param>
        public BankAccountManager(string dbFile)
        {
            _repo = new BankJsonRepository<BankCustomer>(dbFile);
        }

        /// <summary>
        /// Login a customer using the account number and password
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public BankCustomer Login(string accountNumber, string password)
        {
            var customers = _repo.GetAll();
            return customers.FirstOrDefault(c => c.Account.AccountNumber == accountNumber &&
            c.Password == password);
        }
        /// <summary>
        /// Deposits a specified amount into a customer's account.
        /// </summary>
        /// <param name="accountNumber">The account number to deposit into.</param>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(string accountNumber, decimal amount) {
            var customers = _repo.GetAll();
            var customer = customers.FirstOrDefault(c => c.Account.AccountNumber == accountNumber);
            customer?.Account.Deposit(amount);
            _repo.SaveAll(customers);
        }
        /// <summary>
        /// Withdraws a specified amount from a customer's account.
        /// </summary>
        /// <param name="accountNumber">The account number to withdraw from.</param>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdrawal(string accountNumber, decimal amount)
        {
            var customers = _repo.GetAll();
            var customer = customers.FirstOrDefault(c => c.Account.AccountNumber == accountNumber);
            customer?.Account.Withdrawal(amount);
            _repo.SaveAll(customers);
        }
        /// <summary>
        /// Transfers a specified amount from one account to another.
        /// </summary>
        /// <param name="fromAccount">The account number to transfer from.</param>
        /// <param name="toAccount">The account number to transfer to.</param>
        /// <param name="amount">The amount to transfer.</param>
        public void Transfer(string fromAccount, string toAccount, decimal amount)
        {
            var customers = _repo.GetAll();
            var sender = customers.FirstOrDefault(c => c.Account.AccountNumber == fromAccount);
            var receiver = customers.FirstOrDefault(c => c.Account.AccountNumber == toAccount);
            if (sender != null && receiver != null && !sender.Account.IsFrozen && sender.Account.Balance >= amount)
            {
                sender.Account.Transfer(toAccount, amount);
                receiver.Account.Deposit(amount);
                _repo.SaveAll(customers);
            }
        }

        /// <summary>
        /// Freezes a customer's account, preventing further transactions.
        /// </summary>
        /// <param name="accountNumber">The account number to freeze.</param>
        public void Freeze(string accountNumber)
        {
            var customers = _repo.GetAll();
            var customer = customers.FirstOrDefault(c => c.Account.AccountNumber == accountNumber);
            if (customer != null)
            {
                customer.Account.IsFrozen = true;
                _repo.SaveAll(customers);
            }
        }

        /// <summary>
        /// Retrieves a bank customer by their account number.
        /// </summary>
        /// <param name="accountNumber">The account number of the customer to retrieve.</param>
        /// <returns>The <see cref="BankCustomer"/> object if found; otherwise, null.</returns>
        public BankCustomer GetBankCustomer(string accountNumber)
        {
            var customer = _repo.GetAll();
            return customer.FirstOrDefault(c => c.Account.AccountNumber == accountNumber);
        }
    }   
}
