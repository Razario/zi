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
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpGet("{hash}/{login}/{password}")]
        public IActionResult Login(string login, string password, string hash)
        {
            var psw = Verify.Decrypt(password, login);
            if (Verify.Hash(psw + login) != hash)
                return StatusCode((int)HttpStatusCode.BadRequest);
            //провека логина и пароля

            var guid = Guid.NewGuid().ToString().Replace("-", "");
            HttpContext.Session.SetString(guid, login);
            
            return Ok(guid);
        }

        [HttpPost]
        [TokenRequired]
        public bool EndOfWork()
        {
            try
            {
                HttpContext.Session.Remove(Token);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}