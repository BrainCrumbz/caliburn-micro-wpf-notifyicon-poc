using Caliburn.Micro;
using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTrayOpenWindow
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();  // initialise Caliburn.Micro framework
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            // no view/viewmodel to show at startup
            //DisplayRootViewFor<Xxxx>();

            App theApp = sender as App;

            Debug.Assert(theApp != null, "The sender at this point should be the app");

            // create system tray icon (it's a resource declared in a XAML resource dictionary)
            _sysTrayIcon = (TaskbarIcon)theApp.FindResource("MainSystemTrayIcon");
        }

        protected override void OnExit(object sender, EventArgs evt)
        {
            // properly clean system tray icon
            _sysTrayIcon.Dispose();

            base.OnExit(sender, evt);
        }

        private TaskbarIcon _sysTrayIcon;
    }
}
