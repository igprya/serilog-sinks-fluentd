﻿using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.Fluentd;

namespace Serilog
{
    public static class LoggerConfigurationFluentdExtensions
    {
        private const string Host = "localhost";
        private const int Port = 24224;

        public static LoggerConfiguration Fluentd(
            this LoggerSinkConfiguration loggerSinkConfiguration,
            FluentdSinkOptions option = null)
        {
            var sink = new FluentdSink(option ?? new FluentdSinkOptions(Host, Port));

            return loggerSinkConfiguration.Sink(sink, LogEventLevel.Information);
        }

        public static LoggerConfiguration Fluentd(
           this LoggerSinkConfiguration loggerSinkConfiguration,
           string host,
           int port,
           LogEventLevel restrictedToMinimumLevel = LogEventLevel.Debug)
        {
            var sink = new FluentdSink(new FluentdSinkOptions(host, port));

            return loggerSinkConfiguration.Sink(sink, restrictedToMinimumLevel);
        }
    }
}
