﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Trailburger entree
    /// </summary>
    public class TrailBurger : Entree
    {
        /// <summary>
        /// The price of the burger
        /// </summary>
        public override double Price
        {
            get
            {
                return 4.50;
            }
        }

        /// <summary>
        /// The calories of the burger
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 288;
            }
        }

        private bool ketchup = true;
        /// <summary>
        /// Wether or not to have ketchup
        /// </summary>
        public bool Ketchup
        {
            get { return ketchup; }
            set { ketchup = value; }
        }

        private bool mustard = true;
        /// <summary>
        /// Wether or not to have mustard
        /// </summary>
        public bool Mustard
        {
            get { return mustard; }
            set { mustard = value; }
        }

        private bool pickle = true;
        /// <summary>
        /// Wether or not to have pickle
        /// </summary>
        public bool Pickle
        {
            get { return pickle; }
            set { pickle = value; }
        }

        private bool cheese = true;
        /// <summary>
        /// Wether or not to have cheese
        /// </summary>
        public bool Cheese
        {
            get { return cheese; }
            set { cheese = value; }
        }

        private bool bun = true;
        /// <summary>
        /// Wether or not to have a bun
        /// </summary>
        public bool Bun
        {
            get { return bun; }
            set { bun = value; }
        }

        /// <summary>
        /// Get the list of special instruction
        /// </summary>
        public override List<String> SpecialInstructions
        {
            get
            {
                var instructions = new List<String>();

                if (!ketchup) instructions.Add("hold ketchup");
                if (!pickle) instructions.Add("hold pickle");
                if (!mustard) instructions.Add("hold mustard");
                if (!cheese) instructions.Add("hold cheese");
                if (!bun) instructions.Add("hold bun");

                return instructions;
            }
        }
    }
}
