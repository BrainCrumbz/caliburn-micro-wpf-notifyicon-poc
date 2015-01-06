using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysTrayOpenViewModel
{
    /* Autofac-enabled bootstrapper is a generic and requires the type of root ViewModel to be shown.
     * This application starts with system tray icon only, no visible window, so there's no real root ViewModel to show.
     * Thus we created a dummy ViewModel for the sole purpose of serving that to bootstrapper.
     * */
    public class DummyRootViewModel
    {
    }
}
