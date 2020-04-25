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
using System.Windows.Shapes;
using CowboyCafe.Data;
using CowboyCafe.Extension;

namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Interaction logic for CashPaymentControl.xaml
    /// </summary>
    public partial class CashPaymentControl : UserControl
    {
        // Store the parent of this control
        TransactionControl parent;

        /// <summary>
        /// The total cost of this transaction
        /// </summary>
        private double total;

        /// <summary>
        /// MoneyManager that holds both sets of money
        /// </summary>
        private MoneyManager manager;

        /// <summary>
        /// Initialize the control
        /// </summary>
        public CashPaymentControl(double total)
        {
            InitializeComponent();

            manager = new MoneyManager();
            DataContext = manager;

            this.total = total;
        }

        /// <summary>
        /// Find the parent when loaded
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">Event arguments</param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            parent = this.FindAncestor<TransactionControl>();
        }

        /// <summary>
        /// Calculate the change to give
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCalculateChange(object sender, RoutedEventArgs e)
        {
            if (manager.Hand.TotalValue < total) parent.MessageBox.Text = "Error: Not Enough Money for Transaction";
            else
            {
                parent.Transaction.AmountPaid = manager.Hand.TotalValue;
                try
                {
                    parent.MessageBox.Text = $"Change To Give:\n{manager.CalculateChange(total)}";
                    DoneButton.IsEnabled = true;
                    ChangeButton.IsEnabled = false;
                }
                catch (InvalidOperationException ex)
                { // Unable to give change
                    parent.MessageBox.Text = "Error: Unable to give change. Try paying a smaller amount";
                }

            }
        }

        /// <summary>
        /// Complete the transaction when ready
        /// </summary>
        /// <param name="sender">Sending Object</param>
        /// <param name="e">Routed Event Args</param>
        private void OnDone(object sender, RoutedEventArgs e)
        {
            parent.FinishTransaction();
        }
    }
}
