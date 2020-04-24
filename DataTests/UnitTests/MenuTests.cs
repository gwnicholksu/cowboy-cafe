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

            foreach(Type type in EntreeTypes)
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

            foreach(Type type in DrinkTypes)
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

            foreach(Type type in allList )
            {
                Assert.True(all.Where(i => i.GetType() == type).Count() == 1);
            }
        }
    }
}
