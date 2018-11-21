using System.Windows;
using System.Windows.Controls;

namespace Grasp
{
    public class ItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is MenuItem mItem)
            {
                return mItem.Items.Count > 0
                    ? App.Current.Resources["MenuItemWithChildren"] as Style
                    : App.Current.Resources["MenuItemWithoutChildren"] as Style;
            }

            return base.SelectStyle(item, container);
        }
    }
}
