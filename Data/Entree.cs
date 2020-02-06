﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{

    /// <summary>
    /// The base class for an entree
    /// </summary>
    public abstract class Entree
    {
        /// <summary>
        /// The number of calories in the entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The price of the entree
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// The special instructions for this entree 
        /// </summary>
        public abstract List<String> SpecialInstructions { get; }
    }
}