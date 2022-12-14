using CarRentalLibrary.Models.DTOS;
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
using System.Net.Http.Headers;
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

        /// <summary>
        /// Add a car to the DB
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Returns the ID of the inserted car</returns>
        public async Task<int> AddCarAsync(Car car)
        {
            var sql = "Insert into Cars (Brand, Model, Description, Year, Mileage, Type, FuelType, Doors" +
                ", FuelConsumption, ElectricityConsumption, HK, GearType, RegNumber, Color, PricePerDay, ownerId)" +
                "VALUES (@Brand, @Model, @Description, @Year, @Mileage, @Type, @FuelType, @Doors, @FuelConsumption, " +
                "@ElectricityConsumption, @HK, @GearType, @RegNumber, @Color, @PricePerDay, @ownerId); SELECT SCOPE_IDENTITY();";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.QueryAsync<int>(sql, car);
                return result.First();
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
                string queryCars = "select * from Cars";
                //Hent alle biler.
                var resCars = await con.QueryAsync<Car>(queryCars);

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
                var resCars = await con.QueryAsync<Car>(queryCars, new
                {
                    ownerId = ownerId
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

        public async Task<int> DeleteCarAsync(int id)
        {
            var sql = "DELETE FROM CarImages WHERE CarId = @Id \r\n DELETE FROM Cars WHERE Id = @Id";
            using (var connection = new SqlConnection(_ConString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateCarAsync(Car car)
        {

            var sql = @"UPDATE Cars
                        SET Brand = @Brand, Model = @Model, Description = @Description,
                        Year = @Year, Mileage = @Mileage, Type = @Type, FuelType = @FuelType,
                        Doors = @Doors, FuelConsumption = @FuelConsumption, ElectricityConsumption = @ElectricityConsumption,
                        HK = @HK, GearType = @GearType, RegNumber = @RegNumber ,Color = @Color WHERE Id = @Id";
            using (var connection = new SqlConnection(_ConString))
            {
                try
                {
                    var result = await connection.ExecuteAsync(sql, car);
                    return result;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carId">Id of the car</param>
        /// <returns>A list of images as a base64 string</returns>
        public async Task<List<CarImageDTO>> GetPicturesAsync(int carId)
        {
            using (var con = new SqlConnection(_ConString))
            {
                var query = "select * from CarImages Where CarId = @CarId";
                var res = await con.QueryAsync<CarImage>(query, param: new { CarId = carId });

                var returnList = new List<CarImageDTO>();
                foreach (var item in res)
                {
                    returnList.Add(new CarImageDTO
                    {
                        Id = (int)item.Id,
                        ImageAsBase64 = Convert.ToBase64String(item.Image),
                        CarId = item.CarId
                    });
                }

                return returnList;
            }
        }

        public async Task<bool> UploadCarImages(List<CarImageDTO> carImagesDTO)
        {
            int imageCountToUpload = carImagesDTO.Count;
            int succesfullyUploadedCount = 0;

            var query = "insert into CarImages (Image, CarId) VALUES (@Image, @CarId)";

            using (var conn = new SqlConnection(_ConString))
            {
                foreach (var carImageDto in carImagesDTO)
                {
                    CarImage carImage = new CarImage()
                    {
                        Id = null,
                        CarId = carImageDto.CarId,
                        Image = Convert.FromBase64String(carImageDto.ImageAsBase64)
                    };

                    var res = await conn.ExecuteAsync(query, carImage);
                    succesfullyUploadedCount += res;
                }
                return (imageCountToUpload == succesfullyUploadedCount);
            }
        }
    }
}
