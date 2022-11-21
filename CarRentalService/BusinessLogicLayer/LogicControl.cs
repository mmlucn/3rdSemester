using CarRentalService.Dtos;
using CarRentalService.ModelConversion;
using ModelsDap.DB;
using ModelsDap.Models;
using System.Diagnostics;

namespace CarRentalService.BusinessLogicLayer
{
    public class LogicControl
    {
        private readonly CarDB _carDB;

        public LogicControl(CarDB inCarDB)
        {
            _carDB = inCarDB;
        }

        public List<CarReadDto> GetAllCars()
        {
            List<CarReadDto> publicCars = null;
            List<Car>? privateCars;
            try
            {
                privateCars = _carDB.GetCarsAsync();
                if (privateCars != null)
                {
                    publicCars = CarsConversion.FromCarsToReadDtos(privateCars);
                }

            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
                publicCars = null;

            }
            return publicCars;
        }
        public CarReadDto GetCarById(int id)
        {
            Car? privateCar;
            CarReadDto publicCar;
            try
            {
                privateCar = _carDB.GetCarByIdAsync(id);
                publicCar = CarsConversion.FromCarToReadDto(privateCar);
                
            }
            catch 
            {
                publicCar = null;
                
            }
            return publicCar;
        }
        public bool InsertCar(Car car)
        {
            bool wasInserted = false;
            try
            {
                if (car != null)
                {
                    Car privateCar = CarsConversion.FromReadDtoToCar(car);
                    wasInserted = _carDB.AddCarAsync(privateCar);
                }
            }
            catch (Exception)
            {
                wasInserted = false;
            }
            return wasInserted;
        }

        public bool UpdateCar(CarReadDto carReadDto)
        {
            bool wasUpdated;
            try
            {
                Car car =  CarsConversion.FromReadDtoToCar(carReadDto);
                wasUpdated = _carDB.UpdateCarAsync(car);
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
                wasUpdated = false;
            }

            return wasUpdated;
        }
        public bool DeleteCar(int delId)
        {
            bool wasDeleted;
            try
            {
                wasDeleted = _carDB.DeleteCarAsync(delId);
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
                wasDeleted = false;
            }

            return wasDeleted;
        }


    }
}
