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

namespace CarRentalSite.Pages.cars2
{
    public class IndexModel : PageModel
    {
        
        private readonly UserManager<CarRentalSiteUser> _userManager;
        private readonly IConfiguration _configuration;
        public IndexModel(UserManager<CarRentalSiteUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync(int ownerId)
        {

            HttpClient client = new HttpClient();
            var user = await _userManager.GetUserAsync(User);
           
            var customer = await client.GetFromJsonAsync<Customer>($"https://localhost:7124/api/User?email={user.Email}");
            ownerId = customer.Id;


            var res = await client.GetFromJsonAsync<List<Car>>(@"https://localhost:7124/api/Car/GetAllUsersCars?id="+ ownerId);
            
            

            if (res != null)
            {
                Car = res.ToList();
            }
        }
    }
}
