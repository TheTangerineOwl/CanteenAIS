using System;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для DateTimeFormField.xaml
    /// </summary>
    public partial class DateTimeFormField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(DateTimeFormField));

        public static readonly DependencyProperty DateTimePickProperty =
            DependencyProperty.Register("DateTimePick", typeof(DateTime), typeof(DateTimeFormField));

        public static readonly DependencyProperty MinimumPropepty =
            DependencyProperty.Register("Minimum", typeof(DateTime), typeof(DateTimeFormField));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(DateTime), typeof(DateTimeFormField));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public DateTime DateTimePick
        {
            get => (DateTime)GetValue(DateTimePickProperty);
            set => SetValue(DateTimePickProperty, value);
        }

        public DateTime Minimum
        {
            get => (DateTime)GetValue(MinimumPropepty);
            set => SetValue(MinimumPropepty, value);
        }

        public DateTime Maximum
        {
            get => (DateTime)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public DateTimeFormField()
        {
            InitializeComponent();
        }
    }
}
