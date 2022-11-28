using ModelsDap.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ModelsDap.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int? OwnerID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public double Mileage { get; set; }
        public CarType Type { get; set; }
        public FuelType FuelType { get; set; }
        public int Doors { get; set; }
        public double? FuelConsumption { get; set; }
        public double? ElectricityConsumption { get; set; }
        public int? HK { get; set; }
        public GearType GearType { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        //List of car images, as Base64
        public List<string>? Pictures { get; set; }
    }
}