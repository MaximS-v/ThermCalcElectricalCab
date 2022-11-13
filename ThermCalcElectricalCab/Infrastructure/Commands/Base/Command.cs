using System;
using System.Windows.Input;

namespace ThermCalcElectricalCab.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value; 
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);

		Action<object>? _executeMethod;
		Func<object, bool>? _canexecuteMethod;

        public Command(Action<object>? executeMethod, Func<object, bool>? canexecuteMethod)
		{
			_executeMethod = executeMethod;
			_canexecuteMethod = canexecuteMethod;
		}
	}
}
