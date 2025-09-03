using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для CheckFormField.xaml
    /// </summary>
    public partial class CheckFormField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(CheckFormField));

        public static readonly DependencyProperty IsValueCheckedProperty =
            DependencyProperty.Register("IsValueChecked", typeof(bool), typeof(CheckFormField));

        public static readonly DependencyProperty DefaultProperty =
            DependencyProperty.Register("Default", typeof(bool), typeof(CheckFormField));

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

        public CheckFormField()
        {
            InitializeComponent();
        }
    }
}
