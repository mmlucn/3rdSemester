using CarRentalSite.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsDap.Models;

namespace CarRentalSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        

        public Customer Customer { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }

        public async void OnGet()
        {
            
            


        }
    }
}