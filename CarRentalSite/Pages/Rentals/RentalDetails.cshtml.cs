using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;

namespace CarRentalSite.Pages.Rentals
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

      public Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _httpClient == null)
            {
                return NotFound();
            }

            var res = await _httpClient.GetFromJsonAsync<Rental>($"api/Rental/GetRentalById/{id}");
            if (res == null)
            {
                return NotFound();
            }
            else 
            {
                Rental = res;
            }
            return Page();
        }
    }
}
