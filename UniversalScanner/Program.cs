using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalScanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddDebug());

            serviceCollection.ConfigureScanners();

            serviceCollection.AddTransient<ScannerWindow>();
            serviceCollection.AddSingleton<IConfig, Config>();
            
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            ScannerWindow viewer = provider.GetService<ScannerWindow>();


            foreach (var engine in provider.GetServices<IScanner>())
            {
                engine.registerViewer(viewer);
            }

            Application.Run(viewer);
        }
    }
}
