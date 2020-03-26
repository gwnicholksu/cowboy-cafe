/*
* Author: Grant Nichol
* Class: DakotaDoubleBurger.cs
* Purpose: A class representing the Dakota Double Burger entree
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Dakota Double Burger entree
    /// </summary>
    public class DakotaDoubleBurger : Entree
    {
        /// <summary>
        /// The price of the burger
        /// </summary>
        public override double Price
        {
            get
            {
                return 5.20;
            }
        }

        /// <summary>
        /// The calories of the burger
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 464;
            }
        }

        private bool _ketchup = true;
        /// <summary>
        /// Wether or not to have ketchup
        /// </summary>
        public bool Ketchup
        {
            get { return _ketchup; }
            set {
                _ketchup = value;
                NotifyOfPropertyChange("Ketchup");
            }
        }

        private bool _mustard = true;
        /// <summary>
        /// Wether or not to have mustard
        /// </summary>
        public bool Mustard
        {
            get { return _mustard; }
            set {
                _mustard = value;
                NotifyOfPropertyChange("Mustard");
            }
        }

        private bool _pickle = true;
        /// <summary>
        /// Wether or not to have pickle
        /// </summary>
        public bool Pickle
        {
            get { return _pickle; }
            set {
                _pickle = value;
                NotifyOfPropertyChange("Pickle");
            }
        }

        private bool _cheese = true;
        /// <summary>
        /// Wether or not to have cheese
        /// </summary>
        public bool Cheese
        {
            get { return _cheese; }
            set {
                _cheese = value;
                NotifyOfPropertyChange("Cheese");
            }
        }

        private bool _tomato = true;
        /// <summary>
        /// Wether or not to have tomato
        /// </summary>
        public bool Tomato
        {
            get { return _tomato; }
            set {
                _tomato = value;
                NotifyOfPropertyChange("Tomato");
            }
        }

        private bool _lettuce = true;
        /// <summary>
        /// Wether or not to have lettuce
        /// </summary>
        public bool Lettuce
        {
            get { return _lettuce; }
            set {
                _lettuce = value;
                NotifyOfPropertyChange("Lettuce");
            }
        }

        private bool _mayo = true;
        /// <summary>
        /// Wether or not to have mayo
        /// </summary>
        public bool Mayo
        {
            get { return _mayo; }
            set {
                _mayo = value;
                NotifyOfPropertyChange("Mayo");
            }
        }

        private bool _bun = true;
        /// <summary>
        /// Wether or not to have a bun
        /// </summary>
        public bool Bun
        {
            get { return _bun; }
            set {
                _bun = value;
                NotifyOfPropertyChange("Bun");
            }
        }

        /// <summary>
        /// Get the list of special instruction
        /// </summary>
        public override List<String> SpecialInstructions
        {
            get
            {
                var instructions = new List<String>();

                if (!Ketchup) instructions.Add("hold ketchup");
                if (!Pickle) instructions.Add("hold pickle");
                if (!Mustard) instructions.Add("hold mustard");
                if (!Cheese) instructions.Add("hold cheese");
                if (!Tomato) instructions.Add("hold tomato");
                if (!Lettuce) instructions.Add("hold lettuce");
                if (!Mayo) instructions.Add("hold mayo");
                if (!Bun) instructions.Add("hold bun");

                return instructions;
            }
        }

        /// <summary>
        /// Get a nice string representation of this entree
        /// </summary>
        /// <returns>String of entree</returns>
        public override string ToString()
        {
            return "Dakota Double Burger";
        }
    }
}
