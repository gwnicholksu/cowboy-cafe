/*
* Author: Grant Nichol
* Class: ChiliCheeseFries.cs
* Purpose: A class representing the Chili Cheese Fries side
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Chili Cheese Fries side
    /// </summary>
    public class ChiliCheeseFries : Side
    {
        /// <summary>
        /// Gets the price of the side
        /// </summary>
        public override double Price
        { 
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.99;
                    case Size.Medium:
                        return 2.99;
                    case Size.Large:
                        return 3.99;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Gets the calories of the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 433;
                    case Size.Medium:
                        return 524;
                    case Size.Large:
                        return 610;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Display name
        /// </summary>
        public override string DisplayName => "Chili Cheese Fries";

        /// <summary>
        /// Description
        /// </summary>
        public override string Description => "sliced potatoes slathered with chili and cheese";

        /// <summary>
        /// Get a nice string representation of this side
        /// </summary>
        /// <returns>String of side</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(Size);
            ret.Append(" Chili Cheese Fries");
            return ret.ToString();
        }
    }
}
