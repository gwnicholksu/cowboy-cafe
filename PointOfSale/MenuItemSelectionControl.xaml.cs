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
            ((Order)DataContext).Add(new CowpokeChili());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRustlersRibs_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new RustlersRibs());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPecosPulledPork_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new PecosPulledPork());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTrailBurger_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new TrailBurger());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDakotaDoubleBurger_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new DakotaDoubleBurger());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTexasTripleBurger_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new TexasTripleBurger() { Pickle = false, Cheese = false });
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAngryChicken_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new AngryChicken() { Pickle = false });
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
            ((Order)DataContext).Add(new ChiliCheeseFries());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCornDodgers_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new CornDodgers());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPanDeCampo_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new PanDeCampo());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBakedBeans_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new BakedBeans());
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
            ((Order)DataContext).Add(new JerkedSoda());
        }


        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTexasTea_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new TexasTea());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCowboyCoffe_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new CowboyCoffee());
        }

        /// <summary>
        /// Event Handler for a Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddWater_Click(object sender, RoutedEventArgs e)
        {
            ((Order)DataContext).Add(new Water());
        }

        #endregion
    }
}
