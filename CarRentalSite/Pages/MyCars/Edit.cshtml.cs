using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalSite.Data;
using ModelsDap.Models;

namespace CarRentalSite.Pages.cars2
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        
        [BindProperty]
        public IFormFileCollection? UploadFiles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{id}");
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var res = await _httpClient.PostAsJsonAsync<Car>("api/Car/UpdateCar", Car);

            //TODO: Fix upload af billeder.
            // Det virker her, nu skal API'en bare virke.

            if (UploadFiles != null && UploadFiles.Count > 0)
            {
                foreach (var file in UploadFiles)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    await file.CopyToAsync(memoryStream);
                    var imageAsBase64 = System.Convert.ToBase64String(memoryStream.ToArray());
                    var uploadRes = await _httpClient.PostAsJsonAsync<string>($"api/Car/UploadCarImages/{Car.Id}", imageAsBase64);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
