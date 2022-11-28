using CarRentalSite.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsDap.Models;

namespace CarRentalSite.Pages.AllCars
{
    public class DetailsModel : PageModel
    {
        public int Id { get; set; }

        public Car Car { get; set; }

        private readonly SignInManager<CarRentalSiteUser> _signInManager;
        private readonly UserManager<CarRentalSiteUser> _userManager;
        private readonly HttpClient _httpClient;

        public DetailsModel(UserManager<CarRentalSiteUser> userManager, SignInManager<CarRentalSiteUser> signInManager, HttpClient httpClient)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpClient = httpClient;
        }


        public async Task<IActionResult> OnGet([FromQuery] int id)
        {
            Id = id;
            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{Id}");
            if (car == null)
            {
                return NotFound();
            }

            Car = car;
            return Page();
        }
    }
}
