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
    public class CreateAccountController : Controller
    {
        private IValidation validation;
        private ICreateAccountService accountService;

        public CreateAccountController(IValidation validation, ICreateAccountService accountService)
        {
            this.validation = validation;
            this.accountService = accountService;
        }

        [HttpGet("{fullName}/{emailAddress}/{passWord}")]
        public IActionResult Get(string fullName, string emailAddress, string passWord)
        {
            if (validation.DoesAccountExist(emailAddress))
            {
                return BadRequest("An account for this email address already exists.");
            }
            else
            {
                accountService.Add(fullName, emailAddress, passWord);
                return Ok("You have successfully created an account");
            }
        }
    }
}
