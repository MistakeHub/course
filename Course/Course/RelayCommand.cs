using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Course
{
     public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // определяет, может ли команда выполняться
        public bool CanExecute(object parameter)
            => canExecute == null || canExecute(parameter);


        // собственно выполняет логику команды
        public void Execute(object parameter) => execute(parameter);

    } // class RelayCommand
}
