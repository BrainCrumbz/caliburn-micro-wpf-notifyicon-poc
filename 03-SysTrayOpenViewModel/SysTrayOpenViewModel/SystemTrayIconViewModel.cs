using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SysTrayOpenViewModel
{
    public class SystemTrayIconViewModel : PropertyChangedBase
    {
        public SystemTrayIconViewModel(IWindowManager windowManager, SomeViewModel someViewModel)
        {
            _windowManager = windowManager;
            _someViewModel = someViewModel;
        }

        public void ShowWindow()
        {
            // manually show the next window view-model
            _windowManager.ShowWindow(_someViewModel);

            NotifyOfPropertyChange(() => CanShowWindow);
            NotifyOfPropertyChange(() => CanHideWindow);
        }

        public bool CanShowWindow
        {
            get
            {
                return (!_someViewModel.IsActive);
            }
        }

        public void HideWindow()
        {
            _someViewModel.TryClose();

            NotifyOfPropertyChange(() => CanShowWindow);
            NotifyOfPropertyChange(() => CanHideWindow);
        }

        public bool CanHideWindow
        {
            get
            {
                return (_someViewModel.IsActive);
            }
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Shows a window, if none is already open.
        /// </summary>
        public ICommand ShowWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => CanShowWindow,
                    CommandAction = () => ShowWindow(),
                };
            }
        }

        private IWindowManager _windowManager;
        private SomeViewModel _someViewModel;

        /// <summary>
        /// Simplistic delegate command for the demo.
        /// </summary>
        class DelegateCommand : ICommand
        {
            public System.Action CommandAction { get; set; }
            public Func<bool> CanExecuteFunc { get; set; }

            public void Execute(object parameter)
            {
                CommandAction();
            }

            public bool CanExecute(object parameter)
            {
                return CanExecuteFunc == null || CanExecuteFunc();
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }

    }
}
