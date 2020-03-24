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
using System.Text.RegularExpressions;
using System.Reflection;
using CowboyCafe.ExtensionMethods;


namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Interaction logic for ModifySide.xaml
    /// </summary>
    public partial class ModifyItemControl : UserControl
    {
        OrderControl parent;

        public ModifyItemControl(IOrderItem item)
        {
            DataContext = item;
            item.PropertyChanged += (sender, e) => { itemText.GetBindingExpression(TextBlock.TextProperty).UpdateTarget(); }; // Force the texbox to update
            var type = item.GetType();
            InitializeComponent();

            PropertyInfo[] myPropertyInfo = type.GetProperties();
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                if(myPropertyInfo[i].PropertyType == typeof(bool))
                {
                    Viewbox holdCheck = new Viewbox();
                    CheckBox checkBox = new CheckBox();
                    checkBox.Content = Regex.Replace(myPropertyInfo[i].Name, "([a-z])([A-Z])", "$1 $2");

                    Binding binding = new Binding();
                    binding.Source = DataContext;
                    binding.Path = new PropertyPath(myPropertyInfo[i].Name);
                    binding.Mode = BindingMode.TwoWay;
                    checkBox.SetBinding(CheckBox.IsCheckedProperty, binding);

                    holdCheck.Child = checkBox;

                    OptionPanel.Children.Add(holdCheck);
                }
            }

            if (type.GetProperty("Size") != null) sizePanel.Visibility = Visibility.Visible;
            if (type.GetProperty("Flavor") != null) sodaPanel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Method to run when the control is loaded
        /// </summary>
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            parent = this.FindAncestor<OrderControl>();
        }

        /// <summary>
        /// Set the size of the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSize(object sender, RoutedEventArgs e)
        {
            var sizeProp = DataContext.GetType().GetProperty("Size");
            if (sizeProp == null) return;

            if(sender is Button)
            {
                switch (((Button)sender).Content)
                {
                    case "Small":
                        sizeProp.SetValue(DataContext, CowboyCafe.Data.Size.Small);
                        break;
                    case "Medium":
                        sizeProp.SetValue(DataContext, CowboyCafe.Data.Size.Medium);
                        break;
                    case "Large":
                        sizeProp.SetValue(DataContext, CowboyCafe.Data.Size.Large);
                        break;
                }
            }
        }

        /// <summary>
        /// Set the type of soda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSoda(object sender, RoutedEventArgs e)
        {
            var sodaProp = DataContext.GetType().GetProperty("Flavor");
            if (sodaProp == null) return;

            if(sender is Button)
            {
                switch (((Button)sender).Content)
                {
                    case "Cream Soda":
                        sodaProp.SetValue(DataContext, SodaFlavor.CreamSoda);
                        break;
                    case "Orange Soda":
                        sodaProp.SetValue(DataContext, SodaFlavor.OrangeSoda);
                        break;
                    case "Sarsparilla":
                        sodaProp.SetValue(DataContext, SodaFlavor.Sarsparilla);
                        break;
                    case "Birch Beer":
                        sodaProp.SetValue(DataContext, SodaFlavor.BirchBeer);
                        break;
                    case "Root Beer":
                        sodaProp.SetValue(DataContext, SodaFlavor.RootBeer);
                        break;
                }
            }
        }

        /// <summary>
        /// Handle a button to remove this item from the order
        /// </summary>
        /// <param name="sender">The sending button</param>
        /// <param name="e">Event args</param>
        private void OnRemoveItem(object sender, RoutedEventArgs e)
        {
            parent.RemoveAndStopEditing(DataContext as IOrderItem);
        }
    }
}
