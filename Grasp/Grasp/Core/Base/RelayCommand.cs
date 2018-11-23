using System;
using System.Windows.Input;

namespace Grasp
{
    /// <summary>
    /// A Command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members
        private Action mAction;
        #endregion

        #region Public Events
        /// <summary>
        /// The event that is fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action) => mAction = action;
        #endregion

        #region Command Methods
        /// <summary>
        /// A RelayCommand will always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Executes the Command's Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => mAction();
        #endregion
    }
}
