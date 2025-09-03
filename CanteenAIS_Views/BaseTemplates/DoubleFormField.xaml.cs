using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для DoubleFormField.xaml
    /// </summary>
    public partial class DoubleFormField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(DoubleFormField));

        public static readonly DependencyProperty ValuePickProperty =
            DependencyProperty.Register("ValuePick", typeof(decimal), typeof(DoubleFormField));

        public static readonly DependencyProperty MinimumPropepty =
            DependencyProperty.Register("Minimum", typeof(decimal), typeof(DoubleFormField));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(decimal), typeof(DoubleFormField));

        public static readonly DependencyProperty DefaultProperty =
            DependencyProperty.Register("Default", typeof(decimal), typeof(DoubleFormField));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public decimal ValuePick
        {
            get => (decimal)GetValue(ValuePickProperty);
            set => SetValue(ValuePickProperty, value);
        }

        public decimal Minimum
        {
            get => (decimal)GetValue(MinimumPropepty);
            set => SetValue(MinimumPropepty, value);
        }

        public decimal Maximum
        {
            get => (decimal)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public decimal Default
        {
            get => (decimal)GetValue(DefaultProperty);
            set => SetValue(DefaultProperty, value);
        }

        public DoubleFormField()
        {
            InitializeComponent();
        }
    }
}
