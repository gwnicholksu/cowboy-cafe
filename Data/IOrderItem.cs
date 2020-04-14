using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// An interface for all items that can be ordered
    /// </summary>
    public interface IOrderItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The price of the item
        /// </summary>
        double Price { get; }
        
        /// <summary>
        /// The number of calories in this
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// The special instructions to have
        /// </summary>
        List<string> SpecialInstructions { get; }
    }
}
