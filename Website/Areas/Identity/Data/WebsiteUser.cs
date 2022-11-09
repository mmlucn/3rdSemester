using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Website.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebsiteUser class
public class WebsiteUser : IdentityUser
{
    [ProtectedPersonalData]
    public string CPR { get; set; }
    [ProtectedPersonalData]
    public string DrivingLicenseNumber { get; set; }
}

