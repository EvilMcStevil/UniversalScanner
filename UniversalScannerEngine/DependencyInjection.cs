using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalScanner
{
   public static class DependencyInjection
    {
        public static IServiceCollection ConfigureScanners(this IServiceCollection factory)
        {

            factory.AddSingleton<mDNS>();



                factory.AddSingleton<IScanner,UPnP>();
                factory.AddSingleton<IScanner,Wsdiscovery>();
                factory.AddSingleton<IScanner,Dahua1>();
                factory.AddSingleton<IScanner,Dahua2>();
                factory.AddSingleton<IScanner,Hikvision>();
                factory.AddSingleton<IScanner,Axis>();
                factory.AddSingleton<IScanner,Bosch>();
                factory.AddSingleton<IScanner,GoogleCast>();
                factory.AddSingleton<IScanner,Hanwha>();
                factory.AddSingleton<IScanner,Vivotek>();
                factory.AddSingleton<IScanner,Sony>();
                factory.AddSingleton<IScanner,Ubiquiti>();
                factory.AddSingleton<IScanner,_360Vision>();
                factory.AddSingleton<IScanner,NiceVision>();
                factory.AddSingleton<IScanner,Panasonic>();
                factory.AddSingleton<IScanner,Arecont>();
            factory.AddSingleton<IScanner,GigEVision>();



            return factory;
        }
    }
}
