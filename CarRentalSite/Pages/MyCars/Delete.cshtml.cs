using System;
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
        private readonly HttpClient _httpClient;


        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public class InputModel
        {
            [Display(Name = "ID")]
            public string Id { get; set; }
        }

        [BindProperty]
      public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            

            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{id}");

            if (car == null)
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

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                await _httpClient.DeleteAsync($"api/Car/DeleteCar/{id}");
            }
           
            

            return RedirectToPage("./Index");
        }
    }
}
