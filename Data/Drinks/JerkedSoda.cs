/*
* Author: Grant Nichol
* Class: JerkedSoda.cs
* Purpose: A class for the Jerked Soda drink
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class for the Jerked Soda drink
    /// </summary>
    public class JerkedSoda : Drink
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
                    case Size.Small: return 110;
                    case Size.Medium: return 146;
                    case Size.Large: return 198;
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
                    case Size.Small: return 1.59;
                    case Size.Medium: return 2.10;
                    case Size.Large: return 2.59;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private SodaFlavor _flavor = SodaFlavor.CreamSoda;
        /// <summary>
        /// What flavor the soda should be
        /// </summary>
        public SodaFlavor Flavor
        {
            get { return _flavor; }
            set
            {
                _flavor = value;
                NotifyOfPropertyChange("Flavor");
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

            switch (Flavor)
            {
                case SodaFlavor.BirchBeer:
                    ret.Append(" Birch Beer");
                    break;
                case SodaFlavor.CreamSoda:
                    ret.Append(" Cream Soda");
                    break;
                case SodaFlavor.OrangeSoda:
                    ret.Append(" Orange Soda");
                    break;
                case SodaFlavor.RootBeer:
                    ret.Append(" Root Beer");
                    break;
                case SodaFlavor.Sarsparilla:
                    ret.Append(" Sarsparilla");
                    break;
                default:
                    break;
            }

            ret.Append(" Jerked Soda");

            return ret.ToString();
        }
    }
}
