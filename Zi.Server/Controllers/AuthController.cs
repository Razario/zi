using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zi.Context;
using System.Net;

namespace Zi.Server.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpGet("{hash}/{login}/{password}")]
        public IActionResult Login(string login, string password, string hash)
        {
            var psw = Verify.Decrypt(password, login);
            if (Verify.Hash(psw + login) != hash)
                return StatusCode((int)HttpStatusCode.BadRequest);
            var guid = Guid.NewGuid().ToString().Replace("-", "");

            return Ok(guid);
        }

        [HttpPost]
        [TokenRequired]
        public bool EndOfWork([FromBody] string token)
        {
            var xx = Request.Headers;
            var xxf = Request.Headers["Token"];
            return false;
        }
    }
}