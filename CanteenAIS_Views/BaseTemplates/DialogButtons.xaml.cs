using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CanteenAIS_Views.BaseTemplates
{
    /// <summary>
    /// Логика взаимодействия для DialogButtons.xaml
    /// </summary>
    public partial class DialogButtons : UserControl
    {
        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register("ButtonContent", typeof(string), typeof(DialogButtons));

        public static readonly DependencyProperty ApplyCommandProperty =
            DependencyProperty.Register("ApplyCommand", typeof(ICommand), typeof(DialogButtons));

        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(DialogButtons));

        public string ButtonContent
        {
            get => (string)GetValue(ButtonContentProperty);
            set => SetValue(ButtonContentProperty, value);
        }

        public ICommand ApplyCommand
        {
            get => (ICommand)GetValue(ApplyCommandProperty);
            set => SetValue(ApplyCommandProperty, value);
        }

        public ICommand CancelCommand
        {
            get => (ICommand)GetValue(CancelCommandProperty);
            set => SetValue(CancelCommandProperty, value);
        }

        public DialogButtons()
        {
            InitializeComponent();
        }
    }
}
