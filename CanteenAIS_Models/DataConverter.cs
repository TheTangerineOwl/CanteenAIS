using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace CanteenAIS_Models
{
    public static class DataTableConverter
    {
        public static DataTable ToDataTable<T>(List<T> list) where T : class
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in props)
            {
                //if (prop.DisplayName != null)
                //if (prop.DisplayName != "-")
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    //table.Columns.Add(prop.DisplayName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in props) 
                {
                    //if (prop.DisplayName != "-")
                    //if (prop.DisplayName != null)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        //row[prop.DisplayName] = prop.GetValue(item) ?? DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
