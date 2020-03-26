/*
* Author: Grant Nichol
* Class: Water.cs
* Purpose: A class for Water
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

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

        private bool _lemon;
        /// <summary>
        /// Whether there should be lemon
        /// </summary>
        public bool Lemon
        {
            get { return _lemon; }
            set
            {
                _lemon = value;
                NotifyOfPropertyChange("Lemon");
            }
        }

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

        /// <summary>
        /// Get a lice string representation of this drink
        /// </summary>
        /// <returns>String of drink</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(Size);

            ret.Append(" Water");

            return ret.ToString();
        }
    }
}
