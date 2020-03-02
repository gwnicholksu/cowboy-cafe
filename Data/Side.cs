using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A base class representing a side
    /// </summary>
    public abstract class Side : IOrderItem, INotifyPropertyChanged
    {
        private Size _size;
        /// <summary>
        /// Gets the size of the entree
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set
            {
                _size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
            }
        }

        /// <summary>
        /// Gets the price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of the entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The SpecialInstructions to include ( there are none )
        /// </summary>
        public List<string> SpecialInstructions {
            get
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Event to be activated whenever certain properties are changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
