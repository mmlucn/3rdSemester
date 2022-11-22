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
        public async Task GetCustomer()
        {
            CustomerDB customerDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            var res = await customerDB.GetCustomerByEmail("malthe@morsingdata.dk");
            Assert.True(res.EMail == @"malthe@morsingdata.dk" && res.Id == 1);
        }
    }
}
