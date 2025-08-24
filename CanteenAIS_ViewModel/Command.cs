using System;
using System.Windows.Input;

namespace CanteenAIS_ViewModel
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> action;
        public Command(Action<object> action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => action?.Invoke(parameter);
    }
}
