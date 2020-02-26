/*
* Author: Grant Nichol
* Class: Drink.cs
* Purpose: An abstract class detailing what should be in an drink class.
*/

using System;
using System.Collections.Generic;
using System.Text;

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

        /// <summary>
        /// The size of the drink
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// Whether there should be ice in the drink
        /// </summary>
        public virtual bool Ice { get; set; } = true;

        /// <summary>
        /// The special instructions for this drink
        /// </summary>
        public abstract List<String> SpecialInstructions { get; }
    }
}
