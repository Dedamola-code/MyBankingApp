using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppAssignment.Bank_Interface;
using BankAppAssignment.Bank_Model;

namespace BankAppAssignment.Bank_Model
{
    /// <summary>
    /// An abstract class that defines shared bank account behavior.
    /// </summary>
    public abstract class BankBaseAccount : IBankAccountOperations
    {
        /// <summary>
        /// Customer's Account number.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Customer's Account Password.
        /// </summary>
        //public string Password { get; set; }

        /// <summary>
        /// Customer's Account Balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Customer's Transactions.
        /// </summary>
        public List<BankTransaction> Transactions { get; set; } = new();

        /// <summary>
        /// Deposits a specified amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public abstract void Deposit(decimal amount);

        /// <summary>
        /// Withdraws a specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public abstract void Withdrawal(decimal amount);

        /// <summary>
        /// Transfers a specified amount to another account.
        /// </summary>
        /// <param name="toAccount">The account number to transfer to.</param>
        /// <param name="amount">The amount to transfer.</param>
        public abstract void Transfer(string toAccount, decimal amount);
    }
}
