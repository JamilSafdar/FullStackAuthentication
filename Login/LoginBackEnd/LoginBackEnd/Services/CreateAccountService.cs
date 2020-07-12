using LoginBackEnd.DataAccess.Commands;
using LoginBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginBackEnd.Services
{
    public interface ICreateAccountService
    {
        void Add(string fullName, string emailAddress, string passWord);
    }
    public class CreateAccountService : ICreateAccountService
    {
        private ICreateAccount createAccount;
        private IPasswordService passwordSvc;

        public CreateAccountService(ICreateAccount createAccount, IPasswordService passwordSvc)
        {
            this.createAccount = createAccount;
            this.passwordSvc = passwordSvc;
        }

        public void Add(string fullName, string emailAddress, string passWord)
        {
            var hashedPassword = passwordSvc.Hash(passWord);
            var account = new AccountDetails()
            {
                FullName = fullName,
                EmailAddress = emailAddress,
                Password = hashedPassword
            };

            createAccount.Create(account);
        }
    }
}
