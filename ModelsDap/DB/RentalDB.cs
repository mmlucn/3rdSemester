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
    public class RentalDB
    {
        public async Task<int> AddRentalAsync(Rental rental)
        {

            var sql = "Insert into Rentals (carId, ownerId, loanerId, RentalPeriod)" +
                "VALUES (@carId,@ownerId,@loanerId,@RentalPeriod)";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, rental);
                return result;
            }
        }
        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            var sql = "SELECT * FROM Rentals WHERE Id = @Id";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Rental>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<List<Rental>> GetAllUsersRentalsAsync(int ownerId)
        {
            List<Rental> rentals = new List<Rental>();
            using (var con = new SqlConnection(DbConnection.conString))
            {
                string queryRentals = "select * from Rentals WHERE ownerId = @ownerId";
                var resRentals = await con.QueryAsync<Rental>(queryRentals) =>
                {
                    
                    
                });

                return resRentals.ToList();
            }
            return null;
        }
        public async Task<int> UpdateRentalAsync(Rental rental)
        {

            var sql = "UPDATE Rentals SET RentalPeriod @RentalPeriod  WHERE Id = @Id";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, rental);
                return result;
            }
        }


    }
}
