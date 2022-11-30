using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalSite.Data;
using ModelsDap.Models;
using ModelsDap.DB;
using Microsoft.AspNetCore.Identity;
using CarRentalSite.Areas.Identity.Data;

namespace CarRentalSite.Pages.cars2
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<CarRentalSiteUser> _userManager;
        private HttpClient _httpClient;
        

        public CreateModel(
            UserManager<CarRentalSiteUser> userManager, 
            HttpClient httpClient)
        {
            _userManager = userManager;
            _httpClient = httpClient;
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);

                HttpClient httpClient = new HttpClient();
                var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
                car.OwnerID = customer.Id;
                var res = await _httpClient.PostAsJsonAsync<Car>(@"api/Car/AddCar", car);
            }
            

            return RedirectToPage("./Index");
        }
    }
}
