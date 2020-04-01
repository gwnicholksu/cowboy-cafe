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
using CowboyCafe.ExtensionMethods;
using CowboyCafe.Data;
using CashRegister;

namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        // The window that is the parent
        MainWindow parent;

        // The data for this transaction
        public Transaction Transaction { get; private set; }
        
        /// <summary>
        /// Initialize the Transaction Control
        /// </summary>
        /// <param name="order">The order that this transaction pertains to</param>
        public TransactionControl(Order order)
        {
            InitializeComponent();

            Transaction = new Transaction(order);
            DataContext = Transaction;
        }

        /// <summary>
        /// Find the main window that this is a part of
        /// </summary>
        /// <param name="sender">Sending object</param>
        /// <param name="e">Event arguments</param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            parent = this.FindAncestor<MainWindow>();
        }

        /// <summary>
        /// Change to a new ordercontrol when cancelling transaction
        /// </summary>
        /// <param name="sender">Sending object</param>
        /// <param name="e">Event arguments</param>
        private void OnCancelTransaction(object sender, RoutedEventArgs e)
        {
            parent.SwapScreen(new OrderControl());
        }

        /// <summary>
        /// Attempt to pay with credit
        /// </summary>
        /// <param name="sender">Sending object</param>
        /// <param name="e">Event arguments</param>
        private void OnPayWithCredit(object sender, RoutedEventArgs e)
        {
            CardTerminal cardTerminal = new CardTerminal();

            ResultCode code = cardTerminal.ProcessTransaction(Transaction.Total);
            switch (code)
            {
                case ResultCode.Success:
                    Transaction.PaymentMethod = PaymentMethod.Credit;
                    Transaction.AmountPaid = Transaction.Total;
                    MessageBox.Text = "";
                    FinishTransaction();
                    break;
                case ResultCode.CancelledCard:
                    MessageBox.Text = "Error: Cancelled Card";
                    break;
                case ResultCode.InsufficentFunds:
                    MessageBox.Text = "Error: Insufficent Funds";
                    break;
                case ResultCode.ReadError:
                    MessageBox.Text = "Error: Read Error";
                    break;
                case ResultCode.UnknownErrror:
                    MessageBox.Text = "Error: Unknown Error";
                    break;
            }
        }

        /// <summary>
        /// Actually print receipt and finish
        /// </summary>
        private void FinishTransaction()
        {
            // Print receipt
            ReceiptPrinter receiptPrinter = new ReceiptPrinter();
            receiptPrinter.Print(Transaction.ToString());

            parent.SwapScreen(new OrderControl());
        }
    }
}
