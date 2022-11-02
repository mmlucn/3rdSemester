using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public class Rental
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Customer Owner { get; set; }
        public Customer Loaner { get; set; }
        public TimeSpan RentalPeriod { get; set; }
    }
}
