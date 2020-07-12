using LoginBackEnd.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginBackEnd.DataAccess.Commands
{
    public interface ICreateAccount
    {
        bool Create(AccountDetails account);
    }

    public class CreateAccount : ICreateAccount
    {
        private readonly IConfiguration configuration;

        public CreateAccount(IConfiguration config)
        {
            configuration = config;
        }

        public bool Create(AccountDetails account)
        {
            var connectionString = configuration.GetConnectionString("MySQL");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Person(FullName, EmailAddress, Password ) VALUES(@FullName, @EmailAddress, @Password)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@FullName", account.FullName);
                cmd.Parameters.AddWithValue("@EmailAddress", account.EmailAddress);
                cmd.Parameters.AddWithValue("@Password", account.Password);
                cmd.ExecuteNonQuery();
            }

            return true;

        }
    }
}
