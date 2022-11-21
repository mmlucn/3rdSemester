using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.DB
{
    public class CarDB
    {
        public async Task<int> AddCarAsync(Car car)
        {

            var sql = "Insert into Cars (Brand, Model, Description, Year, Mileage, Type, FuelType, Doors" +
                ", FuelConsumption, ElectricityConsumption, HK, GearType, RegNumber, Color, ownerId)" +
                "VALUES (@Brand, @Model, @Description, @Year, @Mileage, @Type, @FuelType, @Doors, @FuelConsumption, " +
                "@ElectricityConsumption, @HK, @GearType, @RegNumber, @Color, @ownerId)";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, car);
                return result;
            }
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var sql = "SELECT * FROM Cars WHERE Id = @Id";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Car>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<List<Car>> GetCarsAsync()
        {
            List<Car> cars = new List<Car>();
            using (var con = new SqlConnection(DbConnection.conString))
            {
                string queryCars = "select * from Cars INNER JOIN AspNetUsers ON Cars.ownerId = AspNetUsers.Id";
                var resCars = await con.QueryAsync<Car, Customer, Car>(queryCars, (car, customer) =>
                {
                    car.Owner = customer;
                    return car;
                });

                string queryImg = "select * from CarImages";
                var resImg = await con.QueryAsync<CarImages>(queryImg);
                foreach (var car in resCars)
                {
                    car.Pictures = resImg.Where(img => img.CarId == car.Id).ToList();
                }


                return resCars.ToList();
            }
            return resCars;
        }
        public async Task<int> DeleteCarAsync(int id)
        {
            var sql = "DELETE FROM Cars WHERE Id = @Id";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateCarAsync(Car car)
        {

            var sql = "UPDATE Cars SET Brand @Brand, Model @Model, Description @Description, Year @Year, Mileage @Mileage, Type @Type, FuelType @FuelType, Doors @Doors" +
                ", FuelConsumption @FuelConsumption, ElectricityConsumption @ElectricityConsumption, HK @HK, GearType @GearType, RegNumber @RegNumber, Color @Color  WHERE Id = @Id";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, car);
                return result;
            }
        }
    }
}
