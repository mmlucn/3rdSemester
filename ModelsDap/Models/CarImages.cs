using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.Models
{
    public class CarImages
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int CarId { get; set; }
        public string[]? ImageAsByte64 { get; set; }
    }
}
