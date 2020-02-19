/*
* Author: Grant Nichol
* Class: AngryChicken.cs
* Purpose: A class representing the Angry Chicken entree
*/

using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Angry Chicken entree
    /// </summary>
    public class AngryChicken : Entree
    {
        /// <summary>
        /// The price of the chicken
        /// </summary>
        public override double Price
        {
            get
            {
                return 5.99;
            }
        }

        /// <summary>
        /// The calories of the chicken
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 190;
            }
        }

        private bool bread = true;
        /// <summary>
        /// Wether or not to have bread
        /// </summary>
        public bool Bread
        {
            get { return bread; }
            set { bread = value; }
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

        /// <summary>
        /// Get the list of special instruction
        /// </summary>
        public override List<String> SpecialInstructions
        {
            get
            {
                var instructions = new List<String>();

                if (!bread) instructions.Add("hold bread");
                if (!pickle) instructions.Add("hold pickle");

                return instructions;
            }
        }

        /// <summary>
        /// Get a nice string representation of this entree
        /// </summary>
        /// <returns>String of entree</returns>
        public override string ToString()
        {
            return "Angry Chicken";
        }
    }
}
