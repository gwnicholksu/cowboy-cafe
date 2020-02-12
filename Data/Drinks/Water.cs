/*
* Author: Grant Nichol
* Class: Water.cs
* Purpose: A class for Water
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class for Water
    /// </summary>
    public class Water : Drink
    {
        /// <summary>
        /// The number of calories in the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public override double Price
        {
            get
            {
                return 0.12;
            }
        }

        /// <summary>
        /// Whether there should be a lemon included
        /// </summary>
        public bool Lemon { get; set; } = false;

        /// <summary>
        /// The special instructions for this drink
        /// </summary>
        public override List<String> SpecialInstructions
        {
            get
            {
                var returnList = new List<String>();
                if (!Ice) returnList.Add("Hold Ice");
                if (Lemon) returnList.Add("Add Lemon");

                return returnList;
            }
        }
    }
}
