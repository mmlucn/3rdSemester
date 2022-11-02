using Dapper;
using Microsoft.Data.SqlClient;

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
                string query = "select * from Cars JOIN Customers ON Cars.ownerId = Customers.Id JOIN CarImages ON Cars.Id = CarImages.Id";
                var res = con.Query<Car, Customer, CarImages, Car>(query, (car, customer, carimages) =>
                {
                    car.Owner = customer;
                    car.Pictures = carimages
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
                    OwnerId = 2
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
            string path = @"C:\Programmering\UCN\3semester\Projekt\3rdSemester\Tests\pictures\first.jpg";
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
            //using (var con = new SqlConnection(conString))
            //{
            //    string query = "select * from CarImages Where Id = @Id";
            //    con.Query<CarImages>
            //}
        }
    }
}