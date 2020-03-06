using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Hold an order
    /// </summary>
    public class Order : INotifyPropertyChanged
    {
        /// <summary>
        /// The last used order number
        /// </summary>
        private static uint lastOrderNumber = 0;

        /// <summary>
        /// The unique number for this order
        /// </summary>
        public uint OrderNumber { get; } = lastOrderNumber++;

        /// <summary>
        /// The items that have been ordered
        /// </summary>
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

        /// <summary>
        /// The subtotal price for this order
        /// </summary>
        public double Subtotal
        {
            get
            {
                double total = 0;
                foreach (var item in Items)
                {
                    total += item.Price;
                }
                return total;
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
            ItemChanged(this, new PropertyChangedEventArgs("Price"));
            item.PropertyChanged += ItemChanged;
        }

        /// <summary>
        /// Remove an item from the order
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void Remove(IOrderItem item)
        {
            items.Remove(item);
            ItemChanged(this, new PropertyChangedEventArgs("Price"));
            item.PropertyChanged -= ItemChanged;
        }

        /// <summary>
        /// Method for if any item has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemChanged(object sender, PropertyChangedEventArgs e)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            if(e.PropertyName == "Price")
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
        }
    }
}
