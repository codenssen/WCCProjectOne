using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;
using System;

namespace WCCProjectOne
{
    public static class Logger
    {
        private static readonly string logDirectory = @"logs\log-.log";
        private static bool isInitialized = false;

        public static void Initialize()
        {
            if (!isInitialized)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(logDirectory, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
                    .WriteTo.Console()
                    .CreateLogger();

                isInitialized = true;
            }
        }      
    }
}
