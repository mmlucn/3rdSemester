using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;
using ModelsDap.DB;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using CarRentalSite.Areas.Identity.Data;

namespace CarRentalSite.Pages.cars2
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<CarRentalSiteUser> _userManager;


        public DeleteModel(HttpClient httpClient, UserManager<CarRentalSiteUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;
        }

        public class InputModel
        {
            [Display(Name = "ID")]
            public string Id { get; set; }
        }

        [BindProperty]
      public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int carId)
        {
            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");

            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{carId}");

            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
            }
            if (car.OwnerID != customer.Id)
            {
                return Forbid();
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int carId)
        {
            
            if (carId == null)
            {
                return NotFound();
            }
            else
            {
                await _httpClient.DeleteAsync($"api/Car/DeleteCar/{carId}");
            }
           
            

            return RedirectToPage("./Index");
        }
    }
}
