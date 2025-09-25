using CanteenAIS_DB;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views
{
    public static class ColumnMasker
    {
        public static DataGrid HideInvisible<T>(DataGrid grid, bool attributed = true) where T : class
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            var entityFields = props.Cast<PropertyDescriptor>().ToList();

            ColumnDisplayAttribute attr;

            if (grid.ItemsSource is DataView dataView && dataView.Table != null)
            {
                foreach (DataGridColumn col in grid.Columns)
                {
                    PropertyDescriptor prop = entityFields.Where(item => item.Name == (string)col.Header || item.DisplayName == (string)col.Header).FirstOrDefault();
                    attr = prop?.Attributes.OfType<ColumnDisplayAttribute>().FirstOrDefault();
                    if (attr != null)
                    {
                        col.Visibility = attr.Visible == true ? Visibility.Visible : Visibility.Collapsed;
                        col.Header = attr.DisplayName;
                    }
                    else if (attributed)
                        col.Visibility = Visibility.Collapsed;
                    else
                        col.Visibility = Visibility.Visible;
                }
            }
            return grid;
        }
    }
}
