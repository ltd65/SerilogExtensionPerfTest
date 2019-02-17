using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Serilog;

namespace SerilogExtensions
{
    public static class SerilogExtensions
    {
        /// <summary>
        /// Logging extensions that adds the FilePath, MemberName and LineNumber to the logging context.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="file">File (will be automatically filled by .NET)</param>
        /// <param name="memberName">Member name (will be automatically filled by .NET)</param>
        /// <param name="lineNumber">Line number (will be automatically filled by .NET)</param>
        /// <returns>The logger instance</returns>
        public static ILogger Here(this ILogger logger, [CallerFilePath] string file = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
            return logger.ForContext("CallerFilePath", file)
                .ForContext("CallerMemberName", memberName)
                .ForContext("CallerLineNumber", lineNumber);
        }
    }
}
