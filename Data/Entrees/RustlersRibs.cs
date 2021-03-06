﻿/*
* Author: Grant Nichol
* Class: RustlersRibs.cs
* Purpose: A class for the Texas Rustler's Ribs entree
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

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
        /// Display Name
        /// </summary>
        public override string DisplayName => "Rustler's Ribs";

        /// <summary>
        /// Description
        /// </summary>
        public override string Description => "BBQ spare ribs";

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

        /// <summary>
        /// Get a nice string representation of this entree
        /// </summary>
        /// <returns>String of entree</returns>
        public override string ToString()
        {
            return "Rustler's Ribs";
        }
    }
}
