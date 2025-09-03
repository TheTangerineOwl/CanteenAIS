using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для CheckFormFieldChecked.xaml
    /// </summary>
    public partial class CheckFormFieldChecked : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(CheckFormField));

        public static readonly DependencyProperty IsValueCheckedProperty =
            DependencyProperty.Register("IsValueChecked", typeof(bool), typeof(CheckFormField));

        public static readonly DependencyProperty DefaultProperty =
            DependencyProperty.Register("Default", typeof(bool), typeof(CheckFormField));

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(UIntFormFieldChecked));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public bool IsValueChecked
        {
            get => (bool)GetValue(IsValueCheckedProperty);
            set => SetValue(IsValueCheckedProperty, value);
        }

        public bool Default
        {
            get => (bool)GetValue(DefaultProperty);
            set => SetValue(DefaultProperty, value);
        }

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public CheckFormFieldChecked()
        {
            InitializeComponent();
        }
    }
}
