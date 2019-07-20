using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WebStore.Logger
{
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        private readonly string _Config;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _Logger = new ConcurrentDictionary<string, Log4NetLogger>();



        public Log4NetLoggerProvider(string Config)
        {
            _Config = Config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _Logger.GetOrAdd(categoryName, category =>
            {
                var xml = new XmlDocument();
                var file_name = _Config;
                xml.Load(file_name);
                return new Log4NetLogger(category, xml["log4net"]);
            });
        }

        public void Dispose()
        {
            _Logger.Clear();
        }
    }
}
