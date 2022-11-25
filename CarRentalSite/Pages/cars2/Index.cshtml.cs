using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;
using Microsoft.AspNetCore.Identity;
using CarRentalSite.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalSite.Pages.cars2
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            
            var res = await _httpClient.GetFromJsonAsync<List<Car>>(@"api/Car/GetAllCars");

            if (res != null && res.Count > 0)
            {
                Car = res.ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("Create");
            }
        }

    }
}
