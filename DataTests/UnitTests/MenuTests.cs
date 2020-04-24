using System;
using System.Collections.Generic;
using Xunit;
using System.Text;
using CowboyCafe.Data;
using System.Linq;

namespace CowboyCafe.DataTests
{
    public class MenuTests
    {
        Type[] EntreeTypes =
        {
            typeof(AngryChicken),
            typeof(CowpokeChili),
            typeof(DakotaDoubleBurger),
            typeof(PecosPulledPork),
            typeof(RustlersRibs),
            typeof(TexasTripleBurger),
            typeof(TrailBurger)
        };

        Type[] SideTypes =
        {
            typeof(BakedBeans),
            typeof(ChiliCheeseFries),
            typeof(CornDodgers),
            typeof(PanDeCampo)
        };

        Type[] DrinkTypes =
        {
            typeof(CowboyCoffee),
            typeof(JerkedSoda),
            typeof(TexasTea),
            typeof(Water)
        };

        [Fact]
        void EntreesGivesAllEntrees()
        {
            IEnumerable<IOrderItem> entrees = Menu.Entrees();

            Assert.All(entrees, i => EntreeTypes.Contains(i.GetType())); // Insure that there are no unwanted types

            foreach (Type type in EntreeTypes)
            {
                Assert.True(entrees.Where(i => i.GetType() == type).Count() == 1);
            }
        }

        [Fact]
        void SidesGivesAllSides()
        {
            IEnumerable<IOrderItem> sides = Menu.Sides();

            Assert.All(sides, i => SideTypes.Contains(i.GetType())); // Insure that there are no unwanted types

            foreach (Type type in SideTypes)
            {
                Assert.True(sides.Where(i => i.GetType() == type).Count() == 1);
            }
        }

        [Fact]
        void DrinksGivesAllDrinks()
        {
            IEnumerable<IOrderItem> drinks = Menu.Drinks();

            Assert.All(drinks, i => DrinkTypes.Contains(i.GetType())); // Insure that there are no unwanted types

            foreach (Type type in DrinkTypes)
            {
                Assert.True(drinks.Where(i => i.GetType() == type).Count() == 1);
            }
        }

        [Fact]
        void CompleteMenuGivesAll()
        {
            IEnumerable<IOrderItem> all = Menu.CompleteMenu();

            var allList = new List<Type>(EntreeTypes);
            allList.AddRange(DrinkTypes);
            allList.AddRange(SideTypes);

            Assert.All(all, i => allList.Contains(i.GetType())); // Insure that there are no unwanted types

            foreach (Type type in allList)
            {
                Assert.True(all.Where(i => i.GetType() == type).Count() == 1);
            }
        }

        [Theory]
        [InlineData(new string[]{"test"},"test",new string[]{"test"})]
        [InlineData(new string[]{"testing"},"test",new string[]{"testing"})]
        [InlineData(new string[]{"testing","not testing"},"no",new string[]{"not testing"})]
        [InlineData(new string[]{"might be testing","testing"},"no",new string[]{})]
        [InlineData(new string[]{"some testing","testing"},"",new string[]{"some testing","testing"})]
        void FilterNameTest(string[] startNames, string filterText, string[] finalNames)
        {
            List<MockOrderItem> startList = new List<MockOrderItem>();
            foreach(var name in startNames)
            {
                startList.Add(new MockOrderItem(name, 0, 0.00)); // Make list with certain names
            }

            var final = Menu.Search(startList, filterText);

            List<string> searchedNames = new List<string>();
            foreach(var item in final)
            {
                searchedNames.Add(item.DisplayName);
            }

            Assert.Equal(finalNames, searchedNames);
        }

        [Theory]
        [InlineData(new uint[] { }, 0u, 100u, new uint[] { })]
        [InlineData(new uint[] {5}, 0u, 100u, new uint[] {5})]
        [InlineData(new uint[] {6, 200}, 0u, 100u, new uint[] {6})]
        [InlineData(new uint[] {4, 400}, 0u, null, new uint[] {4, 400})]
        [InlineData(new uint[] {4, 300}, null, 100u, new uint[] {4})]
        [InlineData(new uint[] {4, 300}, null, null, new uint[] {4, 300})]
        void FilterCaloriesTest(uint[] startCals, uint? minCal, uint? maxCal, uint[] finalCals)
        {
            List<MockOrderItem> startList = new List<MockOrderItem>();
            foreach(var cal in startCals)
            {
                startList.Add(new MockOrderItem("", cal, 0.00));
            }

            var final = Menu.FilterByCalories(startList, minCal, maxCal);

            List<uint> filteredCals = new List<uint>();
            foreach(var item in final)
            {
                filteredCals.Add(item.Calories);
            }
            Assert.Equal(finalCals, filteredCals);
        }

        [Theory]
        [InlineData(new double[] { }, 0, 100, new double[] { })]
        [InlineData(new double[] {5}, 0, 100, new double[] {5})]
        [InlineData(new double[] {6, 200}, 0, 100, new double[] {6})]
        [InlineData(new double[] {4, 400}, 0, null, new double[] {4, 400})]
        [InlineData(new double[] {4, 300}, null, 100, new double[] {4})]
        [InlineData(new double[] {4, 300}, null, null, new double[] {4, 300})]
        void FilterPriceTest(double[] startPrice, double? minPrice, double? maxPrice, double[] finalPrices)
        {
            List<MockOrderItem> startList = new List<MockOrderItem>();
            foreach(var price in startPrice)
            {
                startList.Add(new MockOrderItem("", 0, price));
            }

            var final = Menu.FilterByPrice(startList, minPrice, maxPrice);

            List<double> filteredPrices = new List<double>();
            foreach(var item in final)
            {
                filteredPrices.Add(item.Price);
            }
            Assert.Equal(finalPrices, filteredPrices);
        }
    }
}
