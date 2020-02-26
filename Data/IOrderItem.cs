using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// An interface for all items that can be ordered
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// The price of the item
        /// </summary>
        double Price { get; }

        /// <summary>
        /// The special instructions to have
        /// </summary>
        List<string> SpecialInstructions { get; }
    }
}
