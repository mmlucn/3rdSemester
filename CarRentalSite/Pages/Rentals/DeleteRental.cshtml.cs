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
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
      public Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _httpClient == null)
            {
                return NotFound();
            }

            var rental = await _httpClient.GetFromJsonAsync<Rental>($"api/Rental/GetRentalById/{id}");

            if (rental == null)
            {
                return NotFound();
            }
            else 
            {
                Rental = rental;
            }
            if (DateTime.Compare(rental.RentalStartPeriod, DateTime.Now) < 0)
            {
                return Forbid();
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null && _httpClient == null)
            {
                return NotFound();
            }
            else
            {
                await _httpClient.DeleteAsync($"api/Rental/DeleteRental/{id}");
            }
            
            

            return RedirectToPage("./Index");
        }
    }
}
