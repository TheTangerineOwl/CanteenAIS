using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для IntFormField.xaml
    /// </summary>
    public partial class IntFormField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(IntFormField));

        public static readonly DependencyProperty IntPickProperty =
            DependencyProperty.Register("IntPick", typeof(int), typeof(IntFormField));

        public static readonly DependencyProperty MinimumPropepty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(IntFormField));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(IntFormField));

        public static readonly DependencyProperty DefaultProperty =
            DependencyProperty.Register("Default", typeof(int), typeof(IntFormField));

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

        public IntFormField()
        {
            InitializeComponent();
        }
    }
}
