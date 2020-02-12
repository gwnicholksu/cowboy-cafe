/*
* Author: Grant Nichol
* Class: TexasTea.cs
* Purpose: A class for the Texas Tea drink
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data.Drinks
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
                uint cal = Size switch
                {
                    Size.Small => 10,
                    Size.Medium => 22,
                    Size.Large => 36,
                    _ => throw new NotImplementedException(),
                };

                return (Sweet) ? cal / 2 : cal;
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

        /// <summary>
        /// Whether the tea should be sweetened
        /// </summary>
        public bool Sweet { get; set; } = true;

        /// <summary>
        /// Whether there should be lemon
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
