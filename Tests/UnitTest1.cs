using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using ModelsDap.Models.Enums;

namespace Tests
{
    public class UnitTest1
    {
        private string conString = @"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False";
        [Fact]
        public async Task GetAllCarsAsync()
        {
            using (var con = new SqlConnection(conString))
            {
                string queryCars = "select * from Cars INNER JOIN AspNetUsers ON Cars.ownerId = AspNetUsers.Id";
                var resCars = con.Query<Car, Customer, Car>(queryCars, (car, customer) =>
                {
                    car.Owner = customer;
                    return car;
                });
            }
        }

        [Fact]
        public async Task GetCar()
        {
            using (var con = new SqlConnection(conString))
            {
                string query = "select * from Cars where Id = '2'";
                var res = con.Query<Car>(query);
            }
        }

        [Fact]
        public async Task CreateCar()
        {
            using (var con = new SqlConnection(conString))
            {
                string query = "insert into Cars(Brand, Model, Description, Year, Mileage, Type, FuelType, Doors" +
                    ", FuelConsumption, ElectricityConsumption, HK, GearType, RegNumber, Color, ownerId)" +
                    " VALUES (@Brand, @Model, @Description, @Year, @Mileage, @Type, @FuelType, @Doors, @FuelConsumption, @ElectricityConsumption, @HK, @GearType, @RegNumber, @Color, @ownerId)";

                var result = con.Execute(query, new
                {
                    Brand = "Ford",
                    Model = "Focus",
                    Description = "A nice ford focus",
                    Year = 2015,
                    Mileage = 210_000,
                    Type = CarType.Stationwagon,
                    FuelType = FuelType.Diesel,
                    Doors = 5,
                    FuelConsumption = 22,
                    ElectricityConsumption = 0,
                    HK = 105,
                    GearType = GearType.Manual,
                    RegNumber = "ZY40138",
                    Color = "White",
                    OwnerId = @"ee934626-6e30-408d-a352-67b0e25c1ad2"
                });
            }
        }

        [Fact]
        public async Task DeleteCar()
        {
            var carToDelete = new Car
            {
                Id = 1
            };

            using (var con = new SqlConnection(conString))
            {
                string query = "DELETE FROM Cars Where Id = @Id";
                var res = await con.ExecuteAsync(query, carToDelete);
            }
        }

        [Fact]
        public async Task AddPictures()
        {
            string path = @"C:\Users\mmlke\source\repos\mmlucn\3rdSemester\Tests\pictures\Dalton2.png";
            var file = File.ReadAllBytes(path);

            using (var con = new SqlConnection(conString))
            {
                string query = "INSERT INTO CarImages(Image, CarId) VALUES (@Image, @CarId)";
                var res = con.Execute(query, new
                {
                    CarId = 2,
                    Image = file
                });

                Assert.True(res > 0);
            }
        }

        [Fact]
        public async Task GetPictures()
        {
            using (var con = new SqlConnection(conString))
            {
                string query = "select * from CarImages Where CarId = @Id";
                var res = con.Query<CarImages>(query, new { Id = 2 });
                res.ToList().ForEach(image =>
                {
                    File.WriteAllBytes($"pictures/yolo{image.Image.Length}.png", image.Image);
                });
                Assert.True(res.Count() > 0);
            }
        }
    }
}