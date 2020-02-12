﻿/*
* Author: Grant Nichol
* Class: CowboyCoffee.cs
* Purpose: A class for the Cowboy Coffee drink
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data.Drinks
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

        public bool RoomForCream { get; set; } = false;

        public CowboyCoffee()
        {
            this.Ice = false; // Make Ice false this time
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


    }
}