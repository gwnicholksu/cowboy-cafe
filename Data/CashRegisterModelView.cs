using System;
using System.Collections.Generic;
using System.Text;
using CashRegister;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A ModelView to aid in using a CashDrawer
    /// </summary>
    public class CashRegisterModelView : INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event handlers
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The Model class for this ModelView
        /// </summary>
        CashDrawer drawer = new CashDrawer(); // Static so it stays the same the whole time

        /// <summary>
        /// The total current value of the drawer
        /// </summary>
        public double TotalValue => drawer.TotalValue;

        /// <summary>
        /// Invokes the PropertyChanged event for denomination properties
        /// and the TotalValue
        /// </summary>
        /// <param name="denomination">The property that is changing</param>
        void InvokePropertyChanged(string denomination)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(denomination));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalValue"));
        }

        /// <summary>
        /// Gets or sets the number of Pennies in the cash register
        /// </summary>
        public int Pennies
        {
            get => drawer.Pennies;

            set
            {
                if (drawer.Pennies == value || value < 0) return;
                int quantity = value - drawer.Pennies;
                if (quantity > 0) drawer.AddCoin(Coins.Penny, quantity);
                else drawer.RemoveCoin(Coins.Penny, -quantity);

                InvokePropertyChanged("Pennies");
            }
        }

        /// <summary>
        /// Gets or sets the number of Nickels in the cash register
        /// </summary>
        public int Nickels
        {
            get => drawer.Nickels;

            set
            {
                if (drawer.Nickels == value || value < 0) return;
                int quantity = value - drawer.Nickels;
                if (quantity > 0) drawer.AddCoin(Coins.Nickel, quantity);
                else drawer.RemoveCoin(Coins.Nickel, -quantity);

                InvokePropertyChanged("Nickels");
            }
        }
        
        /// <summary>
        /// Gets or sets the number of Dimes in the cash register
        /// </summary>
        public int Dimes
        {
            get => drawer.Dimes;

            set
            {
                if (drawer.Dimes == value || value < 0) return;
                int quantity = value - drawer.Dimes;
                if (quantity > 0) drawer.AddCoin(Coins.Dime, quantity);
                else drawer.RemoveCoin(Coins.Dime, -quantity);

                InvokePropertyChanged("Dimes");
            }
        }
        
        /// <summary>
        /// Gets or sets the number of Quarters in the cash register
        /// </summary>
        public int Quarters
        {
            get => drawer.Quarters;

            set
            {
                if (drawer.Quarters == value || value < 0) return;
                int quantity = value - drawer.Quarters;
                if (quantity > 0) drawer.AddCoin(Coins.Quarter, quantity);
                else drawer.RemoveCoin(Coins.Quarter, -quantity);

                InvokePropertyChanged("Quarters");
            }
        }
        
        /// <summary>
        /// Gets or sets the number of HalfDollars in the cash register
        /// </summary>
        public int HalfDollars
        {
            get => drawer.HalfDollars;

            set
            {
                if (drawer.HalfDollars == value || value < 0) return;
                int quantity = value - drawer.HalfDollars;
                if (quantity > 0) drawer.AddCoin(Coins.HalfDollar, quantity);
                else drawer.RemoveCoin(Coins.HalfDollar, -quantity);

                InvokePropertyChanged("HalfDollars");
            }
        } 
        
        /// <summary>
        /// Gets or sets the number of Dollars in the cash register
        /// </summary>
        public int Dollars
        {
            get => drawer.Dollars;

            set
            {
                if (drawer.Dollars == value || value < 0) return;
                int quantity = value - drawer.Dollars;
                if (quantity > 0) drawer.AddCoin(Coins.Dollar, quantity);
                else drawer.RemoveCoin(Coins.Dollar, -quantity);

                InvokePropertyChanged("Dollars");
            }
        }

        /// <summary>
        /// Gets or sets the number of Ones in the cash register
        /// </summary>
        public int Ones
        {
            get => drawer.Ones;

            set
            {
                if (drawer.Ones == value || value < 0) return;
                int quantity = value - drawer.Ones;
                if (quantity > 0) drawer.AddBill(Bills.One, quantity);
                else drawer.RemoveBill(Bills.One, -quantity);

                InvokePropertyChanged("Ones");
            }
        }
        
        /// <summary>
        /// Gets or sets the number of Twos in the cash register
        /// </summary>
        public int Twos
        {
            get => drawer.Twos;

            set
            {
                if (drawer.Twos == value || value < 0) return;
                int quantity = value - drawer.Twos;
                if (quantity > 0) drawer.AddBill(Bills.Two, quantity);
                else drawer.RemoveBill(Bills.Two, -quantity);

                InvokePropertyChanged("Twos");
            }
        } 
        
        /// <summary>
        /// Gets or sets the number of Fives in the cash register
        /// </summary>
        public int Fives
        {
            get => drawer.Fives;

            set
            {
                if (drawer.Fives == value || value < 0) return;
                int quantity = value - drawer.Fives;
                if (quantity > 0) drawer.AddBill(Bills.Five, quantity);
                else drawer.RemoveBill(Bills.Five, -quantity);

                InvokePropertyChanged("Fives");
            }
        } 
        
        /// <summary>
        /// Gets or sets the number of Tens in the cash register
        /// </summary>
        public int Tens
        {
            get => drawer.Tens;

            set
            {
                if (drawer.Tens == value || value < 0) return;
                int quantity = value - drawer.Tens;
                if (quantity > 0) drawer.AddBill(Bills.Ten, quantity);
                else drawer.RemoveBill(Bills.Ten, -quantity);

                InvokePropertyChanged("Tens");
            }
        } 
        
        /// <summary>
        /// Gets or sets the number of Twenties in the cash register
        /// </summary>
        public int Twenties
        {
            get => drawer.Twenties;

            set
            {
                if (drawer.Twenties == value || value < 0) return;
                int quantity = value - drawer.Twenties;
                if (quantity > 0) drawer.AddBill(Bills.Twenty, quantity);
                else drawer.RemoveBill(Bills.Twenty, -quantity);

                InvokePropertyChanged("Twenties");
            }
        } 
        
        /// <summary>
        /// Gets or sets the number of Fifties in the cash register
        /// </summary>
        public int Fifties
        {
            get => drawer.Fifties;

            set
            {
                if (drawer.Fifties == value || value < 0) return;
                int quantity = value - drawer.Fifties;
                if (quantity > 0) drawer.AddBill(Bills.Fifty, quantity);
                else drawer.RemoveBill(Bills.Fifty, -quantity);

                InvokePropertyChanged("Fifties");
            }
        } 
        
        /// <summary>
        /// Gets or sets the number of Hundreds in the cash register
        /// </summary>
        public int Hundreds
        {
            get => drawer.Hundreds;

            set
            {
                if (drawer.Hundreds == value || value < 0) return;
                int quantity = value - drawer.Hundreds;
                if (quantity > 0) drawer.AddBill(Bills.Hundred, quantity);
                else drawer.RemoveBill(Bills.Hundred, -quantity);

                InvokePropertyChanged("Hundreds");
            }
        }
    }
}
