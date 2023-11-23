﻿using System;
using System.Windows.Input;

namespace WpfApp1.Commands
{
    abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);

    }
}