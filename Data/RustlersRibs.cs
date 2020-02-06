/*
* Author: Grant Nichol
* Class: RustlersRibs.cs
* Purpose: A class for the Texas Rustler's Ribs entree
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Rustler's Ribs entree
    /// </summary>
    public class RustlersRibs : Entree
    {
        /// <summary>
        /// The price of the ribs
        /// </summary>
        public override double Price
        {
            get
            {
                return 7.50;
            }
        }

        /// <summary>
        /// The calories of the ribs
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 894;
            }
        }

        /// <summary>
        /// Get the special instructions (there are none)
        /// </summary>
        public override List<String> SpecialInstructions
        {
            get
            {
                return new List<String>();
            }
        }
    }
}
