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
using System.ComponentModel;
using CowboyCafe.ExtensionMethods;

namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        OrderControl orderControl;

        /// <summary>
        /// Initialize the Order Summary Control
        /// </summary>
        public OrderSummaryControl()
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
        /// Start modifying the selected item
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="args">Arguments</param>
        void SelectItem(object sender, SelectionChangedEventArgs args)
        {
            if (sender is ListBox lb)
            {
                var lbi = lb.SelectedItem;
                if (lbi is IOrderItem item)
                    orderControl.SwapScreen(new ModifyItemControl(item));
            }
        }

        /// <summary>
        /// Remove the item from order
        /// </summary>
        /// <param name="sender">Sending button</param>
        /// <param name="e">Routed event args</param>
        private void OnRemoveItem(object sender, RoutedEventArgs e)
        {
            if((sender as Button).DataContext is IOrderItem item)
            {
                orderControl.RemoveAndStopEditing(item);
            }
        }
    }
}
