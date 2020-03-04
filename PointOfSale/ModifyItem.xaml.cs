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
    public partial class ModifyItem : UserControl
    {
        public ModifyItem(IOrderItem item)
        {
            DataContext = item;
            var type = item.GetType();
            InitializeComponent();

            // Check if a property exists, and if so, show it
            if (type.GetProperty("Size") != null) SizePanel.Visibility = Visibility.Visible;
            if (type.GetProperty("Flavor") != null) SodaPanel.Visibility = Visibility.Visible;
            if (type.GetProperty("Ice") != null) IceCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("RoomForCream") != null) RoomForCreamCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Decaf") != null) DecafCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Sweet") != null) SweetCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Lemon") != null) LemonCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Bread") != null) BreadCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Pickle") != null) PickleCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Cheese") != null) CheeseCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("SourCream") != null) SourCreamCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("GreenOnions") != null) GreenOnionsCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("TortillaStrips") != null) TortillaStripsCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Ketchup") != null) KetchupCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Mustard") != null) MustardCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Tomato") != null) TomatoCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Lettuce") != null) LettuceCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Mayo") != null) MayoCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Bun") != null) BunCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Bacon") != null) BaconCheck.Visibility = Visibility.Visible;
            if (type.GetProperty("Egg") != null) EggCheck.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Set the size of the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetSize(object sender, RoutedEventArgs e)
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
        public void SetSoda(object sender, RoutedEventArgs e)
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
