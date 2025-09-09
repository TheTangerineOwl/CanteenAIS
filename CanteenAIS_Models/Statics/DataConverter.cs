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
        public static DataTable ToDataTable<T>(List<T> list, bool attributed = true) where T : class
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            List<PropertyDescriptor> orderedProps;
            if (attributed)
                orderedProps = props.Cast<PropertyDescriptor>()
                        .Select(prop => new
                        {
                            Property = prop,
                            paramAttribute = prop.Attributes.OfType<ColumnDisplayAttribute>().FirstOrDefault()
                        })
                        //.Where(item => item.paramAttribute?.Visible ?? false)
                        .OrderBy(item => item.paramAttribute?.Order ?? int.MaxValue)
                        .Select(item => item.Property).ToList();
            else
                orderedProps = props.Cast<PropertyDescriptor>().ToList();

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

        public static DataRow ToDataRow<T>(T entity, bool attributed = true) where T : class
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            List<PropertyDescriptor> orderedProps;
            if (attributed)
                orderedProps = props.Cast<PropertyDescriptor>()
                        .Select(prop => new
                        {
                            Property = prop,
                            paramAttribute = prop.Attributes.OfType<ColumnDisplayAttribute>().FirstOrDefault()
                        })
                        .Where(item => item.paramAttribute?.Visible ?? false)
                        .OrderBy(item => item.paramAttribute?.Order ?? int.MaxValue)
                        .Select(item => item.Property).ToList();
            else
                orderedProps = props.Cast<PropertyDescriptor>().ToList();

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
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in orderedProps)
            {
                row[prop.Name] = prop.GetValue(entity) ?? DBNull.Value;
            }
            table.Rows.Add(row);
            return table.Rows[0];
        }

        public static IEnumerable<T> FromDataTable<T>(DataTable table, Func<DataRow, T> converter)
        {
            IEnumerable<T> values = table.Rows.Cast<DataRow>().Select(row => converter(row));
            return values;
        }
    }
}
