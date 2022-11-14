using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsDap.Models;
using Website.Data;

namespace Website.Pages.Testing
{
    public class IndexModel : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public IndexModel(Website.Data.WebsiteContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                Car = await new ModelsDap.DB.DbConnection().GetCarsAsync();
            }
        }
    }
}
