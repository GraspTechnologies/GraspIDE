using System.Windows;
using System.Windows.Controls;

namespace Grasp
{
    /// <summary>
    /// A StyleSelector that handles the MenuItem style, according to whether it contains children or not
    /// </summary>
    public class DropdownMenuItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            return item is MenuItem mItem
                // Check if MenuItem has children
                ? mItem.Items.Count > 0
                    // Style for MenuItem with children
                    ? App.Current.Resources["MenuItemWithChildren"] as Style
                    // Style for MenuItem without children
                    : App.Current.Resources["MenuItemWithoutChildren"] as Style
                : base.SelectStyle(item, container);
        }
    }
}
