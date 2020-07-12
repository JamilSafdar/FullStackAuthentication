using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBackEnd.DataAccess.Queries
{
    public interface IAccountVerification
    {
        bool VerifyAccount(string emailAddress);
        bool VerifyCredentials(string emailAddress, string passWord);
    }
    public class AccountVerification : IAccountVerification
    {
        private readonly IConfiguration configuration;

        public AccountVerification(IConfiguration config)
        {
            configuration = config;
        }

        public bool VerifyAccount(string emailAddress)
        {
            var connectionString = configuration.GetConnectionString("MySQL");
            string email = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT EmailAddress FROM Person WHERE EmailAddress = @EmailAddress";
                cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        email = reader.GetString(0);
                    }
                }
            }

            return email == emailAddress ? true : false;
        }

        public bool VerifyCredentials(string emailAddress, string passWord)
        {
            var connectionString = configuration.GetConnectionString("MySQL");
            string email = "";
            string password = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT EmailAddress, Password FROM Person WHERE EmailAddress = @EmailAddress";
                cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        email = reader.GetString(0);
                        password = reader.GetString(1);

                    }
                }
            }

            if (email == emailAddress && password == passWord)
            {
                return true;
            }
            else
                return false;
        }
    }

}