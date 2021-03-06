﻿using System;
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

namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        // Parent MainWindow
        private MainWindow parent;

        /// <summary>
        /// Initialize the OrderControl view
        /// </summary>
        public OrderControl()
        {
            DataContext = new Order();
            InitializeComponent();
            SwapScreen(new MenuItemSelectionControl());
        }

        /// <summary>
        /// Find the main window that this is a part of
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            parent = this.FindAncestor<MainWindow>();
        }

        /// <summary>
        /// Swap the scren to a specified element
        /// </summary>
        /// <param name="elem">The element to swap to</param>
        public void SwapScreen(UIElement elem)
        {
            SelectHolder.Content = elem;
        }

        /// <summary>
        /// Remove and item from the order and stop editing it if we are
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void RemoveAndStopEditing(IOrderItem item)
        {
            if (SelectHolder.Content is ModifyItemControl modView)
                if (modView.DataContext is IOrderItem editItem)
                    if (editItem == item)
                        SwapScreen(new MenuItemSelectionControl());

            (DataContext as Order).Remove(item);
        }

        /// <summary>
        /// Method to cancel an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            DataContext = new Order();
            SwapScreen(new MenuItemSelectionControl());
        }

        /// <summary>
        /// Method to complete an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrder(object sender, RoutedEventArgs e)
        {
            parent.SwapScreen(new TransactionControl(DataContext as Order));
        }

        /// <summary>
        /// Handle button to bring back the menuitem selection control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSelection(object sender, RoutedEventArgs e)
        {
            SwapScreen(new MenuItemSelectionControl());
        }
    }
}
