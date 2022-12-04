using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;

namespace CarRentalSite.Pages.Rentals
{
    public class DeleteModel : PageModel
    {
        private readonly CarRentalSite.Data.CarRentalSiteContext _context;

        public DeleteModel(CarRentalSite.Data.CarRentalSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FirstOrDefaultAsync(m => m.Id == id);

            if (rental == null)
            {
                return NotFound();
            }
            else 
            {
                Rental = rental;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }
            var rental = await _context.Rental.FindAsync(id);

            if (rental != null)
            {
                Rental = rental;
                _context.Rental.Remove(Rental);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
