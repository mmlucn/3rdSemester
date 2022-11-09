using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsDap.DB;
using ModelsDap.Models;

namespace Website.Pages.Cars
{
    public class CarsModel : PageModel
    {
        public DbConnection _dbConnection { get; set; }
        public ModelsDap.Models.Car[]? cars { get; set; }
        public CarsModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            cars = (await _dbConnection.GetCarsAsync()).ToArray();
            return Page();
        }

        public void OnPost()
        {

        }
        
    }
}
