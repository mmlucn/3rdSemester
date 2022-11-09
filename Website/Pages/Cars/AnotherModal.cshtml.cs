using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Cars
{
    public class AnotherModalModel : PageModel
    {
        public ModelsDap.Models.Car Car { get; set; }

        public AnotherModalModel(ModelsDap.Models.Car car)
        {
            Car = car;
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            return Page();
        }

    }
}
