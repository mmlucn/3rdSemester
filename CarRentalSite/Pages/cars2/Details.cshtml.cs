using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;
using ModelsDap.DB;
using Newtonsoft.Json;

namespace CarRentalSite.Pages.cars2
{
    public class DetailsModel : PageModel
    {
        

        public DetailsModel()
        {
            
        }

      public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            HttpClient client = new HttpClient();
            var car = await client.GetFromJsonAsync<Car>(@"https://localhost:7124/api/Car?id=" + id);

            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }
    }
}
