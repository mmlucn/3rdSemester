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
        public bool AllowedToRent { get; set; }

        public DetailsModel(UserManager<CarRentalSiteUser> userManager, SignInManager<CarRentalSiteUser> signInManager, HttpClient httpClient)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpClient = httpClient;
        }


        public async Task<IActionResult> OnGet([FromQuery] int id)
        {
            Id = id;
            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{Id}");

            AllowedToRent = (car.OwnerID != customer.Id);

            if (car == null)
            {
                return NotFound();
            }
            //var pics = await _httpClient.GetFromJsonAsync<List<string>>($"api/Car/GetPicturesByCarId/{Id}");
            //if (pics != null)
            //    car.Pictures = pics;
            Car = car;
            if (car.OwnerID == customer.Id)
            {
                return Forbid();
            }
            else
            {
                return Page();
            }
        }
    }
}
