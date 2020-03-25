using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks; // Because it does not like generic object SetValue tasks

namespace CowboyCafe.DataTests
{
    public class TestPropertyChanges
    {

        [Theory]
        [InlineData(typeof(AngryChicken))]
        [InlineData(typeof(CowpokeChili))]
        [InlineData(typeof(DakotaDoubleBurger))]
        [InlineData(typeof(PecosPulledPork))]
        [InlineData(typeof(RustlersRibs))]
        [InlineData(typeof(TexasTripleBurger))]
        [InlineData(typeof(TrailBurger))]
        [InlineData(typeof(CowboyCoffee))]
        [InlineData(typeof(JerkedSoda))]
        [InlineData(typeof(TexasTea))]
        [InlineData(typeof(Water))]
        [InlineData(typeof(BakedBeans))]
        [InlineData(typeof(ChiliCheeseFries))]
        [InlineData(typeof(CornDodgers))]
        [InlineData(typeof(PanDeCampo))]
        public void AllImplementINotifyPropertyChanged(Type testType)
        {
            object testObject = Activator.CreateInstance(testType);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(testObject);
        }

        [Theory]
        // Entree Tests
        [InlineData(typeof(AngryChicken), "Bread", false)]
        [InlineData(typeof(AngryChicken), "Pickle", false)]

        [InlineData(typeof(CowpokeChili), "Cheese", false)]
        [InlineData(typeof(CowpokeChili), "SourCream", false)]
        [InlineData(typeof(CowpokeChili), "GreenOnions", false)]
        [InlineData(typeof(CowpokeChili), "TortillaStrips", false)]

        [InlineData(typeof(DakotaDoubleBurger), "Ketchup", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Pickle", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Mustard", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Cheese", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Tomato", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Lettuce", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Mayo", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Bun", false)]

        [InlineData(typeof(PecosPulledPork), "Bread", false)]
        [InlineData(typeof(PecosPulledPork), "Pickle", false)]

        [InlineData(typeof(TexasTripleBurger), "Ketchup", false)]
        [InlineData(typeof(TexasTripleBurger), "Pickle", false)]
        [InlineData(typeof(TexasTripleBurger), "Mustard", false)]
        [InlineData(typeof(TexasTripleBurger), "Cheese", false)]
        [InlineData(typeof(TexasTripleBurger), "Tomato", false)]
        [InlineData(typeof(TexasTripleBurger), "Lettuce", false)]
        [InlineData(typeof(TexasTripleBurger), "Mayo", false)]
        [InlineData(typeof(TexasTripleBurger), "Bun", false)]
        [InlineData(typeof(TexasTripleBurger), "Bacon", false)]
        [InlineData(typeof(TexasTripleBurger), "Egg", false)]

        [InlineData(typeof(TrailBurger), "Ketchup", false)]
        [InlineData(typeof(TrailBurger), "Pickle", false)]
        [InlineData(typeof(TrailBurger), "Mustard", false)]
        [InlineData(typeof(TrailBurger), "Cheese", false)]
        [InlineData(typeof(TrailBurger), "Bun", false)]

        //Drink Tests
        [InlineData(typeof(CowboyCoffee), "Ice", true)]
        [InlineData(typeof(CowboyCoffee), "RoomForCream", true)]
        [InlineData(typeof(CowboyCoffee), "Decaf", true)]
        [InlineData(typeof(CowboyCoffee), "Size", Size.Large)]

        [InlineData(typeof(JerkedSoda), "Ice", false)]
        [InlineData(typeof(JerkedSoda), "Size", Size.Large)]

        [InlineData(typeof(TexasTea), "Ice", false)]
        [InlineData(typeof(TexasTea), "Sweet", false)]
        [InlineData(typeof(TexasTea), "Lemon", true)]
        [InlineData(typeof(TexasTea), "Size", Size.Large)]

        [InlineData(typeof(Water), "Ice", false)]
        [InlineData(typeof(Water), "Lemon", true)]
        [InlineData(typeof(Water), "Size", Size.Large)]

        //Side Tests
        [InlineData(typeof(BakedBeans), "Size", Size.Large)]
        [InlineData(typeof(ChiliCheeseFries), "Size", Size.Large)]
        [InlineData(typeof(CornDodgers), "Size", Size.Large)]
        [InlineData(typeof(PanDeCampo), "Size", Size.Large)]
        public void PropertyChangesShouldInvokePropertyChanged(Type typeToTest, string propertyToChange, object valueToSet)
        {
            var testObject = (IOrderItem)Activator.CreateInstance(typeToTest);
            Assert.PropertyChanged(testObject, propertyToChange, () =>
            {
                typeToTest.GetProperty(propertyToChange).SetValue(testObject, valueToSet);
            });
        }
        
        [Theory]
        // Entree Tests
        [InlineData(typeof(AngryChicken), "Bread", false)]
        [InlineData(typeof(AngryChicken), "Pickle", false)]

        [InlineData(typeof(CowpokeChili), "Cheese", false)]
        [InlineData(typeof(CowpokeChili), "SourCream", false)]
        [InlineData(typeof(CowpokeChili), "GreenOnions", false)]
        [InlineData(typeof(CowpokeChili), "TortillaStrips", false)]

        [InlineData(typeof(DakotaDoubleBurger), "Ketchup", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Pickle", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Mustard", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Cheese", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Tomato", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Lettuce", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Mayo", false)]
        [InlineData(typeof(DakotaDoubleBurger), "Bun", false)]

        [InlineData(typeof(PecosPulledPork), "Bread", false)]
        [InlineData(typeof(PecosPulledPork), "Pickle", false)]

        [InlineData(typeof(TexasTripleBurger), "Ketchup", false)]
        [InlineData(typeof(TexasTripleBurger), "Pickle", false)]
        [InlineData(typeof(TexasTripleBurger), "Mustard", false)]
        [InlineData(typeof(TexasTripleBurger), "Cheese", false)]
        [InlineData(typeof(TexasTripleBurger), "Tomato", false)]
        [InlineData(typeof(TexasTripleBurger), "Lettuce", false)]
        [InlineData(typeof(TexasTripleBurger), "Mayo", false)]
        [InlineData(typeof(TexasTripleBurger), "Bun", false)]
        [InlineData(typeof(TexasTripleBurger), "Bacon", false)]
        [InlineData(typeof(TexasTripleBurger), "Egg", false)]

        [InlineData(typeof(TrailBurger), "Ketchup", false)]
        [InlineData(typeof(TrailBurger), "Pickle", false)]
        [InlineData(typeof(TrailBurger), "Mustard", false)]
        [InlineData(typeof(TrailBurger), "Cheese", false)]
        [InlineData(typeof(TrailBurger), "Bun", false)]

        //Drink Tests
        [InlineData(typeof(CowboyCoffee), "Ice", true)]
        [InlineData(typeof(CowboyCoffee), "RoomForCream", true)]

        [InlineData(typeof(JerkedSoda), "Ice", false)]

        [InlineData(typeof(TexasTea), "Ice", false)]
        [InlineData(typeof(TexasTea), "Lemon", true)]

        [InlineData(typeof(Water), "Ice", false)]
        [InlineData(typeof(Water), "Lemon", true)]
        public void PropertyChangesShouldInvokePropertyChangedForSpecialInstructions(Type typeToTest, string propertyToChange, object valueToSet)
        {
            var testObject = (IOrderItem)Activator.CreateInstance(typeToTest);
            Assert.PropertyChanged(testObject, propertyToChange,() =>
            {
                typeToTest.GetProperty(propertyToChange).SetValue(testObject, valueToSet);
            });
        }

        [Theory]
        [InlineData(typeof(CowboyCoffee))]
        [InlineData(typeof(JerkedSoda))]
        [InlineData(typeof(TexasTea))]
        [InlineData(typeof(Water))]
        [InlineData(typeof(BakedBeans))]
        [InlineData(typeof(ChiliCheeseFries))]
        [InlineData(typeof(CornDodgers))]
        [InlineData(typeof(PanDeCampo))]
        public void SizeChangeShouldInvokePropertyChangedForPriceAndCalories(Type typeToTest)
        {
            var testObject = (IOrderItem)Activator.CreateInstance(typeToTest);
            Assert.PropertyChanged(testObject, "Price", () =>
            {
                typeToTest.GetProperty("Size").SetValue(testObject, Size.Large);
            });

            Assert.PropertyChanged(testObject, "Calories", () =>
            {
                typeToTest.GetProperty("Size").SetValue(testObject, Size.Medium);
            });
        }
    }
}
