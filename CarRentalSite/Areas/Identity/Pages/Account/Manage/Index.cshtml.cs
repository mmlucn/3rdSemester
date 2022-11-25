// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CarRentalSite.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModelsDap.Models;
using ModelsDap.Models.DTOS;

namespace CarRentalSite.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<CarRentalSiteUser> _userManager;
        private readonly SignInManager<CarRentalSiteUser> _signInManager;
        private Customer _Customer;

        public IndexModel(
            UserManager<CarRentalSiteUser> userManager,
            SignInManager<CarRentalSiteUser> signInManager)
            
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        public string? ProfilePictureBase64 { get; set; }

        public string CPR { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Profile Picture")]
            public IFormFile ProfilePicture { get; set; }
        }

        private async Task LoadAsync(CarRentalSiteUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            HttpClient client = new HttpClient();
            var res = await client.GetFromJsonAsync<Customer>($"https://localhost:7124/api/User?email={user.Email}");
            if (res != null)
                _Customer = res;

            Username = userName;
            CPR = _Customer.CPR;
            ProfilePictureBase64 = System.Convert.ToBase64String(_Customer.ProfilePicture);

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            HttpClient client = new HttpClient();
            var customer = await client.GetFromJsonAsync<Customer>($"https://localhost:7124/api/User?email={user.Email}");

            if (Input.ProfilePicture != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                Input.ProfilePicture.CopyTo(memoryStream);
                var picBase64 = System.Convert.ToBase64String(memoryStream.ToArray());

                HttpClient httpClient = new();
                var res = await httpClient.PostAsJsonAsync<ProfilePictureDTO>(@"https://localhost:7124/api/User/UpdateProfilePicture", new ProfilePictureDTO
                {
                    PictureAsBase64 = picBase64,
                    UserId = customer.Id
                });
            }
            

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
