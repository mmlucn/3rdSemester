using ModelsDap.Models;
using ModelsDap.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.Conversion
{
    public static class DTOConverter
    {
        public static Customer CustomerDTOToCustomer(CustomerDTO customerDTO)
        {
            return new Customer()
            {
                Address = customerDTO.Address,
                CPR = null,
                DateOfBirth = customerDTO.DateOfBirth,
                DrivingLicenseNumber = customerDTO.DrivingLicenseNumber,
                EMail = customerDTO.EMail,
                Firstname = customerDTO.Firstname,
                Lastname = customerDTO.Lastname,
                Id = customerDTO.Id
            };
        }

        public static Customer CustomerToCustomerDTO(Customer customer)
        {
            return new Customer()
            {
                
            };
        }
    }
}
