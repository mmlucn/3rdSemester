using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("carId")]
        public int? CarId { get; set; }
        [ForeignKey("ownerId")]
        public int? OwnerId { get; set; }
        [ForeignKey("loanerId")]
        public int? LoanerId { get; set; }
        public TimeSpan RentalPeriod { get; set; }
    }
}
