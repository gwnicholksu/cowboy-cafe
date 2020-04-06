using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CowboyCafe.Data;
using CowboyCafe.Extension;
using System.Reflection;

namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        private OrderControl orderControl;

        /// <summary>
        /// Initialize the Menu Selection Control
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to run when the control is loaded
        /// </summary>
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
        }

        /// <summary>
        /// Find the desired type from tag and add that item to the order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemAddButtonClicked(object sender, RoutedEventArgs e)
        {
            if(DataContext is Order order)
            {
                if (sender is ItemButton button)
                {
                    Type itemType = button.OrderItem;
                    if (itemType != null)
                    {
                        var itemConstructor = itemType.GetConstructor(new Type[] { });
                        if (itemConstructor != null)
                        {
                            object possibleItem = itemConstructor.Invoke(new Type[] { });
                            if(possibleItem is IOrderItem item)
                            { 
                                order.Add(item);
                                if(!(item is RustlersRibs)) // Don't change view if certain item
                                    orderControl.SwapScreen(new ModifyItemControl(item));
                            }
                        }
                    }
                }
            }
        }
    }
}
