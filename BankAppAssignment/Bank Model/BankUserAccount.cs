using BankAppAssignment.Bank_Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppAssignment.Bank_Model;

namespace BankAppAssignment.Bank_Model
{
    /// <summary>
    /// Shows a user's bank account information
    /// </summary>
    public class BankUserAccount:BankBaseAccount
    {
        /// <summary>
        /// Gets or sets the name associated with the account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the type of the account (e.g., "Savings", "Checking").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is frozen.
        /// </summary>
        public bool IsFrozen { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the account was created.
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// Deposits a specified amount into the account.
        /// If the account is frozen, the deposit will not proceed.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public override void Deposit(decimal amount)
        {
            if (IsFrozen)
                return;
            Balance += amount;
            Transactions.Add(new BankTransaction { Type = "Deposit", Status = "Success" });
        }

        /// <summary>
        /// Withdraws a specified amount from the account.
        /// If the account is frozen or the balance is insufficient, the withdrawal will not proceed.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public override void Withdrawal(decimal amount)
        {
            if (IsFrozen || Balance < amount)
                return;
            Balance -= amount;
            Transactions.Add(new BankTransaction { Type = "Withdrawal", Status = "Success" });
        }

        /// <summary>
        /// Transfers a specified amount from this account to another account.
        /// If the account is frozen or the balance is insufficient, the transfer will not proceed.
        /// </summary>
        /// <param name="toAccount">The account number to transfer to.</param>
        /// <param name="amount">The amount to transfer.</param>
        public override void Transfer(string toAccount, decimal amount)
        {
            if (IsFrozen || Balance < amount)
                return;
            Balance -= amount;
            Transactions.Add(new BankTransaction { Type = "Transfer", Status = $"Transfer to {toAccount}" });
        }
    }
}
