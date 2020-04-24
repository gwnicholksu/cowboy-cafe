/*
* Author: Grant Nichol
* Class: PecosPulledPork.cs
* Purpose: A class representing the Pecos Pulled Pork entree
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Pecos Pulled Pork entree
    /// </summary>
    public class PecosPulledPork : Entree
    {
        /// <summary>
        /// The price of the pulled pork
        /// </summary>
        public override double Price
        {
            get
            {
                return 5.88;
            }
        }

        /// <summary>
        /// The calories of the pulled pork
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 528;
            }
        }

        private bool _bread = true;
        /// <summary>
        /// Wether or not to have bread
        /// </summary>
        public bool Bread
        {
            get { return _bread; }
            set {
                _bread = value;
                NotifyOfPropertyChange("Bread");
            }
        }

        private bool _pickle = true;
        /// <summary>
        /// Wether or not to have pickle
        /// </summary>
        public bool Pickle
        {
            get { return _pickle; }
            set
            {
                _pickle = value;
                NotifyOfPropertyChange("Pickle");
            }
        }

        /// <summary>
        /// Display Name
        /// </summary>
        public override string DisplayName => "Pecos Pulled Pork";

        /// <summary>
        /// Description
        /// </summary>
        public override string Description => "BBQ pulled pork sandwich";

        /// <summary>
        /// Get the list of special instruction
        /// </summary>
        public override List<String> SpecialInstructions
        {
            get
            {
                var instructions = new List<String>();

                if (!Bread) instructions.Add("hold bread");
                if (!Pickle) instructions.Add("hold pickle");

                return instructions;
            }
        }

        /// <summary>
        /// Get a nice string representation of this entree
        /// </summary>
        /// <returns>String of entree</returns>
        public override string ToString()
        {
            return "Pecos Pulled Pork";
        }
    }
}
