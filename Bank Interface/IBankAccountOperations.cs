using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAssignment.Bank_Interface
{
    /// <summary>
    /// An abstract data type for the bank's basic operations.
    /// </summary>
    public interface IBankAccountOperations
    {
        /// <summary>
        /// Deposits a specified amount into an account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        void Deposit(decimal amount);

        /// <summary>
        /// Withdraws a specified amount from an account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        void Withdrawal(decimal amount);

        /// <summary>
        /// Transfers a specified amount from one account to another.
        /// </summary>
        /// <param name="toAccount">The account number to transfer to.</param>
        /// <param name="amount">The amount to transfer.</param>
        void Transfer(string toAccount, decimal amount);
    }
}

