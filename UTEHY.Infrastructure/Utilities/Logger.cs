using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UTEHY.Infrastructure.Utilities
{
    public class Logger
    {
        private readonly ILogger _logger;

        public Logger()
        {
            _logger = new LoggerConfiguration()
                   .WriteTo.File(HttpContext.Current.Server.MapPath("~/logs/log-.txt"),
                                    rollingInterval: RollingInterval.Day,
                                    rollOnFileSizeLimit: true)
                   .CreateLogger();
        }
        public void LogError(string error)
        {
            _logger.Error(error);
        }
    }
}
