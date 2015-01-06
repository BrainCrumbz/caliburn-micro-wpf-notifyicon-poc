using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SysTrayOpenViewModel
{
    class Bootstrapper : AutofacBootstrapper<DummyRootViewModel>
    {
        public Bootstrapper()
        {
            Initialize();  // initialise Caliburn.Micro framework
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            // create a window manager instance to be used by everyone asking for one (including Caliburn.Micro)
            builder.RegisterInstance<IWindowManager>(new WindowManager());
            builder.RegisterType<SystemTrayIconViewModel>();
            builder.RegisterType<SomeViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            // no view/viewmodel to show at startup
            //DisplayRootViewFor<Xxxx>();

            App theApp = sender as App;

            Debug.Assert(theApp != null, "The sender at this point should be the app");

            // create system tray icon (it's a resource declared in a XAML resource dictionary)
            _sysTrayIcon = (TaskbarIcon)theApp.FindResource(_sysTrayResourceName);

            // manually set its view-model 
            _sysTrayIcon.DataContext = Container.Resolve<SystemTrayIconViewModel>();
        }

        protected override void OnExit(object sender, EventArgs evt)
        {
            // properly clean system tray icon
            _sysTrayIcon.Dispose();

            base.OnExit(sender, evt);
        }

        private TaskbarIcon _sysTrayIcon;

        private const string _sysTrayResourceName = "SystemTrayIcon";

    }
}
