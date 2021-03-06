﻿/*
* Author: Grant Nichol
* Class: CashInHand.cs
* Purpose: Class detailing the cash that has been given by the customer
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Class representing the money payed by the customer
    /// </summary>
    public class CashInHand : INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event handlers
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The total current value of what was given
        /// </summary>
        public double TotalValue {
            get
            {
                double totalValue = 0;
                totalValue += 100.00 * Hundreds;
                totalValue += 50.00 * Fifties;
                totalValue += 20.00 * Twenties;
                totalValue += 10.00 * Tens;
                totalValue += 5.00 * Fives;
                totalValue += 2.00 * Twos;
                totalValue += 1.00 * Dollars;
                totalValue += 0.50 * HalfDollars;
                totalValue += 0.25 * Quarters;
                totalValue += 0.10 * Dimes;
                totalValue += 0.05 * Nickels;
                totalValue += 0.01 * Pennies;
                return totalValue;
            }
        }


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

        private int pennies = 0;
        /// <summary>
        /// Gets or sets the number of Pennies in the cash register
        /// </summary>
        public int Pennies
        {
            get => pennies;

            set
            {
                if (pennies == value || value < 0) return;
                else pennies = value;

                InvokePropertyChanged("Pennies");
            }
        }

        private int nickels;
        /// <summary>
        /// Gets or sets the number of Nickels in the cash register
        /// </summary>
        public int Nickels
        {
            get => nickels;

            set
            {
                if (nickels == value || value < 0) return;
                else nickels = value;

                InvokePropertyChanged("Nickels");
            }
        }

        private int dimes;
        /// <summary>
        /// Gets or sets the number of Dimes in the cash register
        /// </summary>
        public int Dimes
        {
            get => dimes;

            set
            {
                if (dimes == value || value < 0) return;
                else dimes = value;

                InvokePropertyChanged("Dimes");
            }
        }

        private int quarters;
        /// <summary>
        /// Gets or sets the number of Quarters in the cash register
        /// </summary>
        public int Quarters
        {
            get => quarters;

            set
            {
                if (quarters == value || value < 0) return;
                else quarters = value;

                InvokePropertyChanged("Quarters");
            }
        }

        private int halfDollars;
        /// <summary>
        /// Gets or sets the number of HalfDollars in the cash register
        /// </summary>
        public int HalfDollars
        {
            get => halfDollars;

            set
            {
                if (halfDollars == value || value < 0) return;
                else halfDollars = value;

                InvokePropertyChanged("HalfDollars");
            }
        }

        private int dollars;
        /// <summary>
        /// Gets or sets the number of Dollars in the cash register
        /// </summary>
        public int Dollars
        {
            get => dollars;

            set
            {
                if (dollars == value || value < 0) return;
                else dollars = value;

                InvokePropertyChanged("Dollars");
            }
        }

        private int ones;
        /// <summary>
        /// Gets or sets the number of Ones in the cash register
        /// </summary>
        public int Ones
        {
            get => ones;
            set
            {
                if (ones == value || value < 0) return;
                else ones = value;

                InvokePropertyChanged("Ones");
            }
        }

        private int twos;
        /// <summary>
        /// Gets or sets the number of Twos in the cash register
        /// </summary>
        public int Twos
        {
            get => twos;

            set
            {
                if (twos == value || value < 0) return;
                else twos = value;

                InvokePropertyChanged("Twos");
            }
        }

        private int fives;
        /// <summary>
        /// Gets or sets the number of Fives in the cash register
        /// </summary>
        public int Fives
        {
            get => fives;

            set
            {
                if (fives == value || value < 0) return;
                else fives = value;

                InvokePropertyChanged("Fives");
            }
        }

        private int tens;
        /// <summary>
        /// Gets or sets the number of Tens in the cash register
        /// </summary>
        public int Tens
        {
            get => tens;

            set
            {
                if (tens == value || value < 0) return;
                else tens = value;

                InvokePropertyChanged("Tens");
            }
        }

        private int twenties;
        /// <summary>
        /// Gets or sets the number of Twenties in the cash register
        /// </summary>
        public int Twenties
        {
            get => twenties;

            set
            {
                if (twenties == value || value < 0) return;
                else twenties = value;

                InvokePropertyChanged("Twenties");
            }
        } 
        
        private int fifties;
        /// <summary>
        /// Gets or sets the number of Fifties in the cash register
        /// </summary>
        public int Fifties
        {
            get => fifties;

            set
            {
                if (fifties == value || value < 0) return;
                else fifties = value;

                InvokePropertyChanged("Fifties");
            }
        }

        private int hundreds;
        /// <summary>
        /// Gets or sets the number of Hundreds in the cash register
        /// </summary>
        public int Hundreds
        {
            get => hundreds;

            set
            {
                if (hundreds == value || value < 0) return;
                else hundreds = value;

                InvokePropertyChanged("Hundreds");
            }
        }

        /// <summary>
        /// Get or set all the denomination values in the array
        /// </summary>
        public int[] Values
        {
            get
            {
                int[] array = new int[13];
                array[0] = Hundreds;
                array[1] = Fifties;
                array[2] = Twenties;
                array[3] = Tens;
                array[4] = Fives;
                array[5] = Twos;
                array[6] = Ones;
                array[7] = Dollars;
                array[8] = HalfDollars;
                array[9] = Quarters;
                array[10] = Dimes;
                array[11] = Nickels;
                array[12] = Pennies;
                return array;
            }
            set
            {
                if (value.Length != 13) return;
                Hundreds = value[0];
                Fifties = value[1];
                Twenties = value[2];
                Tens = value[3];
                Fives = value[4];
                Twos = value[5];
                Ones = value[6];
                Dollars = value[7];
                HalfDollars = value[8];
                Quarters = value[9];
                Dimes = value[10];
                Nickels = value[11];
                Pennies = value[12];
            }
        }
    }
}
