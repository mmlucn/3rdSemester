using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalSite.Data;
using ModelsDap.Models;
using CarRentalSite.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Runtime.ConstrainedExecution;

namespace CarRentalSite.Pages.AllCars
{
    public class AddRentalModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<CarRentalSiteUser> _userManager;

        [BindProperty]
        public Car Car { get; set; }
        public IList<Rental>? Rentals { get; set; } = default!;


        public AddRentalModel(HttpClient httpClient, UserManager<CarRentalSiteUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;

        }
        

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{id}");
            var rentalsUnderCar = await _httpClient.GetFromJsonAsync<List<Rental>>($"api/Rental/GetAllCarsRentals/{id}");
            if (rentalsUnderCar.Count > 0)
            {
                Rentals = rentalsUnderCar.ToList();
            }
            else
            {
                Rentals = null;
            }
            if (car.OwnerID == customer.Id)
                return Forbid();
            else
                return Page();


        }

        [BindProperty]
        public Rental Rental { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{id}");
            Rental.LoanerId = customer.Id;
            Rental.CarId = car.Id;
            Rental.OwnerId = car.OwnerID;
            var res = await _httpClient.PostAsJsonAsync<Rental>(@"api/Rental/AddRental", Rental);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");

            }
            else
            {
                var errorMessage = await res.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, "Sorry the car is not available in the requested period");
                return Page();
            }
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //else
            //{
            //    var res = await _httpClient.PostAsJsonAsync<Rental>(@"api/Rental/AddRental", Rental);
            //}




            
        }
    }
}
