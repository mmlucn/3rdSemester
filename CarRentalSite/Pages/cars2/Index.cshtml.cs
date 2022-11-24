using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;

namespace CarRentalSite.Pages.cars2
{
    public class IndexModel : PageModel
    {
        HttpClient client = new HttpClient();

        public IndexModel()
        {
            
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {

            HttpClient client = new HttpClient();
            var res = await client.GetFromJsonAsync<List<Car>>(@"https://localhost:7124/api/Car/GetAllCars");
            
            

            if (res != null)
            {
                Car = res.ToList();
            }
        }
    }
}
