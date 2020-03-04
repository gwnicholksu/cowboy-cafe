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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Initialize the Menu Selection Control
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        #region Entree Handlers

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCowpokeChiliButton_Click(object sender, RoutedEventArgs e)
        {
            var item = new CowpokeChili();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);

        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRustlersRibs_Click(object sender, RoutedEventArgs e)
        {
            var item = new RustlersRibs();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPecosPulledPork_Click(object sender, RoutedEventArgs e)
        {
            var item = new PecosPulledPork();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTrailBurger_Click(object sender, RoutedEventArgs e)
        {
            var item = new TrailBurger();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDakotaDoubleBurger_Click(object sender, RoutedEventArgs e)
        {
            var item = new DakotaDoubleBurger();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTexasTripleBurger_Click(object sender, RoutedEventArgs e)
        {
            var item = new TexasTripleBurger();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAngryChicken_Click(object sender, RoutedEventArgs e)
        {
            var item = new AngryChicken();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }
        #endregion

        #region Side Handlers

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChiliCheeseFries_Click(object sender, RoutedEventArgs e)
        {
            var item = new ChiliCheeseFries();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCornDodgers_Click(object sender, RoutedEventArgs e)
        {
            var item = new CornDodgers();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPanDeCampo_Click(object sender, RoutedEventArgs e)
        {
            var item = new PanDeCampo();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBakedBeans_Click(object sender, RoutedEventArgs e)
        {
            var item = new BakedBeans();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        #endregion

        #region Drink Handlers

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJerkedSoda_Click(object sender, RoutedEventArgs e)
        {
            var item = new JerkedSoda();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTexasTea_Click(object sender, RoutedEventArgs e)
        {
            var item = new TexasTea();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCowboyCoffe_Click(object sender, RoutedEventArgs e)
        {
            var item = new CowboyCoffee();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddWater_Click(object sender, RoutedEventArgs e)
        {
            var item = new Water();
            ((Order)DataContext).Add(item);
            ((Border)Parent).Child = new ModifyItem(item);
        }

        #endregion
    }
}
