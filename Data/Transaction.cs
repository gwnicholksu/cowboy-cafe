/*
* Author: Grant Nichol
* Class: Transaction.cs
* Purpose: Class holding all the information needeed for a transaction
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Holds all the data for an order transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The actual over held in this transaction
        /// </summary>
        public Order Order { get; private set; }

        public const double TAX_RATE = 0.16;

        /// <summary>
        /// Width to print for summary string
        /// </summary>
        public int PrintWidth { get; set; } = 60;

        /// <summary>
        /// Calculate the cost added due to tax
        /// </summary>
        public double AddedTax
        {
            get { return Math.Round(Order.Subtotal * TAX_RATE, 2); }
        }

        /// <summary>
        /// Calculate the total with tax
        /// </summary>
        public double Total
        {
            get { return Order.Subtotal + AddedTax; }
        }

        /// <summary>
        /// The method used to pay this transaction
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        double amountPaid;
        /// <summary>
        /// The amount that the customer paid
        /// </summary>
        public double AmountPaid
        {
            get { return amountPaid; }
            set
            {
                if (value < Total) return;
                amountPaid = value;
            }
        }

        /// <summary>
        /// Initialize the transaction object
        /// </summary>
        /// <param name="order">The order to hold</param>
        public Transaction(Order order)
        {
            Order = order;
        }

        /// <summary>
        /// The string that sumarizes the transaction in a receipt
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Cowboy Cafe");
            builder.AppendLine($"Order: {Order.OrderNumber}");
            builder.AppendLine(DateTime.Now.ToString());
            builder.Append('-', PrintWidth); // Add a horizontal line
            builder.AppendLine();
            builder.AppendLine("Items:");

            foreach(IOrderItem item in Order.Items)
            {
                string itemName = item.ToString();
                string price = item.Price.ToString("C"); // Format as currency
                if(itemName.Length + price.Length + 1 > PrintWidth)
                { // Truncate item name if too long
                    builder.Append(itemName, 0, PrintWidth - price.Length - 1);
                    builder.Append(" ");
                    builder.Append(price);
                }
                else
                {
                    builder.Append(itemName);
                    builder.Append(' ', PrintWidth - itemName.Length - price.Length);
                    builder.Append(price);
                }
                builder.AppendLine();

                foreach(string instruction in item.SpecialInstructions)
                {
                    builder.Append(' ', 5);
                    builder.Append(instruction);
                    builder.AppendLine();
                }
            }

            builder.Append('-', PrintWidth);
            builder.AppendLine();

            string subtotal = Order.Subtotal.ToString("C");
            builder.Append(' ', PrintWidth - 15 - 9);
            builder.Append("Subtotal:"); // 9 char long
            builder.Append(' ', 15 - subtotal.Length);
            builder.AppendLine(subtotal);

            string tax = AddedTax.ToString("C");
            builder.Append(' ', PrintWidth - 15 - 4);
            builder.Append("Tax:"); // 4 char long
            builder.Append(' ', 15 - tax.Length);
            builder.AppendLine(tax);

            builder.Append('-', PrintWidth);
            builder.AppendLine();

            string total = Total.ToString("C");
            builder.Append(' ', PrintWidth - 15 - 12);
            builder.Append("Grand Total:");
            builder.Append(' ', 15 - total.Length);
            builder.AppendLine(total);

            builder.Append('-', PrintWidth);
            builder.AppendLine();


            string method_name;
            switch (PaymentMethod)
            {
                case PaymentMethod.Cash:
                    method_name = "Cash";
                    break;
                case PaymentMethod.Credit:
                    method_name = "Credit";
                        break;
                default:
                    method_name = "";
                    break;
            }

            builder.Append(method_name);
            string payedAmount = AmountPaid.ToString("C");
            builder.Append(' ', PrintWidth - payedAmount.Length - method_name.Length);
            builder.AppendLine(payedAmount);
            builder.AppendLine();

            string balance = (AmountPaid - Total).ToString("C");
            builder.Append(' ', PrintWidth - 15 - 8);
            builder.Append("Balance:"); // 8 char long
            builder.Append(' ', 15 - balance.Length);
            builder.AppendLine(balance);
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
