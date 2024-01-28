using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task_19
{
    internal class RelayComman : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func <object,bool > canExecute;

        
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayComman(Action <object >Execute,Func<object ,bool>CanExecute=null) 
        {
            execute = Execute ?? throw new ArgumentException (nameof (Execute));
            canExecute = CanExecute;
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke (parameter) ?? true;
        
        public void Execute(object parameter) => execute(parameter);
       
    }
}
