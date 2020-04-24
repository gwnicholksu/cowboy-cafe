/*
* Author: Grant Nichol
* Class: PanDeCampo.cs
* Purpose: A class representing the Pan de Campo side
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Pan de Campo side
    /// </summary>
    public class PanDeCampo : Side
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
                        return 227;
                    case Size.Medium:
                        return 269;
                    case Size.Large:
                        return 367;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Display name
        /// </summary>
        public override string DisplayName => "Pan de Campo";

        /// <summary>
        /// Description
        /// </summary>
        public override string Description => "pan-fried bread";

        /// <summary>
        /// Get a nice string representation of side
        /// </summary>
        /// <returns>String of side</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(Size);
            ret.Append(" Pan de Campo");
            return ret.ToString();
        }
    }
}
