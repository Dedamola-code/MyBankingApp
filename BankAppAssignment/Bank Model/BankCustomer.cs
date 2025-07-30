using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAssignment.Bank_Model
{
    /// <summary>
    /// Represents a bank customer.
    /// </summary>
    public class BankCustomer
    {
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The gender of the customer.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The address of the customer.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The age of the customer.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// The bank customer's password
        /// </summary>
        public string Password {  get; set; }

        /// <summary>
        /// The bank identifier for the customer (default is 0).
        /// </summary>
        public string Bank { get; set; } 

        /// <summary>
        /// The bank user account associated with the customer.
        /// </summary
        public BankUserAccount Account { get; set; }
    }
}
