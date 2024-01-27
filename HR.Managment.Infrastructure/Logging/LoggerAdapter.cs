using HR.Managment.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _loggerFactory;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory.CreateLogger<T>();
        }

        public async Task LogInformation(string message, params object[] args)
        {
            _loggerFactory.LogInformation(message, args);
        }

        public async Task LogWarning(string message, params object[] args)
        {
            _loggerFactory.LogWarning(message, args);
        }
    }
}
