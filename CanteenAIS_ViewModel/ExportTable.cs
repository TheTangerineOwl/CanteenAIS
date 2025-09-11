using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace CanteenAIS_ViewModel
{
    public enum ExportFormat { CSV = 0, Word, Excel }

    public static class ExportTable
    {
        public static readonly Dictionary<string, ExportFormat> StrFormats = new Dictionary<string, ExportFormat>
            {
                { "CSV", ExportFormat.CSV },
                { "Word", ExportFormat.Word },
                { "Excel", ExportFormat.Excel }
            };

        public static ExportFormat StringToFormat(string value)
        {
            if (StrFormats.TryGetValue(value, out ExportFormat format))
                return format;
            else
                return ExportFormat.CSV;
        }

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

        public static void ExportWord(DataTable table, string filepath)
        {
            Word.Application wordApp = null;
            Word.Document wordDoc = null;

            try
            {
                // Создаем приложение Word
                wordApp = new Word.Application();
                wordApp.Visible = false;

                // Создаем новый документ
                wordDoc = wordApp.Documents.Add();

                // Добавляем заголовок
                Word.Paragraph title = wordDoc.Content.Paragraphs.Add();
                title.Range.Text = $"Экспорт данных - {DateTime.Now:dd.MM.yyyy HH:mm}";
                title.Range.Font.Bold = 1;
                title.Range.Font.Size = 14;
                title.Format.SpaceAfter = 12;
                title.Range.InsertParagraphAfter();

                // Создаем таблицу в Word
                Word.Table wordTable = wordDoc.Tables.Add(
                    wordDoc.Range(wordDoc.Content.End - 1, wordDoc.Content.End - 1),
                    table.Rows.Count + 1,  // +1 для заголовков
                    table.Columns.Count,
                    Missing.Value, Missing.Value);

                wordTable.Borders.Enable = 1;

                // Заполняем заголовки столбцов
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    wordTable.Cell(1, i + 1).Range.Text = table.Columns[i].ColumnName;
                    wordTable.Cell(1, i + 1).Range.Font.Bold = 1;
                }

                // Заполняем данные
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        wordTable.Cell(row + 2, col + 1).Range.Text =
                            table.Rows[row][col]?.ToString() ?? string.Empty;
                    }
                }

                // Сохраняем документ
                wordDoc.SaveAs2(filepath);
            }
            finally
            {
                // Закрываем документ и приложение
                if (wordDoc != null)
                {
                    wordDoc.Close();
                    Marshal.ReleaseComObject(wordDoc);
                }

                if (wordApp != null)
                {
                    wordApp.Quit();
                    Marshal.ReleaseComObject(wordApp);
                }
            }
        }

        public static void ExportExcel(DataTable table, string filepath)
        {
            if (table == null || table.Rows.Count == 0)
                throw new ArgumentException("DataTable не может быть null или пустым");

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Создаем приложение Excel
                excelApp = new Excel.Application();
                excelApp.Visible = false;

                // Создаем новую книгу
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                // Заполняем заголовки столбцов
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = table.Columns[i].ColumnName;
                    ((Excel.Range)worksheet.Cells[1, i + 1]).Font.Bold = true;
                }

                // Заполняем данные
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1] = table.Rows[row][col]?.ToString();
                    }
                }

                // Автоподбор ширины столбцов
                worksheet.Columns.AutoFit();

                // Сохраняем файл
                workbook.SaveAs(filepath);
            }
            finally
            {
                // Освобождаем COM объекты
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close();
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }

                // Очищаем память
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
