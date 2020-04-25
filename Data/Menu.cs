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
        /// The possible types of order items
        /// </summary>
        public static string[] Types =
        {
            "Entree",
            "Side",
            "Drink"
        };

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
        /// Get the menu by the type of item
        /// </summary>
        /// <param name="type">The type of order item to get</param>
        /// <returns>A subset of the menu with specified type</returns>
        public static IEnumerable<IOrderItem> GetMenuByType(string type)
        {
            switch (type)
            {
                case "Entree": return Entrees();
                case "Drink": return Drinks();
                case "Side": return Sides();
                default: return new List<IOrderItem>();
            }
        }

        /// <summary>
        /// Search the provided collection and select names that match the search terms
        /// </summary>
        /// <param name="items">Collection of items to search through</param>
        /// <param name="search">String to search for</param>
        /// <returns>Collection of search results</returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> items, string search)
        {
            if (search == null) return items;

            List<IOrderItem> retList = new List<IOrderItem>();
            foreach(IOrderItem item in items)
            {

                if(item.DisplayName.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                {
                    retList.Add(item);
                }
            }

            return retList;
        }

        /// <summary>
        /// Filter a collection by a minimum and maximum bound of calories
        /// </summary>
        /// <param name="items">Colection of items to filter</param>
        /// <param name="min">Minimum allowed calories</param>
        /// <param name="max">Maximum allowed calories</param>
        /// <returns>Filtered collection</returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> items, uint? min, uint? max)
        {
            if (min == null) min = 0;
            if (max == null) max = uint.MaxValue;

            var retList = new List<IOrderItem>();
            foreach(var item in items)
            {
                if(item.Calories >= min && item.Calories <= max)
                {
                    retList.Add(item);
                }
            }
            return retList;
        }

        /// <summary>
        /// Filter a collection by a minimum and maximum bound of price
        /// </summary>
        /// <param name="items">Colection of items to filter</param>
        /// <param name="min">Minimum allowed price</param>
        /// <param name="max">Maximum allowed price</param>
        /// <returns>Filtered collection</returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> items, double? min, double? max)
        {
            if (min == null) min = 0;
            if (max == null) max = double.MaxValue;

            var retList = new List<IOrderItem>();
            foreach (var item in items)
            {
                if (item.Price >= min && item.Price <= max)
                {
                    retList.Add(item);
                }
            }
            return retList;
        }
    }
}
