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
    /// Interaction logic for ModifySide.xaml
    /// </summary>
    public partial class ModifyItemControl : UserControl
    {
        public ModifyItemControl(IOrderItem item)
        {
            DataContext = item;
            item.PropertyChanged += (sender, e) => { itemText.GetBindingExpression(TextBlock.TextProperty).UpdateTarget(); }; // Force the texbox to update
            var type = item.GetType();
            InitializeComponent();

            // Check if a property exist and, if so, show it
            if (type.GetProperty("Size") != null) sizePanel.Visibility = Visibility.Visible;
            if (type.GetProperty("Flavor") != null) sodaPanel.Visibility = Visibility.Visible;
            if (type.GetProperty("Ice") != null) iceCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("RoomForCream") != null) roomForCreamCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Decaf") != null) decafCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Sweet") != null) sweetCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Lemon") != null) lemonCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Bread") != null) breadCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Pickle") != null) pickleCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Cheese") != null) cheeseCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("SourCream") != null) sourCreamCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("GreenOnions") != null) greenOnionsCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("TortillaStrips") != null) tortillaStripsCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Ketchup") != null) ketchupCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Mustard") != null) mustardCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Tomato") != null) tomatoCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Lettuce") != null) lettuceCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Mayo") != null) mayoCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Bun") != null) bunCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Bacon") != null) baconCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Egg") != null) eggCheck.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Set the size of the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSize(object sender, RoutedEventArgs e)
        {
            var sizeProp = DataContext.GetType().GetProperty("Size");

            switch (((Button)sender).Tag)
            {
                case "SizeSmall":
                    sizeProp.SetValue(DataContext, CowboyCafe.Data.Size.Small);
                    break;
                case "SizeMedium":
                    sizeProp.SetValue(DataContext, CowboyCafe.Data.Size.Medium);
                    break;
                case "SizeLarge":
                    sizeProp.SetValue(DataContext, CowboyCafe.Data.Size.Large);
                    break;
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

            switch (((Button)sender).Tag)
            {
                case "CreamSoda":
                    sodaProp.SetValue(DataContext, SodaFlavor.CreamSoda);
                    break;
                case "OrangeSoda":
                    sodaProp.SetValue(DataContext, SodaFlavor.OrangeSoda);
                    break;
                case "Sarsparilla":
                    sodaProp.SetValue(DataContext, SodaFlavor.Sarsparilla);
                    break;
                case "BirchBeer":
                    sodaProp.SetValue(DataContext, SodaFlavor.BirchBeer);
                    break;
                case "RootBeer":
                    sodaProp.SetValue(DataContext, SodaFlavor.RootBeer);
                    break;
            }
        }
    }
}
