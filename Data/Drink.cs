/*
* Author: Grant Nichol
* Class: Drink.cs
* Purpose: An abstract class detailing what should be in an drink class.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// An abstract class detailing what should be in an drink class.
    /// </summary>
    public abstract class Drink : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The number of calories in the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// The size of the drink
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// Whether there should be ice in the drink
        /// </summary>
        public abstract bool Ice { get; set; }

        /// <summary>
        /// The special instructions for this drink
        /// </summary>
        public abstract List<String> SpecialInstructions { get; }

        /// <summary>
        /// Event to be activated whenever certain properties are changed
        /// </summary>
        public abstract event PropertyChangedEventHandler PropertyChanged;
    }
}
