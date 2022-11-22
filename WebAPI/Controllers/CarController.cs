using Microsoft.AspNetCore.Mvc;
using ModelsDap.Models;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{
    public class CarController : ControllerBase
    {
        IConfiguration _Configuration;


        public CarController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        [HttpGet("/GetCars")]
        [ProducesResponseType(typeof(List<Car>), 200)]
        public async Task<ActionResult> GetAllCars()
        {
            ModelsDap.DB.CarDB carDB = new ModelsDap.DB.CarDB(_Configuration.GetConnectionString("Hildur"));
            var res = await carDB.GetCarsAsync();
            if (res.Count > 0)
                return Ok(res);

            return Problem("Error");
        }

        [HttpGet("/GetCar/{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            ModelsDap.DB.CarDB carDB = new ModelsDap.DB.CarDB(_Configuration.GetConnectionString("Hildur"));
            var res = await carDB.GetCarByIdAsync(id);
            if (res.Id > 0)
            {
                return Ok(res);
            }
            return Problem("Error");
        }

        [HttpPost("/AddCar")]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            ModelsDap.DB.CarDB carDB = new ModelsDap.DB.CarDB(_Configuration.GetConnectionString("Hildur"));
            var res = await carDB.AddCarAsync(car);
            

            return CreatedAtAction(nameof(GetCarById), new {id = car.Id}, car);
        }

        [HttpDelete("/DeleteCar/{id}")]
        public async Task<ActionResult<int>> DeleteCar(int id)
        {
            ModelsDap.DB.CarDB carDB = new ModelsDap.DB.CarDB(_Configuration.GetConnectionString("Hildur"));
            var res = await carDB.DeleteCarAsync(id);
            if (id == null)
            {
                return NotFound();

            }
            return Ok();
        }

        [HttpPut("/PutCar/{id}")]
        public async Task<ActionResult<int>> UpdateCar(Car car)
        {
            
            ModelsDap.DB.CarDB carDB = new ModelsDap.DB.CarDB(_Configuration.GetConnectionString("Hildur"));
            var res = await carDB.UpdateCarAsync(car);


            return Ok(res);
        }
    }
}
