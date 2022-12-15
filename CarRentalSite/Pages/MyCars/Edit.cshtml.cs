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
using ModelsDap.DB;
using CarRentalLibrary.Models.DTOS;
using Microsoft.AspNetCore.Identity;
using CarRentalSite.Areas.Identity.Data;

namespace CarRentalSite.Pages.cars2
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<CarRentalSiteUser> _userManager;

        public EditModel(HttpClient httpClient, UserManager<CarRentalSiteUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;
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

            var user = await _userManager.GetUserAsync(User);
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{id}");
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            
            if (car.OwnerID != customer.Id)
            {
                return Forbid();
            }
            else
            {
                return Page();
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _httpClient.PostAsJsonAsync<Car>("api/Car/UpdateCar", Car);


            if (UploadFiles != null && UploadFiles.Count > 0)
            {
                List<CarImageDTO> carImageDTOs = new();
                foreach (var file in UploadFiles)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    await file.CopyToAsync(memoryStream);
                    var imageAsBase64 = System.Convert.ToBase64String(memoryStream.ToArray());
                    carImageDTOs.Add(new CarImageDTO()
                    {
                        CarId = Car.Id,
                        Id = null,
                        ImageAsBase64 = imageAsBase64
                    });
                }

                var uploadRes = await _httpClient.PostAsJsonAsync<List<CarImageDTO>>($"api/Car/UploadCarImages", carImageDTOs);
            }

            return RedirectToPage("./Index");
        }
    }
}
