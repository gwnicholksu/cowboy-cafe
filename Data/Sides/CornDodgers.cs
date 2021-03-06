﻿/*
* Author: Grant Nichol
* Class: CornDodgers.cs
* Purpose: A class representing the Corn Dodgers side
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Corn Dodgers side
    /// </summary>
    public class CornDodgers : Side
    {
        /// <summary>
        /// Gets the price of the side
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.59;
                    case Size.Medium:
                        return 1.79;
                    case Size.Large:
                        return 1.99;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Gets the calories of the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 512;
                    case Size.Medium:
                        return 685;
                    case Size.Large:
                        return 717;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Display name
        /// </summary>
        public override string DisplayName => "Corn Dodgers";

        /// <summary>
        /// Description
        /// </summary>
        public override string Description => "a traditional trail treat of cornbread";

        /// <summary>
        /// Get a nice string representation of side
        /// </summary>
        /// <returns>String of side</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(Size);
            ret.Append(" Corn Dodgers");
            return ret.ToString();
        }
    }
}
