using LoginBackEnd.DataAccess.Queries;
using LoginBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace LoginBackEnd.Services
{
    public interface ILogInService
    {
        bool LogIn(string emailAddress, string passWord);
    }

    public class LogInService : ILogInService

    {
        private IAccountVerification accountVerification;
        private IPasswordService passwordSvc;

        public LogInService(IAccountVerification accountVerification, IPasswordService passwordSvc)
        {
            this.accountVerification = accountVerification;
            this.passwordSvc = passwordSvc;
        }

        public bool LogIn(string emailAddress, string passWord)
        {
            var hashedPassword = passwordSvc.Hash(passWord);
            var account = new AccountDetails()
            {
                EmailAddress = emailAddress,
                Password = hashedPassword
            };

            return accountVerification.VerifyCredentials(account.EmailAddress, account.Password) ? true : false;
        }
    }
}
