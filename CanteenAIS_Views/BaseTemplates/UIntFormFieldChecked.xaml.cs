using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для IntFormFieldChecked.xaml
    /// </summary>
    public partial class IntFormFieldChecked : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(IntFormFieldChecked));

        public static readonly DependencyProperty IntPickProperty =
            DependencyProperty.Register("IntPick", typeof(int), typeof(IntFormFieldChecked));

        public static readonly DependencyProperty MinimumPropepty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(IntFormFieldChecked));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(IntFormFieldChecked));

        public static readonly DependencyProperty DefaultProperty =
            DependencyProperty.Register("Default", typeof(int), typeof(IntFormFieldChecked));

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(IntFormFieldChecked));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public int IntPick
        {
            get => (int)GetValue(IntPickProperty);
            set => SetValue(IntPickProperty, value);
        }

        public int Minimum
        {
            get => (int)GetValue(MinimumPropepty);
            set => SetValue(MinimumPropepty, value);
        }

        public int Maximum
        {
            get => (int)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public int Default
        {
            get => (int)GetValue(DefaultProperty);
            set => SetValue(DefaultProperty, value);
        }

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public IntFormFieldChecked()
        {
            InitializeComponent();
        }
    }
}
