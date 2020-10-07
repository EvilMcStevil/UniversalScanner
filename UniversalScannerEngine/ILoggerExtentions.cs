using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace UniversalScanner
{
public static     class ILoggerExtentions
    {
        public static void WriteData(this ILogger logger, LogLevel dataLevel, byte[] data, int threadId = 0)
        {
            string textFromData;
            bool isBinary;
            string[] lines;
            StringBuilder result;
            Regex binaryCharacters;

            if (!logger.IsEnabled(dataLevel))
            {
                return;
            }

            if (threadId == 0)
            {
                threadId = Thread.CurrentThread.ManagedThreadId;
            }

            textFromData = "";
            try
            {
                textFromData = Encoding.UTF8.GetString(data);
                binaryCharacters = new Regex("[^\x20-\x7E\t\r\n]");
                isBinary = binaryCharacters.IsMatch(textFromData);
            }
            catch
            {
                isBinary = true;
            }

            result = new StringBuilder();
            if (isBinary)
            {

                for (int i = 0; i < data.Length; i++)
                {
                    if (i % 16 == 0 && i > 0)
                    {
                        result.AppendFormat("\n[{0,4}] ", threadId);
                    }
                    result.AppendFormat(" {0:X02}", (byte)data[i]);
                }
            }
            else
            {
                lines = Regex.Split(textFromData, "\r\n|\r|\n");

                foreach (string line in lines)
                {
                    result.AppendFormat("\n[{0,4}] {1}", threadId, line);
                }

            }
            logger.Log(dataLevel, String.Format("[{0,4}] {1}", threadId, result.ToString()));
            //Trace.WriteLineIf(dataLevel <= level, String.Format("[{0,4}] {1}", threadId, result.ToString()));
        }
    }
}
