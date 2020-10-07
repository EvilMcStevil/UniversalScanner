using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalScanner
{

    public interface IScanner
    {

        void registerViewer(ScannerViewer viewer);
    }


    public interface IConfig
    {

       bool enableIPv6 { get; }
       bool forceLinkLocal { get; }
       bool enableIPv4 { get; }
       bool forceZeroConf { get; }
       bool forceGenericProtocols { get; }
       bool clearOnRescan { get; }
       bool showDebugWarning { get; }
       bool portSharing { get; }
       bool onvifVerbatim { get; }
       bool dahuaNetScan { get; }
    }


}

