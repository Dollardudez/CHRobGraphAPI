using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class PathController : ControllerBase
    {
        private readonly ILogger<PathController> _logger;
        private readonly IPath path;

        public PathController(ILogger<PathController> logger, IPath path)
        {
            _logger = logger;
            this.path = path;
        }

        [HttpGet("{countrycode}")]
        public IActionResult Get(string countrycode)
        {
            path.Destination = countrycode;
            return Ok(path);
        }
    }
}
