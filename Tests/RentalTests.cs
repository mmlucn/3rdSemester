using ModelsDap.DB;
using ModelsDap.Models;
using ModelsDap.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RentalTests
    {
        [Fact]
        public async Task AddRentalTest()
        {
            //Arrange
            RentalDB rentalDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "CAR",
                Lastname = "TEST",
                Address = "HANSPETERGADE 2",
                EMail = "CARDELETETEST9@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "1238947894",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.AddCustomerAsync(customer);
            Customer customer2 = new Customer()
            {
                Firstname = "Hans",
                Lastname = "ANDERSEN",
                Address = "HANSANDERSENGADE 2",
                EMail = "HANSANDERSEN8@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "8765432984",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.AddCustomerAsync(customer2);
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
            Rental rental = new()
            {
                CarId = car.Id,
                OwnerId = customer.Id,
                LoanerId = customer2.Id,
                RentalStartPeriod = DateTime.Now,
                RentalEndPeriod = DateTime.Now.AddDays(4)
            };

            //Act
            var res = await rentalDB.AddRentalAsync(rental);
            //Assert
            Assert.True(res);

            //CLEANUP
            await customerDB.DeleteCustomerAsync(customer.EMail);
            await customerDB.DeleteCustomerAsync(customer2.EMail);
            await carDB.DeleteCarAsync(car.Id);
            await rentalDB.DeleteRentalAsync(rental.Id);

        }

        public async Task GetRentalByIdTest()
        {
            //Arrange
            RentalDB rentalDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "CAR",
                Lastname = "TEST",
                Address = "HANSPETERGADE 2",
                EMail = "CARDELETETEST@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "12389478",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.AddCustomerAsync(customer);
            Customer customer2 = new Customer()
            {
                Firstname = "Hans",
                Lastname = "ANDERSEN",
                Address = "HANSANDERSENGADE 2",
                EMail = "HANSANDERSEN@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "87654329",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.AddCustomerAsync(customer2);
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
            Rental rental = new()
            {
                CarId = car.Id,
                OwnerId = customer.Id,
                LoanerId = customer2.Id,
                RentalStartPeriod = DateTime.Now.AddDays(1),
                RentalEndPeriod = DateTime.Now.AddDays(4)
            };
            await rentalDB.AddRentalAsync(rental);
            //Act
            var res = await rentalDB.GetRentalByIdAsync(rental.Id);
            //Assert
            Assert.True(res.Id > 0);

            //CLEANUP
            await customerDB.DeleteCustomerAsync(customer.EMail);
            await customerDB.DeleteCustomerAsync(customer2.EMail);
            await carDB.DeleteCarAsync(car.Id);
            await rentalDB.DeleteRentalAsync(rental.Id);

        }
        public async Task DeleteRentalTest()
        {
            //Arrange
            RentalDB rentalDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "CAR",
                Lastname = "TEST",
                Address = "HANSPETERGADE 2",
                EMail = "CARDELETETEST@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "12389478",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.AddCustomerAsync(customer);
            Customer customer2 = new Customer()
            {
                Firstname = "Hans",
                Lastname = "ANDERSEN",
                Address = "HANSANDERSENGADE 2",
                EMail = "HANSANDERSEN@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "87654329",
                ProfilePicture = Array.Empty<byte>()
            };
            await customerDB.AddCustomerAsync(customer2);
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
            Rental rental = new()
            {
                CarId = car.Id,
                OwnerId = customer.Id,
                LoanerId = customer2.Id,
                RentalStartPeriod = DateTime.Now.AddDays(1),
                RentalEndPeriod = DateTime.Now.AddDays(4)
            };
            await rentalDB.AddRentalAsync(rental);
            //Act
            var res = await rentalDB.DeleteRentalAsync(rental.Id);
            //Assert
            Assert.True(res > 0);

            //CLEANUP
            await customerDB.DeleteCustomerAsync(customer.EMail);
            await customerDB.DeleteCustomerAsync(customer2.EMail);
            await carDB.DeleteCarAsync(car.Id);
            

        }


    }
}
