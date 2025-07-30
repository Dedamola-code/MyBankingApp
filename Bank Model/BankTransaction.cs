using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppAssignment.Bank_Interface;


namespace BankAppAssignment.Bank_Model
{
    /// <summary>
    /// Represents a bank transaction.
    /// </summary>
    public class BankTransaction
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the type of the transaction (e.g., "Deposit", "Withdrawal", "Transfer").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the status of the transaction (e.g., "Completed", "Pending", "Failed").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the transaction was created.
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
