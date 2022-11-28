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

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Car> Car { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            var res = await _httpClient.GetFromJsonAsync<List<Car>>($"api/Car/GetAllCars");

            if (res != null && res.Count > 0)
            {
                Car = res.ToList();
                return Page();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
