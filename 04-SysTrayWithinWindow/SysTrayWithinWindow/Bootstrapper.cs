using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SysTrayWithinWindow
{
    class Bootstrapper : AutofacBootstrapper<SystemTrayViewModel>
    {
        public Bootstrapper()
        {
            Initialize();  // inizializza il framework Caliburn.Micro
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            // create a window manager instance to be used by everyone asking for one (including Caliburn.Micro)
            builder.RegisterInstance<IWindowManager>(new WindowManager());
            builder.RegisterType<SystemTrayViewModel>();
            builder.RegisterType<SomeViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            DisplayRootViewFor<SystemTrayViewModel>();
        }
    }
}
