using System;
using Serilog;
using Serilog.Events;
using ServiceStack.Logging;

namespace ServiceStack.Extras.Serilog
{
    public class SerilogLogger : ILog
    {
        private readonly ILogger _log;

        public SerilogLogger(ILogger log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));
            _log = log;
        }

        public void Debug(object message) => _log.Debug(string.Empty, message);
        public void Debug(object message, Exception exception) => _log.Debug(exception, string.Empty, message);
        public void DebugFormat(string format, params object[] args) => _log.Debug(format, args);
        public void Error(object message) => _log.Error(string.Empty, message);
        public void Error(object message, Exception exception) => _log.Error(exception, string.Empty, message);
        public void ErrorFormat(string format, params object[] args) => _log.Error(format, args);
        public void Fatal(object message) => _log.Fatal(string.Empty, message);
        public void Fatal(object message, Exception exception) => _log.Fatal(exception, string.Empty, message);
        public void FatalFormat(string format, params object[] args) => _log.Fatal(format, args);
        public void Info(object message) => _log.Information(string.Empty, message);
        public void Info(object message, Exception exception) => _log.Information(exception, string.Empty, message);
        public void InfoFormat(string format, params object[] args) => _log.Information(format, args);
        public void Warn(object message) => _log.Warning(string.Empty, message);
        public void Warn(object message, Exception exception) => _log.Warning(exception, string.Empty, message);
        public void WarnFormat(string format, params object[] args) => _log.Warning(format, args);
        public bool IsDebugEnabled => _log.IsEnabled(LogEventLevel.Debug);
    }
}
