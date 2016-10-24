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

        public void Debug(object message)
        {
            if (IsDebugEnabled) _log.Debug(message.ToString());
        }

        public void Debug(object message, Exception exception)
        {
            if (IsDebugEnabled) _log.Debug(exception, message.ToString());
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (IsDebugEnabled) _log.Debug(format, args);
        }

        public void Error(object message)
        {
            if (IsErrorEnabled) _log.Error(message.ToString());
        }

        public void Error(object message, Exception exception)
        {
            if (IsErrorEnabled) _log.Error(exception, message.ToString());
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (IsErrorEnabled) _log.Error(format, args);
        }

        public void Fatal(object message)
        {
            if (IsFatalEnabled) _log.Fatal(message.ToString());
        }

        public void Fatal(object message, Exception exception)
        {
            if (IsFatalEnabled) _log.Fatal(exception, message.ToString());
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (IsFatalEnabled) _log.Fatal(format, args);
        }

        public void Info(object message)
        {
            if (IsInfoEnabled) _log.Information(message.ToString());
        }

        public void Info(object message, Exception exception)
        {
            if (IsInfoEnabled) _log.Information(exception, message.ToString());
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (IsInfoEnabled) _log.Information(format, args);
        }

        public void Warn(object message)
        {
            if (IsWarnEnabled) _log.Warning(message.ToString());
        }

        public void Warn(object message, Exception exception)
        {
            if (IsWarnEnabled) _log.Warning(exception, message.ToString());
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (IsWarnEnabled) _log.Warning(format, args);
        }

        public bool IsDebugEnabled => _log.IsEnabled(LogEventLevel.Debug);

        public bool IsInfoEnabled => _log.IsEnabled(LogEventLevel.Information);

        public bool IsWarnEnabled => _log.IsEnabled(LogEventLevel.Warning);

        public bool IsErrorEnabled => _log.IsEnabled(LogEventLevel.Error);

        public bool IsFatalEnabled => _log.IsEnabled(LogEventLevel.Fatal);
    }
}
