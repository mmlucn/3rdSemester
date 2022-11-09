using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Website.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebsiteUser class
public class WebsiteUser : IdentityUser
{
    public string CPR { get; set; }

    public string DrivingLicenseNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public DateTime DateOfBirth { get; set; }

}

