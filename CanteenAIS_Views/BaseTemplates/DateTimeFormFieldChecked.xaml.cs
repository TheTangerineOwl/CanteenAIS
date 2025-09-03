using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для DateTimeFormFieldChecked.xaml
    /// </summary>
    public partial class DateTimeFormFieldChecked : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(DateTimeFormFieldChecked));

        public static readonly DependencyProperty ValuePickProperty =
            DependencyProperty.Register("ValuePick", typeof(DateTime), typeof(DateTimeFormFieldChecked));

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(DateTimeFormFieldChecked));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public DateTime ValuePick
        {
            get => (DateTime)GetValue(ValuePickProperty);
            set => SetValue(ValuePickProperty, value);
        }

        public DateTimeFormFieldChecked()
        {
            InitializeComponent();
        }
    }
}
