/*
* Author: Grant Nichol
* Class: TexasTea.cs
* Purpose: A class for the Texas Tea drink
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class for the Texas Tea drink
    /// </summary>
    public class TexasTea : Drink
    {
        /// <summary>
        /// The number of calories in the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals;
                switch (Size)
                {
                    case Size.Small:
                        cals = 10;
                        break;
                    case Size.Medium:
                        cals = 22;
                        break;
                    case Size.Large:
                        cals = 36;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                return (Sweet) ? cals : cals / 2;
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
                    case Size.Small: return 1.00;
                    case Size.Medium: return 1.50;
                    case Size.Large: return 2.00;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private bool _sweet = true;
        /// <summary>
        /// Whether the tea should be sweetened
        /// </summary>
        public bool Sweet
        {
            get { return _sweet; }
            set
            {
                _sweet = value;
                NotifyOfPropertyChange("Sweet");
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

            ret.Append(" Texas");

            if (Sweet) ret.Append(" Sweet");
            else ret.Append(" Plain");

            ret.Append(" Tea");

            return ret.ToString();
        }
    }
}
