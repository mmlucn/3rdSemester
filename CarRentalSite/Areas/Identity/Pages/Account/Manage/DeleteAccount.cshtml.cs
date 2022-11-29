using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsDap.Models;

namespace CarRentalSite.Areas.Identity.Pages.Account.Manage
{
    public class DeleteAccountModel : PageModel
    {
        
        
        
        public Customer Customer { get; set; }


        public void OnGet()
        {
        }



    }
}
