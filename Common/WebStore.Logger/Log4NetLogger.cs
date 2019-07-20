using log4net;
using log4net.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace WebStore.Logger
{
    public class Log4NetLogger : Microsoft.Extensions.Logging.ILogger
    {
        private readonly ILog _log;
        public Log4NetLogger (string categoryName, XmlElement Config)
        {
            var loggerRep = LoggerManager.CreateRepository(
                Assembly.GetEntryAssembly(),
                 typeof(log4net.Repository.Hierarchy.Hierarchy));
            _log = log4net.LogManager.GetLogger(loggerRep.Name, categoryName);
            log4net.Config.XmlConfigurator.Configure(loggerRep, Config);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case (LogLevel.Critical):
                    return _log.IsFatalEnabled;
                case (LogLevel.Debug):
                    return _log.IsDebugEnabled;
                case (LogLevel.Error):
                    return _log.IsErrorEnabled;
                case (LogLevel.Information):
                    return _log.IsInfoEnabled;
                case (LogLevel.Warning):
                    return _log.IsWarnEnabled;
                case(LogLevel.None):
                    return false;
                case (LogLevel.Trace):
                    return false;
                default: throw new ArgumentOutOfRangeException(nameof(Level), Level.Info, null);
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            if (formatter is null) throw new ArgumentNullException(nameof(formatter));
            var msg = formatter(state, exception);
            if (string.IsNullOrEmpty(msg) && exception is null) return;
            switch (logLevel)
            {
                case (LogLevel.Critical):
                     _log.Fatal(msg ?? exception.ToString());
                    break;
                case (LogLevel.Trace):
                case (LogLevel.Debug):
                    _log.Debug(msg);
                    break;

                case (LogLevel.Error):
                    _log.Error(msg ?? exception.ToString());
                    break;

                case (LogLevel.Information):
                    _log.Info(msg);
                    break;
                case (LogLevel.Warning):
                    _log.Warn(msg);
                    break;
                case (LogLevel.None):
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(Level), Level.Info, null);
            }
        }
    }
}
