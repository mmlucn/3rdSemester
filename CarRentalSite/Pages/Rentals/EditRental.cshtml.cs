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
using Microsoft.AspNetCore.Identity;
using CarRentalSite.Areas.Identity.Data;

namespace CarRentalSite.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<CarRentalSiteUser> _userManager;

        [BindProperty]
        public Rental RentalModel { get; set; }

        private int? _loanerId;
        private int? _ownerId;
        private int? _carId;

        public EditModel(HttpClient httpClient, UserManager<CarRentalSiteUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _httpClient == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
            var rental = await _httpClient.GetFromJsonAsync<Rental>($"api/Rental/GetRentalById/{id}");
            if(DateTime.Compare(rental.RentalEndPeriod, DateTime.Now) < 0)
            {
                return Forbid();
            }
            else
            {
                    
            }
            if (rental == null)
            {
                return NotFound();
            }
            RentalModel = rental;
            _loanerId = rental.LoanerId;
            _ownerId = rental.OwnerId;
            _carId = rental.CarId;
            if (DateTime.Compare(rental.RentalStartPeriod, DateTime.UtcNow) < 0 && DateTime.Compare(rental.RentalEndPeriod, DateTime.Now) < 0 && rental.LoanerId != customer.Id)
            {
                return Forbid();
            }
            else
            {
                return Page();
            }
            
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _httpClient.PostAsJsonAsync<Rental>($"api/Rental/UpdateRental", RentalModel);


            return RedirectToPage("./Index");
        }

        
    }
}
