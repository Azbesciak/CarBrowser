using System;
using System.Windows.Input;

namespace WPFUI.Models
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void UpdateCanExecuteState()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged;
    }
}
