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

namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        /// <summary>
        /// Initialize the OrderControl view
        /// </summary>
        public OrderControl()
        {
            DataContext = new Order();
            InitializeComponent();
            SelectHolder.Child = new MenuItemSelectionControl();
        }

        /// <summary>
        /// Method to cancel an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            DataContext = new Order();
        }

        /// <summary>
        /// Method to complete an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrder(object sender, RoutedEventArgs e)
        {
            DataContext = new Order();
        }

        private void ItemSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            SelectHolder.Child = new MenuItemSelectionControl();
        }
    }
}
