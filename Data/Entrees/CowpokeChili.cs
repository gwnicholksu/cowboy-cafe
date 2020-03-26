/*
* Author: Grant Nichol
* Class: CowpokeChili.cs
* Purpose: A class representing the Cowpoke Chili entree
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Cowpoke Chili entree
    /// </summary>
    public class CowpokeChili : Entree
    {
        private bool _cheese = true;
        /// <summary>
        /// If the chili is topped with cheese
        /// </summary>
        public bool Cheese
        {
            get { return _cheese; }
            set {
                _cheese = value;
                NotifyOfPropertyChange("Cheese");
            }
        }

        private bool _sourCream = true;
        /// <summary>
        /// If the chili is topped with sour cream
        /// </summary>
        public bool SourCream
        {
            get { return _sourCream; }
            set {
                _sourCream = value;
                NotifyOfPropertyChange("SourCream");
            }
        }

        private bool _greenOnions = true;
        /// <summary>
        /// If the chili is topped with green onions
        /// </summary>
        public bool GreenOnions
        {
            get { return _greenOnions; }
            set {
                _greenOnions = value;
                NotifyOfPropertyChange("GreenOnions");
            }
        }

        private bool _tortillaStrips = true;
        /// <summary>
        /// If the chili is topped with tortilla strips
        /// </summary>
        public bool TortillaStrips
        {
            get { return _tortillaStrips; }
            set {
                _tortillaStrips = value;
                NotifyOfPropertyChange("TortillaStrips");
            }
        }

        /// <summary>
        /// The price of the chili
        /// </summary>
        public override double Price
        {
            get
            {
                return 6.10;
            }
        }

        /// <summary>
        /// The calories of the chili
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 171;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the chili
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Cheese) instructions.Add("hold cheese");
                if (!SourCream) instructions.Add("hold sour cream");
                if (!GreenOnions) instructions.Add("hold green onions");
                if (!TortillaStrips) instructions.Add("hold tortilla strips");

                return instructions;
            }
        }

        /// <summary>
        /// Get a nice string representation of this entree
        /// </summary>
        /// <returns>String of entree</returns>
        public override string ToString()
        {
            return "Cowpoke Chili";
        }
    }
}

