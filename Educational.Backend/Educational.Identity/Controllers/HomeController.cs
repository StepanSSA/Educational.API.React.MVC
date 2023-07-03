using Educational.Identity.Data.Entity;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Educational.Identity.Controllers
{

    public class HomeController : Controller
    {

        [HttpGet]
        [Route("[controller]/error")]
        public async Task<IActionResult> Error()
        {
            return View("Error");
        }
    }
}
