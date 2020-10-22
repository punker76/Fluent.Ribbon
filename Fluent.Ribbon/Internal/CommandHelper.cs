﻿namespace Fluent.Internal
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Helper class for <see cref="ICommand"/>
    /// </summary>
    public static class CommandHelper
    {
        /// <summary>
        /// Checks if <paramref name="command"/> can be executed.
        /// This method is <c>null</c> safe.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed, otherwise <c>false</c>.</returns>
        public static bool CanExecute(ICommand command, object commandParameter, IInputElement commandTarget)
        {
            if (command is null)
            {
                return false;
            }

            if (command is RoutedCommand routedCommand)
            {
                return routedCommand.CanExecute(commandParameter, commandTarget);
            }

            return command.CanExecute(commandParameter);
        }

        /// <summary>
        /// Executes <paramref name="command"/>.
        /// This method is <c>null</c> safe.
        /// </summary>
        public static void Execute(ICommand command, object commandParameter, IInputElement commandTarget)
        {
            if (command is null)
            {
                return;
            }

            if (command is RoutedCommand routedCommand)
            {
                if (routedCommand.CanExecute(commandParameter, commandTarget))
                {
                    routedCommand.Execute(commandParameter, commandTarget);
                }
            }
            else if (command.CanExecute(commandParameter))
            {
                command.Execute(commandParameter);
            }
        }
    }
}