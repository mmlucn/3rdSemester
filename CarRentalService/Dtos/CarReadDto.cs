using ModelsDap.Models;
using ModelsDap.Models.Enums;

namespace CarRentalService.Dtos
{
    public class CarReadDto
    {
        public int Id { get; set; }
        public Customer Owner { get; set; }
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
        public List<CarImages> Pictures { get; set; }

    }

}
