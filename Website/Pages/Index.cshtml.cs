using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CowboyCafe.Data;

namespace CowboyCafe.Website.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// String to  select text with
        /// </summary>
//        [BindProperty]
        public string SearchTerm { get; set; }

        /// <summary>
        /// Types of order items to show
        /// </summary>
//        [BindProperty]
        public string[] Types { get; set; }

        /// <summary>
        /// Minimum allowed calories
        /// </summary>
        public uint? MinCalories { get; set; }

        /// <summary>
        /// Maximum allowed calories
        /// </summary>
        public uint? MaxCalories { get; set; }

        /// <summary>
        /// Minimum price
        /// </summary>
        public double? MinPrice { get; set; }

        /// <summary>
        /// Maximum price
        /// </summary>
        public double? MaxPrice { get; set; }

        /// <summary>
        /// Type, Collection pairs to show
        /// </summary>
        public List<Tuple<string, IEnumerable<IOrderItem>>> DisplayCollections { get; set; } = new List<Tuple<string, IEnumerable<IOrderItem>>>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string SearchTerm, string[] Types, uint? MinCalories, uint? MaxCalories, double? MinPrice, double? MaxPrice)
        {
            this.SearchTerm = SearchTerm;
            this.Types = Types;
            this.MinCalories = MinCalories;
            this.MaxCalories = MaxCalories;
            this.MinPrice = MinPrice;
            this.MaxPrice = MaxPrice;

            if (this.Types == null || this.Types.Length == 0) this.Types = Menu.Types; // Select all if none selected
            foreach(string type in this.Types)
            {
                var menu = Menu.GetMenuByType(type);
                menu = Menu.Search(menu, SearchTerm);
                menu = Menu.FilterByCalories(menu, MinCalories, MaxCalories);
                menu = Menu.FilterByPrice(menu, MinPrice, MaxPrice);
                DisplayCollections.Add(Tuple.Create(type, menu));
            }
        }
    }
}
