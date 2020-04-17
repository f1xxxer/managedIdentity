using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ManagedIdentity.Configuration;
using ManagedIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ManagedIdentity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;
        private readonly RemoteConfig _remoteConfig;
        private readonly ApiConnectionSettings _apiConnectionSettings;

        public ConfigurationController(ILogger<ConfigurationController> logger, IOptions<RemoteConfig> remoteConfig, IOptions<ApiConnectionSettings> apiConnection)
        {
            _logger = logger;
            _remoteConfig = remoteConfig.Value;
            _apiConnectionSettings = apiConnection.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonSerializer.Serialize(new { _remoteConfig, _apiConnectionSettings }));
        }
    }
}
