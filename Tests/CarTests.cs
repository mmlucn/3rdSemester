using ModelsDap.DB;
using ModelsDap.Models;
using ModelsDap.Models.DTOS;
using ModelsDap.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   public class CarTests
    {
        [Fact]
        public async Task GetCarByIdTest()
        {
            //Arrange
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "CAR",
                Lastname = "TEST",
                Address = "HANSPETERGADE 2",
                EMail = "CARTEST41@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "1238947841",
                ProfilePicture = Array.Empty<byte>()
            };
            
            await customerDB.AddCustomerAsync(customer);
            Car car = new()
            {
                Brand = "Toyota",
                Model = "fdf",
                Description = "a",
                Year = 2000,
                Mileage = 20000,
                Type = CarType.Hatchback,
                Doors = 4,
                FuelConsumption = 20,
                ElectricityConsumption = null,
                HK = 200,
                GearType = GearType.Automatic,
                RegNumber = "ey78945",
                Color = "string",
                PricePerDay = 250,
                OwnerID = customer.Id,
            };
           
            await carDB.AddCarAsync(car);
            //Act
            var res = await carDB.GetCarByIdAsync(car.Id);
            //Assert
            Assert.True(res.Id > 0);

            //CLEANUP
            await carDB.DeleteCarAsync(car.Id);
            await customerDB.DeleteCustomerAsync(customer.EMail);
        }
        [Fact]
        public async Task AddCarTest()
        {
            //Arrange
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "CAR",
                Lastname = "TEST",
                Address = "HANSPETERGADE 2",
                EMail = "CARTEST@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "12389478",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.DeleteCustomerAsync(customer.EMail);
            await customerDB.AddCustomerAsync(customer);
            Car car = new()
            {
                Brand = "Toyota",
                Model = "fdf",
                Description = "a",
                Year = 2000,
                Mileage = 20000,
                Type = CarType.Hatchback,
                Doors = 4,
                FuelConsumption = 20,
                ElectricityConsumption = null,
                HK = 200,
                GearType = GearType.Automatic,
                RegNumber = "ey78945",
                Color = "string",
                PricePerDay = 250,
                OwnerID = customer.Id,
            };
            //Act
            var res = await carDB.AddCarAsync(car);
            //Assert
            Assert.True(res > 0);

            //CLEANUP
            await carDB.DeleteCarAsync(car.Id);
            await customerDB.DeleteCustomerAsync(customer.EMail);
        }
        [Fact]
        public async Task GetAllCarsTest()
        {
            //Arrange
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            //Act
            var res = await carDB.GetCarsAsync();
            //Assert
            Assert.True(res.Count > 0);
        }
        [Fact]
        public async Task DeleteCarTest()
        {
            //Arrange
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "CAR",
                Lastname = "TEST",
                Address = "HANSPETERGADE 2",
                EMail = "CARDELETETEST2@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "12389498",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.DeleteCustomerAsync(customer.EMail);
            customerDB.AddCustomerAsync(customer);
            Car car = new()
            {
                Brand = "Toyota",
                Model = "aqe",
                Description = "a",
                Year = 2000,
                Mileage = 20000,
                Type = CarType.Hatchback,
                Doors = 4,
                FuelConsumption = 20,
                ElectricityConsumption = null,
                HK = 200,
                GearType = GearType.Automatic,
                RegNumber = "ey78945",
                Color = "string",
                PricePerDay = 250,
                OwnerID = customer.Id,
            };
            await carDB.AddCarAsync(car);
            //Act
            var res = await carDB.DeleteCarAsync(car.Id); ;
            //Assert
            Assert.True(res > 0);

            //CLEANUP
            await customerDB.DeleteCustomerAsync(customer.EMail);
        }



    }
}
