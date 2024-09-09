using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceSphere.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logge)
        {
            _logger = logge;
        }

        [HttpGet(Name = "GetTest")]
        public IActionResult SayHello()
        {
            return Ok(false);
        }
    }
}