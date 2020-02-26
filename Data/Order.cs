using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Hold an order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The last used order number
        /// </summary>
        private static uint lastOrderNumber = 0;

        /// <summary>
        /// The unique number for this order
        /// </summary>
        public uint OrderNumber { get; } = lastOrderNumber++;

        private List<IOrderItem> items = new List<IOrderItem>();
        /// <summary>
        /// The items in this Order
        /// </summary>
        public IEnumerable<IOrderItem> Items {
            get
            {
                return items.ToArray();
            }
        }


        private double subtotal = 0;
        /// <summary>
        /// The subtotal price for this order
        /// </summary>
        public double Subtotal
        {
            get
            {
                return subtotal;
            }
            private set
            {
                subtotal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            }
        }

        /// <summary>
        /// Event for changed properties
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Add an item to the order
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(IOrderItem item)
        {
            items.Add(item);
            Subtotal += item.Price;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
        }

        /// <summary>
        /// Remove an item from the order
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void Remove(IOrderItem item)
        {
            items.Remove(item);
            Subtotal -= item.Price;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
        }
    }
}
