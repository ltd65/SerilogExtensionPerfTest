using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace SerilogExtensions
{
    public class LoggerFactory
    {
        private static ILogger loggerInstance;

        /// <summary>
        /// Returns an instance of the logger.
        /// </summary>
        /// <typeparam name="T">The context in which the logger shall be running</typeparam>
        /// <returns>Logging instance</returns>
        public static ILogger Create<T>()
        {
            if (loggerInstance == null)
            {
                loggerInstance = Create();
            }
            return loggerInstance.ForContext<T>();
        }

        /// <summary>
        /// Returns an instance of the logger.
        /// </summary>
        /// <returns>Logging instance</returns>
        public static ILogger Create()
        {
            if (loggerInstance == null)
            {
                try
                {
                    var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

                    loggerInstance = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();
                }
                catch (Exception e)
                {
                    // Cannot initialize logger. As the user will not get any logging we better write the exception
                    // simply to the current folder because otherwise we will have no clue what happened
                    File.WriteAllText("./startup_exception.txt", e.Message + e.StackTrace);
                    throw;
                }
            }
            return loggerInstance;
        }
    }
}
