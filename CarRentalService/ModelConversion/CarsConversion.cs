using CarRentalService.Dtos;
using ModelsDap.Models;

namespace CarRentalService.ModelConversion
{
    public class CarsConversion
    {
        public static CarReadDto? FromCarToReadDto(Car? car)
        {
            CarReadDto? foundCar = null;
            if (car != null)
            {
                foundCar = GetCarReadDto(car);
            }
            return foundCar;
        }

        public static List<CarReadDto> FromCarsToReadDtos(List<Car> cars)
        {
            List<CarReadDto> foundCars = new List<CarReadDto>();
            CarReadDto? tempDtoCar;
            foreach (Car car in cars)
            {
                tempDtoCar = GetCarReadDto(car);
                if (tempDtoCar != null)
                {
                    foundCars.Add(tempDtoCar);
                }
            }
            return foundCars;
        }
        

        private static CarReadDto? GetCarReadDto(Car car)
        {
            throw new NotImplementedException();
        }

        internal static Car FromReadDtoToCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
