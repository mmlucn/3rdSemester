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
using Dapper;

namespace CarRentalSite.Pages.Rentals
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<CarRentalSiteUser> _userManager;
        private readonly HttpClient _httpClient;

        [BindProperty]
        public IList<Rental> Rentals { get; set; } = default!;

        [BindProperty]
        public IList<Car> RentalCars { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public IndexModel(HttpClient httpClient, UserManager<CarRentalSiteUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;
        }
        

        


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
            int loanerId = customer.Id;
            Customer = customer;

            var res = await _httpClient.GetFromJsonAsync<List<Rental>>($"api/Rental/GetAllLoanerRentals/{loanerId}");
            
            if (res != null)
            {
                Rentals = res.ToList();

                //foreach (var rental in Rentals)
                //{
                //    RentalCars.Add(await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{rental.CarId}"));
                //}

                return Page();
            }
            return Page();
        }
    }
}
