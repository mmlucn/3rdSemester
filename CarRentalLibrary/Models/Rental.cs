using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime RentalStartPeriod { get; set; }
        public DateTime RentalEndPeriod { get; set; }
    }
}
