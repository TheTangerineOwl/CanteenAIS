using System.Collections;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для Subtable.xaml
    /// </summary>
    public partial class Subtable : UserControl
    {
        public Subtable()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(Subtable));

        public ICommand AddCommand
        {
            get => (ICommand)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }

        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(Subtable));

        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(Subtable));

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public static readonly DependencyProperty ExportCommandProperty =
            DependencyProperty.Register("ExportCommand", typeof(ICommand), typeof(Subtable));

        public ICommand ExportCommand
        {
            get => (ICommand)GetValue(ExportCommandProperty);
            set => SetValue(ExportCommandProperty, value);
        }

        public static readonly DependencyProperty CanEditSubtableProperty =
            DependencyProperty.Register("CanEditSubtable", typeof(bool), typeof(Subtable));

        public bool CanEditSubtable
        {
            get => (bool)GetValue(CanEditSubtableProperty);
            set => SetValue(CanEditSubtableProperty, value);
        }

        public static readonly DependencyProperty CanAddSubtableProperty =
            DependencyProperty.Register("CanAddSubtable", typeof(bool), typeof(Subtable));

        public bool CanAddSubtable
        {
            get => (bool)GetValue(CanAddSubtableProperty);
            set => SetValue(CanAddSubtableProperty, value);
        }

        public static readonly DependencyProperty TableProperty =
            DependencyProperty.Register("Table", typeof(IEnumerable), typeof(Subtable));

        public IEnumerable Table
        {
            get => (IEnumerable)GetValue(TableProperty);
            set => SetValue(TableProperty, value);
        }

        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(Subtable));

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Subtable));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public event SelectionChangedEventHandler GridSelectionChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridSelectionChanged?.Invoke(this, e);
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (((DataGrid)sender).ItemsSource is DataView dataView && dataView.Table != null)
            {
                DataTable dataTable = dataView.Table;
                DataColumn dataColumn = dataTable.Columns[e.PropertyName];

                if (dataColumn != null)
                {
                    e.Column.Header = dataColumn.Caption;
                    //if (dataColumn.Caption.Contains("Id") && dataColumn.Caption != "Id")
                    //    e.Column.Visibility = Visibility.Collapsed;
                }
            }
        }

        public virtual void HideInvisible<T>(bool attributed = true) where T : class
        {
            ColumnMasker.HideInvisible<T>(SubGrid, attributed);
        }
    }
}
