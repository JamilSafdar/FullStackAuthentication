using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginBackEnd.Services
{
    public interface IPasswordService
    {
        string Hash(string password);
    }
    public class PasswordService : IPasswordService
    {
        public string Hash(string password)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(bytes);
            var hashedPassword = Encoding.ASCII.GetString(sha1data);

            return hashedPassword;
        }
    }
}
