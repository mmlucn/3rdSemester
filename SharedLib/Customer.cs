using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string CPR { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DriverLicenseNr { get; set; }

    }
}
