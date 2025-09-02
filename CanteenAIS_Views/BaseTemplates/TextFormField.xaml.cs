using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для TextFormField.xaml
    /// </summary>
    public partial class TextFormField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(TextFormField));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextFormField));

        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(TextFormField),
                new PropertyMetadata(0));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public TextFormField()
        {
            InitializeComponent();
        }
    }
}
