using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WebStore.Logger
{
    public static class Log4NetExtensions
    {
        public static Microsoft.Extensions.Logging.ILoggerFactory AddLog4Net(this Microsoft.Extensions.Logging.ILoggerFactory Factory, string Config = "log4net.config")
        {
            if (!Path.IsPathRooted(Config))
            {
                var assembly = Assembly.GetEntryAssembly();
                var dir = Path.GetDirectoryName(assembly.Location);
                Config = Path.Combine(dir, Config);

            }
            Factory.AddProvider(new Log4NetLoggerProvider(Config));

            return Factory;
        }
    }
}
