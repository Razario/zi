using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zi.Server.Controllers
{
    [Route("api/Registration")]
    public class RegistrationController : Controller
    {
        [HttpGet]
        public bool Registration()
        {

            return false;
        }
    }
}