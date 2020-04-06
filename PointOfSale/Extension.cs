using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace CowboyCafe.Extension
{
    /// <summary>
    /// Hold Extension Methods that we wish to add
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Find the first ancestor in the Visual Tree that has the specified type,
        /// or null if no ancestor is found
        /// </summary>
        /// <typeparam name="T">The type to search for</typeparam>
        /// <param name="obj"></param>
        /// <returns>The first ancestor of type T, or null</returns>
        public static T FindAncestor<T>(this DependencyObject obj) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(obj);

            if (parent is null) return null;

            if (parent is T) return parent as T;

            return FindAncestor<T>(parent);
        }
    }

    /// <summary>
    /// Extend the Button control to include OrderItem type
    /// </summary>
    public class ItemButton : Button
    {
        /// <summary>
        /// The OrderItemProperty definition
        /// </summary>
        public static readonly DependencyProperty OrderItemProperty =
            DependencyProperty.Register("OrderItem", typeof(Type), typeof(ItemButton), new PropertyMetadata(null));

        /// <summary>
        /// Base getter and setter for OrderItem
        /// </summary>
        public Type OrderItem
        {
            get { return (Type)GetValue(OrderItemProperty); }
            set { SetValue(OrderItemProperty, value); }
        }
    }
}
