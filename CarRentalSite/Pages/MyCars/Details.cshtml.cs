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
using Newtonsoft.Json;
using CarRentalLibrary.Models.DTOS;

namespace CarRentalSite.Pages.cars2
{
    public class DetailsModel : PageModel
    {

        private readonly HttpClient _httpClient;
        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

      public Car Car { get; set; }
        public string[]? CarPicturesAsBase64 { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            var car = await _httpClient.GetFromJsonAsync<Car>($"api/Car/GetCarById/{id}");
            CarPicturesAsBase64 = await _httpClient.GetFromJsonAsync<string[]>($"api/Car/GetPicturesByCarId/{id}");
            var breakpointt = "";

            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
                //CarPictures = 
            }
            return Page();
        }
    }
}
