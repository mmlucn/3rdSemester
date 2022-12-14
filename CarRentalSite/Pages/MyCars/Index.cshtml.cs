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
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace CarRentalSite.Pages.cars2
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

        public IList<Car> Car { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
            int ownerId = customer.Id;

            //Ugly fix, but works

            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Car>>($"api/Car/GetAllUsersCars/{ownerId}");
                if (res != null && res.Count > 0)
                {

                    Car = res.ToList();
                    return Page();
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("Create");
            }
            return Page();
        }

    }
}
