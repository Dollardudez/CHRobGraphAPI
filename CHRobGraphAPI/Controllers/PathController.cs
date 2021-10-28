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

        public PathController(ILogger<PathController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{countrycode}")]
        public IPath Get(string countrycode)
        {
            return new CountryPath(countrycode);
        }
    }
}
