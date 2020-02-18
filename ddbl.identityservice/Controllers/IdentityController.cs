using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddbl.identityservice.IdentityRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ddbl.identityservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;
        private TokenManager _manager;

        public IdentityController(ILogger<IdentityController> logger, IConfiguration config)
        {
            _logger = logger;
            _manager = new TokenManager(config);
        }

        [HttpPost("Authorize")]
        public IActionResult Authorizate(string userName, string password)
        {
            if (IdentityProvider.Authorizate(userName, password))
            {
                return Ok(_manager.GenerateToken(IdentityProvider.GetUser(userName).Id));
            }
            return Unauthorized();
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser(string token)
        {
            if (token == null)
            {
                return Unauthorized();
            }
            var id = _manager.ValidateToken(token);
            var user = IdentityProvider.GetUser(id);
            return Ok(user);
        }
    }
}
