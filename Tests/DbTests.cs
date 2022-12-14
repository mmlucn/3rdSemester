using ModelsDap.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    public class DbTests
    {
        [Fact]
        public async Task GetImageDtos()
        {
            CarDB carDB = new(@"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
            var res = await carDB.GetPicturesAsync(9);
        }
    }
}
