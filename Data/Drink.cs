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
    public abstract class Drink : IOrderItem
    {
        /// <summary>
        /// The number of calories in the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public abstract double Price { get; }

        public Size _size = Size.Small;
        /// <summary>
        /// The size of the drink
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set
            {
                _size = value;
                NotifyOfPropertyChange("Size");
            }
        }

        private bool _ice = true;
        /// <summary>
        /// Whether there should be ice in the drink
        /// </summary>
        public bool Ice
        {
            get { return _ice; }
            set
            {
                _ice = value;
                NotifyOfPropertyChange("Ice");
            }
        }

        /// <summary>
        /// The special instructions for this drink
        /// </summary>
        public abstract List<String> SpecialInstructions { get; }

        /// <summary>
        /// Event to be activated whenever certain properties are changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify that a property has changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == "Size")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }
    }
}
