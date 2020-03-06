/*
* Author: Grant Nichol
* Class: Entree.cs
* Purpose: An abstract class detailing what should be in an entree class.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{

    /// <summary>
    /// The base class for an entree
    /// </summary>
    public abstract class Entree : IOrderItem
    {
        /// <summary>
        /// The number of calories in the entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The price of the entree
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// The special instructions for this entree 
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }
    }
}
