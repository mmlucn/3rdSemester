﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalSite.Data;
using ModelsDap.Models;
using ModelsDap.DB;

namespace CarRentalSite.Pages.cars2
{
    public class CreateModel : PageModel
    {
        

        public CreateModel()
        {
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            HttpClient client = new HttpClient();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                await client.PostAsJsonAsync<Car>(@"https://localhost:7124/api/User/CreateUser", car);
            }
            

            return RedirectToPage("./Index");
        }
    }
}