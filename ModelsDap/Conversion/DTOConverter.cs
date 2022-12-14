using CarRentalLibrary.Models.DTOS;
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
                DateOfBirth = customerDTO.DateOfBirth,
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

        public static CarImage CarImageDtoToCarImage(CarImageDTO carImageDTO)
        {
            return new CarImage()
            {
                Id = carImageDTO.Id,
                Image = Convert.FromBase64String(carImageDTO.ImageAsBase64),
                CarId = carImageDTO.CarId
            };
        }
    }
}
