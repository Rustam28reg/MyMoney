using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_ProjectWork.Services.Classes
{
    internal class GenericButtonCommand<T> : ICommand
    {
        private readonly Action<T> _funcToExecute;
        private readonly Func<T, bool> _funcToCheck = (T) => true;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public GenericButtonCommand(Action<T> funcToExecute)
        {
            _funcToExecute = funcToExecute;
        }

        public GenericButtonCommand(Action<T> funcToExecute, Func<T, bool> funcToCheck)
        {
            _funcToExecute = funcToExecute;
            _funcToCheck = funcToCheck;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is T value)
            {
                return _funcToCheck(value);
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter is T value)
            {
                _funcToExecute(value);
            }
        }
    }
}
