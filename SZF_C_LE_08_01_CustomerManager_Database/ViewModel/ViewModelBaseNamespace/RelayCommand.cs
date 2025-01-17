using System;
using System.Windows.Input;


namespace SZF_C_LE_08_01_CustomerManager_Database.ViewModel.ViewModelBaseNamespace
{
    public class RelayCommand : ICommand
    {
        /// Action by execution
        private readonly Action<object?> _execute;

        /// Condition for execution
        private readonly Predicate<object?>? _canExecute;


        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }


        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => _execute(parameter);
    }

}


