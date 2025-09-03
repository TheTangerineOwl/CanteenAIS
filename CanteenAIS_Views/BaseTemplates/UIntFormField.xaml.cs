using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для UIntFormField.xaml
    /// </summary>
    public partial class UIntFormField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(UIntFormField));

        public static readonly DependencyProperty UIntPickProperty =
            DependencyProperty.Register("IntPick", typeof(uint), typeof(UIntFormField));

        public static readonly DependencyProperty MinimumPropepty =
            DependencyProperty.Register("Minimum", typeof(uint), typeof(UIntFormField));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(uint), typeof(UIntFormField));

        public static readonly DependencyProperty DefaultProperty =
            DependencyProperty.Register("Default", typeof(uint), typeof(UIntFormField));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public uint UIntPick
        {
            get => (uint)GetValue(UIntPickProperty);
            set => SetValue(UIntPickProperty, value);
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

        public UIntFormField()
        {
            InitializeComponent();
        }
    }
}
