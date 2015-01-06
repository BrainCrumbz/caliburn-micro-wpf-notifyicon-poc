using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SysTrayOpenWindow
{
    public class MainSystemTrayIconViewModel : PropertyChangedBase
    {
        public void ShowWindow()
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();

            NotifyOfPropertyChange(() => CanShowWindow);
            NotifyOfPropertyChange(() => CanHideWindow);
        }

        public bool CanShowWindow
        {
            get 
            {
                return (Application.Current.MainWindow == null);
            }
        }

        public void HideWindow()
        {
            Application.Current.MainWindow.Close();

            NotifyOfPropertyChange(() => CanShowWindow);
            NotifyOfPropertyChange(() => CanHideWindow);
        }

        public bool CanHideWindow
        {
            get
            {
                return (Application.Current.MainWindow != null);
            }
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
