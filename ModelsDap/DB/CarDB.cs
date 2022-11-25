using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Conversion;
using ModelsDap.Models;
using ModelsDap.Models.DTOS;
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
        private string _ConString;
        public CarDB(string conString)
        {
            _ConString = conString;
        }

        public async Task<bool> AddCarAsync(Car car)
        {

            var sql = "Insert into Cars (Brand, Model, Description, Year, Mileage, Type, FuelType, Doors" +
                ", FuelConsumption, ElectricityConsumption, HK, GearType, RegNumber, Color, ownerId)" +
                "VALUES (@Brand, @Model, @Description, @Year, @Mileage, @Type, @FuelType, @Doors, @FuelConsumption, " +
                "@ElectricityConsumption, @HK, @GearType, @RegNumber, @Color, @ownerId)";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, car);
                return (result == 1);
            }
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var sql = "SELECT * FROM Cars WHERE Id = @Id";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Car>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<List<Car>> GetCarsAsync()
        {
            List<Car>? cars = new List<Car>();
            using (var con = new SqlConnection(_ConString))
            {
                string queryCars = "select * from Cars INNER JOIN Customers ON Cars.ownerId = Customers.Id";
                //Hent alle biler.
                var resCars = await con.QueryAsync<Car, CustomerDTO, Car>(queryCars, (car, customer) =>
                {
                    car.Owner = DTOConverter.CustomerDTOToCustomer(customer);
                    return car;
                });

                //Tilføj eventuelle billeder, til hver bil.
                //string queryImg = "select * from CarImages";
                //var resImg = await con.QueryAsync<CarImages>(queryImg);
                //foreach (var car in resCars)
                //{
                //    car.Pictures = resImg.Where(img => img.CarId == car.Id).ToList();
                //}

                //Retuner alle biler
                cars = resCars.ToList();
            }
            return cars;
        }

        public async Task<List<Car>> GetAllCustomerCarsAsync(int ownerId)
        {
            List<Car>? cars = new List<Car>();
            using (var con = new SqlConnection(_ConString))
            {
                string queryCars = "select * from Cars WHERE ownerId = @ownerId";
                //Hent alle biler.
                var resCars = await con.QueryAsync<Car>(queryCars);
              

                //Tilføj eventuelle billeder, til hver bil.
                //string queryImg = "select * from CarImages";
                //var resImg = await con.QueryAsync<CarImages>(queryImg);
                //foreach (var car in resCars)
                //{
                //    car.Pictures = resImg.Where(img => img.CarId == car.Id).ToList();
                //}

                //Retuner alle biler
                cars = resCars.ToList();
            }
            return cars;
        }

        public async Task<int> DeleteCarAsync(int id)
        {
            var sql = "DELETE FROM Cars WHERE Id = @Id";
            using (var connection = new SqlConnection(_ConString))
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
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, car);
                return result;
            }
        }
    }
}
