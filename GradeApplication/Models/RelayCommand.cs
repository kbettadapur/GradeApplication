﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GradeApplication
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> action;

        public RelayCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
        public void Execute(object parameter, object sender)
        {
            action(sender);
        }
    }
}
