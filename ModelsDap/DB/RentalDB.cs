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
        private string _ConString;
        public RentalDB(string conString)
        {
            _ConString = conString;
        }
        public async Task<bool> AddRentalAsync(Rental rental)
        {

            var sql = "Insert into Rentals (carId, ownerId, loanerId, RentalStartPeriod, RentalEndPeriod)" +
                "VALUES (@carId,@ownerId,@loanerId,@RentalStartPeriod, @RentalEndPeriod)";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, rental);
                return (result == 1);
            }
        }
        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            var sql = "SELECT * FROM Rentals WHERE Id = @Id";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Rental>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<List<Rental>> GetAllOwnersRentalsAsync(int ownerId)
        {
            List<Rental> rentals = new List<Rental>();
            using (var con = new SqlConnection(_ConString))
            {
                string queryRentals = "select * from Rentals WHERE ownerId = @ownerId";
                var resRentals = await con.QueryAsync<Rental>(queryRentals, new
                {
                    ownerId = ownerId
                });

                return resRentals.ToList();
            }
            return null;
        }
        public async Task<List<Rental>> GetAllLoanersRentalsAsync(int loanerId)
        {
            List<Rental> rentals = new List<Rental>();
            using (var con = new SqlConnection(_ConString))
            {
                string queryRentals = "select * from Rentals WHERE loanerId = @loanerId";
                var resRentals = await con.QueryAsync<Rental>(queryRentals, new
                {
                    loanerId = loanerId
                });

                return resRentals.ToList();
            }
            return null;
        }
        public async Task<int> UpdateRentalAsync(Rental rental)
        {

            var sql = "UPDATE Rentals SET RentalStartPeriod =  @RentalPeriod, RentalEndPeriod = @RentalEndPeriod  WHERE Id = @Id";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, rental);
                return result;
            }
        }

        public async Task<int> DeleteRentalAsync(int id)
        {
            var sql = "DELETE FROM Rentals WHERE Id = @Id";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }


    }
}
