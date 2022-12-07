using CarRentalSite.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ModelsDap.Models;
using System.Net.Http;

namespace CarRentalSite.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<CarRentalSiteUser> _userManager;

        public IndexModel(HttpClient httpClient, UserManager<CarRentalSiteUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;
        }

        public List<Car> Car { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
                Customer = customer;
            }
            else
            {
                Customer = null;
            }
            
            
            var res = await _httpClient.GetFromJsonAsync<List<Car>>($"api/Car/GetAllCars");

            if (res != null && res.Count > 0)
            {
                Car = res.ToList();
                //foreach (var item in res)
                //{
                //    if (item.OwnerID == customer.Id)
                //    {
                //        res.Remove(item);

                //    }
                //    else
                //    {
                //        Car = res.ToList();
                //    }

                //}

                return Page();
                
            }
            else
            {
                return NotFound();
            }

        }
    }
}
