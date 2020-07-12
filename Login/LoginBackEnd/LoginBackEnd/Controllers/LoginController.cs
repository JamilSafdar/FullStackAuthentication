using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginBackEnd.Helpers;
using LoginBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoginBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private ILogInService loginSvc;

        public LoginController(ILogInService loginSvc)
        {
            this.loginSvc = loginSvc;
        }

        [HttpGet("{emailAddress}/{passWord}")]
        public IActionResult Get(string emailAddress, string passWord)
        {
            if (loginSvc.LogIn(emailAddress, passWord))
            {
                return Ok("You have successfully logged in.");
            }
            else
            {
                return BadRequest("You have entered an incorrect username or password.");
            }
        }
    }
}
