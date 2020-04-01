using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Holds all the data for an order transaction
    /// </summary>
    class Transaction
    {
        /// <summary>
        /// The actual over held in this transaction
        /// </summary>
        public Order order { get; private set; }

        private const double tax_rate = 1.16;


    }
}
