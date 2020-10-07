using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalScanner
{
    public class Config : IConfig
    {
        // default values
        public bool enableIPv6 { get; } = false;
        public bool forceLinkLocal { get; } = true;
        public bool enableIPv4 { get; } = true;
        public bool forceZeroConf { get; } = false;
        public bool forceGenericProtocols { get; } = false;
        public bool clearOnRescan { get; } = false;
        public bool showDebugWarning { get; } = true;
        public bool portSharing { get; } = true;
        public bool onvifVerbatim { get; } = false;
        public bool dahuaNetScan { get; } = false;

        private static readonly string path = @"Software\UniversalScanner";

        public Config()
        {
            RegistryKey key;

            key = Registry.CurrentUser.openOrCreate(path);
            if (key != null)
            {
                enableIPv6 = key.readBool(nameof(enableIPv6), enableIPv6);
                key.writeBool(nameof(enableIPv6), enableIPv6);

                forceLinkLocal = key.readBool(nameof(forceLinkLocal), forceLinkLocal);
                key.writeBool(nameof(forceLinkLocal), forceLinkLocal);
                
                enableIPv4 = key.readBool(nameof(enableIPv4), enableIPv4);
                key.writeBool(nameof(enableIPv4), enableIPv4);
                
                forceZeroConf = key.readBool(nameof(forceZeroConf), forceZeroConf);
                key.writeBool(nameof(forceZeroConf), forceZeroConf);
                
                forceGenericProtocols = key.readBool(nameof(forceGenericProtocols), forceGenericProtocols);
                key.writeBool(nameof(forceGenericProtocols), forceGenericProtocols);
                
                clearOnRescan = key.readBool(nameof(clearOnRescan), clearOnRescan);
                key.writeBool(nameof(clearOnRescan), clearOnRescan);
                
                showDebugWarning = key.readBool(nameof(showDebugWarning), showDebugWarning);
                key.writeBool(nameof(showDebugWarning), showDebugWarning);

                portSharing = key.readBool(nameof(portSharing), portSharing);
                key.writeBool(nameof(portSharing), portSharing);

                onvifVerbatim = key.readBool(nameof(onvifVerbatim), onvifVerbatim);
                key.writeBool(nameof(onvifVerbatim), onvifVerbatim);

                dahuaNetScan = key.readBool(nameof(dahuaNetScan), dahuaNetScan);
                key.writeBool(nameof(dahuaNetScan), dahuaNetScan);
            }
        }
    }
}
