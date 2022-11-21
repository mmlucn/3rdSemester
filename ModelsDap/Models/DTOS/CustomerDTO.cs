using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.Models.DTOS
{
    public class CustomerDTO
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DrivingLicenseNumber { get; set; }
    }
}
