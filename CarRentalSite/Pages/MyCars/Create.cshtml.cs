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
using Microsoft.AspNetCore.Identity;
using CarRentalSite.Areas.Identity.Data;
using CarRentalLibrary.Models.DTOS;

namespace CarRentalSite.Pages.cars2
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<CarRentalSiteUser> _userManager;
        private HttpClient _httpClient;
        

        public CreateModel(
            UserManager<CarRentalSiteUser> userManager, 
            HttpClient httpClient)
        {
            _userManager = userManager;
            _httpClient = httpClient;
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set;}

        [BindProperty]
        public IFormFileCollection? UploadFiles { get; set;}


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            
                var user = await _userManager.GetUserAsync(User);
                var customer = await _httpClient.GetFromJsonAsync<Customer>($"api/User?email={user.Email}");
                Car.OwnerID = customer.Id;
                var res = await _httpClient.PostAsJsonAsync<Car>(@"api/Car/AddCar", Car);

            //TODO: den uploader ikke billederne???

                if (UploadFiles != null && UploadFiles.Count > 0)
                {
                    List<string> imagesAsBase64 = new();
                    foreach (var file in UploadFiles)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        await file.CopyToAsync(memoryStream);
                        var imageAsBase64 = System.Convert.ToBase64String(memoryStream.ToArray());
                        imagesAsBase64.Add(imageAsBase64);
                    }

                    CarImagesDTO carImagesDTO = new CarImagesDTO()
                    {
                        CarId = Car.Id,
                        ImageAsByte64 = imagesAsBase64.ToArray()
                    };
                    var uploadRes = await _httpClient.PostAsJsonAsync<CarImagesDTO>($"api/Car/UploadCarImages", carImagesDTO);
                }
                


            return RedirectToPage("./Index");
        }
    }
}
