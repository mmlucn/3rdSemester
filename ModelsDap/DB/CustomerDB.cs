using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using ModelsDap.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.DB
{
    public class CustomerDB
    {
        private string _ConString;
        public CustomerDB(string conString)
        {
            _ConString = conString;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            using (var con = new SqlConnection(_ConString))
            {
                try
                {
                    string query = "SELECT * FROM Customers WHERE Email=@Email";
                    var res = await con.QueryAsync<Customer>(query, new
                    {
                        Email = email
                    });
                    if (res.First()?.EMail == email) return res.First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return null;
        }

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            var sql = @"INSERT INTO Customers (Firstname, Lastname, Address, EMail, DateOfBirth, PhoneNumber, ProfilePicture) 
            VALUES (@Firstname, @Lastname, @Address, @EMail, @DateOfBirth, @PhoneNumber, @ProfilePicture)";
            using (var connection = new SqlConnection(_ConString))
            {
                var sqlModel = new
                {
                    Firstname = customer.Firstname,
                    Lastname = customer.Lastname,
                    Address = customer.Address,
                    EMail = customer.EMail,
                    DateOfBirth = customer.DateOfBirth,
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

        public async Task<bool> UpdateProfilePictureAsync(ProfilePictureDTO profilePictureDTO)
        {
            string query = @"UPDATE Customers SET ProfilePicture = @Picture WHERE Id = @UserId";
            using (var con = new SqlConnection(_ConString))
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
        public async Task<int> DeleteCustomerAsync(string email)
        {
            var sql = "DELETE FROM Customers WHERE EMail = @Email \r\n Delete FROM AspNetUsers WHERE Email = @Email";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Email = email });
                return result;
            }
        }
    }
}
