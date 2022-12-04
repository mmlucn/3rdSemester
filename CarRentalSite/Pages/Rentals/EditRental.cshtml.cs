using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;

namespace CarRentalSite.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Rental Rental { get; set; } = default!;

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
            Rental = rental;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //TODO: Edit bliver ikke opdateret efter man ændrer datoerne i en rental

            var res = _httpClient.PostAsJsonAsync<Rental>($"api/Rental/UpdateRental", Rental);

            //try
            //{
            //    var res = _httpClient.PostAsJsonAsync<Rental>($"api/Rental/UpdateRental", Rental);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RentalExists(Rental.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        
    }
}
