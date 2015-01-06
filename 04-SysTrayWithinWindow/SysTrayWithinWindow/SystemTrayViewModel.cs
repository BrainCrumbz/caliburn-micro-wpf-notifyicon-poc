using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SysTrayWithinWindow
{
    public class SystemTrayViewModel : Screen
    {
        /*
         * NOTE: In this sample the system tray view-model doesn't receive any notification 
         * when the other window gets closed by pressing the top right 'x'.
         * Thus no property notification is invoked, and system tray context-menu appears 
         * out of sync, still allowing 'Hide' and disabling 'Show'.
         * Given the purpose of the sample - integrating Caliburn.Micro with WPF NotifyIcon -
         * sync'ing the two view-models is not of interest here.
         * */

        public SystemTrayViewModel(IWindowManager windowManager, SomeViewModel someViewModel)
        {
            _windowManager = windowManager;
            _someViewModel = someViewModel;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            NotifyOfPropertyChange(() => CanShowWindow);
            NotifyOfPropertyChange(() => CanHideWindow);
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

        private IWindowManager _windowManager;
        private SomeViewModel _someViewModel;
    }
}
