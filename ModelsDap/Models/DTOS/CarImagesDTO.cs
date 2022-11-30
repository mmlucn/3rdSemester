using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary.Models.DTOS
{
    public class CarImagesDTO
    {
        public int CarId { get; set; }
        public string[]? ImageAsByte64 { get; set; }
    }
}
