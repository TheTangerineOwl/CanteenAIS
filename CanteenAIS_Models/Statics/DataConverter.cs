using CanteenAIS_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace CanteenAIS_Models.Statics
{
    public static class DataTableConverter
    {
        public static DataTable ToDataTable<T>(List<T> list) where T : class
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            var orderedProps = props.Cast<PropertyDescriptor>()
                        .Select(prop => new
                        {
                            Property = prop,
                            paramAttribute = prop.Attributes.OfType<ColumnDisplayAttribute>().FirstOrDefault()
                        })
                        .Where(item => item.paramAttribute?.Visible ?? false)
                        .OrderBy(item => item.paramAttribute?.Order ?? int.MaxValue)
                        .Select(item => item.Property).ToList();

            foreach (PropertyDescriptor prop in orderedProps)
            {
                DataColumn column = new DataColumn
                {
                    ColumnName = prop.Name,
                    DataType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType,
                    Caption = prop.DisplayName ?? prop.Name
                };
                table.Columns.Add(column);
            }
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in orderedProps)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
