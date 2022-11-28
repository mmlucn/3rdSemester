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
        private readonly IConfiguration _configuration;
        

        public CreateModel(UserManager<CarRentalSiteUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            
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

            HttpClient client = new HttpClient();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);

                HttpClient httpClient = new HttpClient();
                var customer = await httpClient.GetFromJsonAsync<Customer>($"https://localhost:7124/api/User?email={user.Email}");
                car.OwnerID = customer.Id;
                var res = await client.PostAsJsonAsync<Car>(@"https://localhost:7124/api/Car/AddCar", car);
            }
            

            return RedirectToPage("./Index");
        }
    }
}
