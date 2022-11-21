using Microsoft.Build.Framework;
using ModelsDap.Models.Enums;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebApplication1.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }
        [Range(1900,2023,ErrorMessage = "Please specify the cars model year")]
        public String Year { get; set; }
        public double Mileage { get; set; }
        public CarType Type { get; set; }
        public FuelType FuelType { get; set; }
        public int Doors { get; set; }
    
        public double? FuelConsumption { get; set; }
        public double? ElectricityConsumption { get; set; }
        public int? HK { get; set; }
        public GearType GearType { get; set; }
        [Required]
        
        [Range(7,7,ErrorMessage ="Registration number must be precisely 7 characters.(2 letters and 5 numbers).")]
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public List<ModelsDap.Models.CarImages> Pictures { get; set; }
    }
}
