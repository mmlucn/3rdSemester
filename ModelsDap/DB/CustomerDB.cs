using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.DB
{
    public class CustomerDB
    {
        private string _ConnectionString;
        public CustomerDB(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                string query = "SELECT * FROM Customers WHERE Email=@Email";
                var res = await con.QueryAsync<Customer>(query, new
                {
                    Email = email
                });
                if (res.First()?.EMail == email) return res.First();
            }
            return null;
        }

        public async Task<bool> AddCarAsync(Customer customer)
        {

            var sql = "Insert into Customers (FirstName, LastName, Address, Email, CPR, DateOfBirth, DrivingLicenseNumber" +
                ", PhoneNumber, ProfilePicture)" +
                "VALUES (@FirstName, @LastName, @Address, @Email, @CPR, @DateOfBirth, @DrivingLicenseNumber " +
                "@PhoneNumber, @ProfilePicture)";
            using (var connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, customer);
                return (result == 1);
            }
        }
    }
}
