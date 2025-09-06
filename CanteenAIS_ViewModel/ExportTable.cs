using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_ViewModel
{
    public static class ExportTable
    {
        private static string EscapedCsvValue(string value)
        {
            if (value.Contains('\"') || value.Contains(',') || value.Contains(' '))
            {
                value = string.Concat("\"", value.Replace("\"", "\"\""), "\"");
            }
            return value;
        }

        public static void ExportCsv(DataTable table, string filepath)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = table.Columns.Cast<DataColumn>()
                                                           .Select(item => EscapedCsvValue(item.Caption.ToString()));

            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in table.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Cast<object>()
                                                          .Select(item => EscapedCsvValue(item.ToString()));
                sb.AppendLine(string.Join(",", fields));
            }

            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.Write(sb.ToString());
            }
        }
    }
}
