using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsDap.DB;
using ModelsDap.Models;

namespace Tests
{
    public class CustomerTests
    {
        [Fact]
        public async Task GetCustomerByEmailTest()
        {
            //Arrange
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            //Act
            var res = await customerDB.GetCustomerByEmailAsync("10407492@ucn.dk");
            //Assert
            Assert.True(res.EMail == @"10407492@ucn.dk" && res.Id == 8);
        }

        [Fact]
        public async Task AddCustomerTest()
        {
            //Arrange
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "Hans",
                Lastname = "Peter",
                Address = "HANSPETERGADE 2",
                EMail = "HANSPETER4@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "123654784",
                ProfilePicture = Array.Empty<byte>()
            };
            //Act
            var res = await customerDB.AddCustomerAsync(customer);
            
            //Assert
            Assert.True(res);

            //CLEANUP
            await customerDB.DeleteCustomerAsync(customer.EMail);
        }
        [Fact]
        public async Task DeleteCustomerTest()
        {
            //Arrange
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            Customer customer = new Customer()
            {
                Firstname = "Hans",
                Lastname = "ANDERSEN",
                Address = "HANSANDERSENGADE 2",
                EMail = "HANSANDERSEN@gmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "87654329",
                ProfilePicture = Array.Empty<byte>()
            };
            customerDB.DeleteCustomerAsync(customer.EMail);
            await customerDB.AddCustomerAsync(customer);
            //Act
            var res = await customerDB.DeleteCustomerAsync(customer.EMail);
            
            //Assert
            Assert.True(res > 0);

        }
    }
}
