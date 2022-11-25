﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;
using ModelsDap.DB;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace CarRentalSite.Pages.cars2
{
    public class DeleteModel : PageModel
    {
        
        

        public DeleteModel()
        {
            
        }

        public class InputModel
        {
            [Display(Name = "ID")]
            public string Id { get; set; }
        }

        [BindProperty]
      public Car Car { get; set; }

        public async Task<ActionResult<Car>> OnGetAsync(int? id)
        {
            HttpClient client = new HttpClient();



            if (id == null || client == null)
            {
                return NotFound();
            }

            var res = await client.PostAsJsonAsync<int>(@"https://localhost:7124/api/Car?id", (int)id);
            string resAsString = res.Content.ToString();
            Car car = JsonConvert.DeserializeObject<Car>(resAsString);

            if (res == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            HttpClient client = new HttpClient();

            if (id == null || client == null)
            {
                return NotFound();
            }

            await client.PostAsJsonAsync<int>(@"https://localhost:7124/api/Car/DeleteCar?id", id);
            

            return RedirectToPage("./Index");
        }
    }
}