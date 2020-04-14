using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Methods to obtain menu items
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Get a list of all entrees in the cafe
        /// </summary>
        /// <returns>All the entrees in the cafe</returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            return new List<IOrderItem>
            {
                new AngryChicken(),
                new CowpokeChili(),
                new DakotaDoubleBurger(),
                new PecosPulledPork(),
                new RustlersRibs(),
                new TexasTripleBurger(),
                new TrailBurger()
            };
        }

        /// <summary>
        /// Get a list of all available sides
        /// </summary>
        /// <returns>All the available sides</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            return new List<IOrderItem>
            {
                new BakedBeans(),
                new ChiliCheeseFries(),
                new CornDodgers(),
                new PanDeCampo()
            };
        }

        /// <summary>
        /// Get a list of all the drinks
        /// </summary>
        /// <returns>List of all drinks</returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            return new List<IOrderItem>
            {
                new CowboyCoffee(),
                new JerkedSoda(),
                new TexasTea(),
                new Water()
            };
        }

        /// <summary>
        /// Get a complete list of items on the menu
        /// </summary>
        /// <returns>A complete list of menu items</returns>
        public static IEnumerable<IOrderItem> CompleteMenu()
        {
            var list = new List<IOrderItem>();
            list.AddRange(Entrees());
            list.AddRange(Sides());
            list.AddRange(Drinks());
            return list;
        }

        /// <summary>
        /// Get a nice name for a menu item
        /// </summary>
        /// <param name="item">Item to find the name of</param>
        /// <returns>Name of the item</returns>
        public static string GetMenuName(IOrderItem item)
        {
            if (item is Side || item is CowboyCoffee || item is Water)
            {
                return Regex.Replace(item.ToString(), "^\\S+ ", ""); // The first word is the size for all sides
            }
            else if (item is JerkedSoda) return "Jerked Soda";
            else if (item is TexasTea) return "Texas Tea";
            else return item.ToString();
        }
    }
}
