using LoginBackEnd.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginBackEnd.Helpers
{
    public interface IValidation
    {
        bool DoesAccountExist(string emailAddress);
    }

    public class Validation : IValidation
    {
        private IAccountVerification accountVerification;
        public Validation(IAccountVerification accountVerification)
        {
            this.accountVerification = accountVerification;
        }

        public bool DoesAccountExist(string emailAddress)
        {
            return accountVerification.VerifyAccount(emailAddress);
        }
    }
}
