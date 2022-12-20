using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.DTOS
{
    public class CarImageDTO
    {
        public int? Id { get; set; }
        public string? ImageAsBase64 { get; set; }
        public int CarId { get; set; }
    }
}
