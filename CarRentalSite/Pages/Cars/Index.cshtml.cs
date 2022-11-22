using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsDap.Models;

namespace CarRentalSite.Pages.Cars
{
    public class IndexModel : PageModel
    {
        public List<Car> AllCars { get; set; }
        
        public void OnGet()
        {

        }
    }
}
