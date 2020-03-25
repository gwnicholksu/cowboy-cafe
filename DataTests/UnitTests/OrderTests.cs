using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CowboyCafe.Data;
using Xunit;
using System.ComponentModel;
using Xunit.Sdk; // For PropertyChangedException

namespace CowboyCafe.DataTests
{
    class MockOrderItem : IOrderItem
    {
        private double price;
        public double Price {
            get { return price; }
            set
            {
                price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            } 
        }

        public List<string> SpecialInstructions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class OrderTests
    {
        [Fact]
        // Adding something ot the order should have it appear in the Items property
        public void AddedIOrderItemsAppearInItemsProperty()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            Assert.Contains(item, order.Items);
        }

        // Removing something from the order should remove it from the Items propert
        [Fact]
        // Adding something ot the order should have it appear in the Items property
        public void RemovedIOrderItemsDoesNotAppearInItemsProperty()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            order.Remove(item);

            Assert.DoesNotContain(item, order.Items);
        }

        [Theory]
        [InlineData(new double[] { })]
        [InlineData(new double[] { 0 })]
        [InlineData(new double[] { 10, 15, 18 })]
        [InlineData(new double[] { 20, -4, 3.6, 8 })]
        [InlineData(new double[] { -6, -4, -1, -9 })]
        // Get the price - needs to be right for the items we've added
        public void SubtotalShouldBeTheSumOfOrderItemPrices(IEnumerable<double> prices)
        {
            var order = new Order();
            double total = 0;
            foreach (var price in prices)
            {
                order.Add(new MockOrderItem() { Price = price });
                total += price;
            }

            Assert.Equal(order.Subtotal, total);
        }

        [Fact]
        public void ItemsShouldContaonOnlyAddedItems()
        {
            var items = new IOrderItem[]
            {
                new MockOrderItem(){ Price = 4 },
                new MockOrderItem(){ Price = 5 },
                new MockOrderItem(){ Price = 7 }
            };

            var order = new Order();
            foreach (var item in items)
            {
                order.Add(item);
            }

            Assert.Equal(items.Count(), order.Items.Count());
            foreach (var item in items)
            {
                Assert.Contains(item, order.Items);
            }
        }
        
        [Fact]
        public void ChangingPriceOfItemShouldInvokePropertyChangedForSubtotal()
        {
            var order = new Order();

            var item1 = new MockOrderItem() { Price = 3.0 };
            var item2 = new MockOrderItem() { Price = 2.0 };

            order.Add(item1);
            order.Add(item2);

            Assert.PropertyChanged(order, "Subtotal", () => { item1.Price = 1.0; });
            Assert.PropertyChanged(order, "Subtotal", () => { item2.Price = 1.0; });

            // Assert that the Sutotal is actually set right
            Assert.Equal(2.0, order.Subtotal);
        }

        [Fact]
        public void AddingItemShouldInvokePropertyChangedForItems()
        {
            var order = new Order();

            var item1 = new MockOrderItem();
            var item2 = new MockOrderItem();

            Assert.PropertyChanged(order, "Items", () => { order.Add(item1); });
            Assert.PropertyChanged(order, "Items", () => { order.Add(item2); });
        }

        [Fact]
        public void RemovingItemShouldInvokePropertyChangedForItems()
        {
            var order = new Order();

            var item1 = new MockOrderItem();

            order.Add(item1);

            Assert.PropertyChanged(order, "Items", () => { order.Remove(item1); });
        }

        [Fact]
        public void PropertyChangedInRemovedItemShouldNotInvokePropertyChanged()
        {
            var order = new Order();

            var item1 = new MockOrderItem() { Price = 1.0 };

            order.Add(item1);
            order.Remove(item1);

            // A bit of a hack to assert that the PropertyChanged assertion fails
            Assert.Throws<PropertyChangedException>(() =>
            {
                Assert.PropertyChanged(order, "Subtotal", () =>
                {
                    item1.Price = 2.0;
                });
            }); 
        }
    }
}
