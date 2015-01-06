using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysTrayOpenViewModel
{
    /* Il bootstrapper integrato con Autofac è un generic e richiede il tipo del view-model radice da mostrare.
     * La app parte con la sola icona del system tray, quindi non c'è un view-model radice, quindi è stato creato
     * un view-model dummy al solo scopo di passarlo al bootstrap.
     * */
    public class DummyRootViewModel
    {
    }
}
