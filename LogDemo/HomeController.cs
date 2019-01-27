using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.StructuredLogging.Json;
using LogLevel = NLog.LogLevel;

namespace LogDemo
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Microsoft.Extensions.Logging.ILogger<HomeController> _msLogger;
        private readonly NLog.Logger _nlogLogger = LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> msLogger)
        {
            _msLogger = msLogger;
        }

        [HttpGet]
        public string Get()
        {
            _msLogger.LogInformation("ILogger information");
            _msLogger.LogInformation("ILogger templated information at {CustomProperty}", DateTime.UtcNow);

            _nlogLogger.Log(LogLevel.Info, "NLog information");
            _nlogLogger.ExtendedInfo("NLog Extended information",
                new { CustomProperty = DateTime.UtcNow });

        return "Logging Demo has written logs";
    }

    }
}
