using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для UIntFormFieldChecked.xaml
    /// </summary>
    public partial class UIntFormFieldChecked : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(UIntFormFieldChecked));

        public static readonly DependencyProperty ValuePickProperty =
            DependencyProperty.Register("ValuePick", typeof(uint), typeof(UIntFormFieldChecked));

        public static readonly DependencyProperty MinimumPropepty =
            DependencyProperty.Register("Minimum", typeof(uint), typeof(UIntFormFieldChecked));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(uint), typeof(UIntFormFieldChecked));

        public static readonly DependencyProperty DefaultProperty =
            DependencyProperty.Register("Default", typeof(uint), typeof(UIntFormFieldChecked));

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(UIntFormFieldChecked));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public uint ValuePick
        {
            get => (uint)GetValue(ValuePickProperty);
            set => SetValue(ValuePickProperty, value);
        }

        public uint Minimum
        {
            get => (uint)GetValue(MinimumPropepty);
            set => SetValue(MinimumPropepty, value);
        }

        public uint Maximum
        {
            get => (uint)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public uint Default
        {
            get => (uint)GetValue(DefaultProperty);
            set => SetValue(DefaultProperty, value);
        }

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public UIntFormFieldChecked()
        {
            InitializeComponent();
        }
    }
}
