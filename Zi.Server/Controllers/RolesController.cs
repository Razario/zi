using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zi.Entity;

namespace Zi.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        [HttpGet]
        public IEnumerable<Role> GetActualRoles()
        {
            return new List<Role> {
                new Role{ Id=1, Name="Разработчик"},
                new Role {Id=2, Name="Тестировщик"}
            };
        }
    }
}