/*
* Author: Grant Nichol
* Class: CowboyCoffee.cs
* Purpose: A class for the Cowboy Coffee drink
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class for the Cowboy Coffee drink
    /// </summary>
    public class CowboyCoffee : Drink
    {
        /// <summary>
        /// The number of calories in the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small: return 3;
                    case Size.Medium: return 5;
                    case Size.Large: return 7;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small: return 0.60;
                    case Size.Medium: return 1.10;
                    case Size.Large: return 1.60;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private bool _decaf = false;
        /// <summary>
        /// Whether the coffee should be decalf
        /// </summary>
        public bool Decaf
        {
            get { return _decaf; }
            set {
                _decaf = value;
                NotifyOfPropertyChange("Decaf");
            }
        }

        private bool _roomForCream = false;
        /// <summary>
        /// Whether there should be room for cream
        /// </summary>
        public bool RoomForCream
        {
            get { return _roomForCream; }
            set
            {
                _roomForCream = value;
                NotifyOfPropertyChange("RoomForCream");
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
                if (Ice) returnList.Add("Add Ice");
                if (RoomForCream) returnList.Add("Room for Cream");

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

            if (Decaf) ret.Append(" Decaf");

            ret.Append(" Cowboy Coffee");

            return ret.ToString();
        }
    }
}
