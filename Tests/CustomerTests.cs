using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsDap.DB;

namespace Tests
{
    public class CustomerTests
    {
        [Fact]
        public async Task GetCustomerByEmail()
        {
            //Arrange
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            //Act
            var res = await customerDB.GetCustomerByEmailAsync("10407492@ucn.dk");
            //Assert
            Assert.True(res.EMail == @"10407492@ucn.dk" && res.Id == 8);
        }
    }
}
