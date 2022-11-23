using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using ModelsDap.Models.DTOS;
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

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            var sql = @"INSERT INTO Customers (Firstname, Lastname, Address, EMail, CPR, DateOfBirth, DrivingLicenseNumber, PhoneNumber, ProfilePicture) 
            VALUES (@Firstname, @Lastname, @Address, @EMail, @CPR, @DateOfBirth, @DrivingLicenseNumber, @PhoneNumber, @ProfilePicture)";
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var sqlModel = new
                {
                    Firstname = customer.Firstname,
                    Lastname = customer.Lastname,
                    Address = customer.Address,
                    EMail = customer.EMail,
                    CPR = customer.CPR,
                    DateOfBirth = customer.DateOfBirth,
                    DrivingLicenseNumber = customer.DrivingLicenseNumber,
                    PhoneNumber = customer.PhoneNumber,
                    ProfilePicture = Array.Empty<byte>()
                };
                try
                {
                    var result = await connection.ExecuteAsync(sql, sqlModel);
                    return (result == 1);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return false;
            }
        }

        public async Task<bool> UpdateProfilePicture(ProfilePictureDTO profilePictureDTO)
        {
            string query = @"UPDATE Customers SET ProfilePicture = @Picture WHERE Id = @UserId";
            using (var con = new SqlConnection(_ConnectionString))
            {
                var res = await con.ExecuteAsync(query, new
                {
                    Picture = System.Convert.FromBase64String(profilePictureDTO.PictureAsBase64),
                    UserId = profilePictureDTO.UserId
                });
                return (res == 1);
            }
            return false;
        }
    }
}
