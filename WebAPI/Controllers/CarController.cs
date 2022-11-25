using Microsoft.AspNetCore.Mvc;
using ModelsDap.DB;
using ModelsDap.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        IConfiguration _Configuration;
        private string _conString;


        public CarController(IConfiguration configuration)
        {
            _Configuration = configuration;
            _conString = _Configuration.GetConnectionString("Hildur");
        }

        [HttpGet]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.GetCarByIdAsync(id);
            if (res.Id > 0)
            {
                return Ok(res);
            }
            return Problem("Error");
        }

        [HttpGet("GetAllCars")]
        [ProducesResponseType(typeof(List<Car>), 200)]
        public async Task<ActionResult> GetAllCars()
        {
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.GetCarsAsync();
            if (res.Count > 0)
                return Ok(res);

            return Problem("Error");
        }

        [HttpGet("GetAllUsersCars/{ownerId}")]
        [ProducesResponseType(typeof(List<Car>), 200)]
        public async Task<ActionResult<List<Car>>> GetAllUsersCars(int ownerId)
        {
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.GetAllCustomerCarsAsync(ownerId);
            if (res.Count > 0)
                return Ok(res);

            return Problem("Error");
        }



        [HttpPost("AddCar")]
        public async Task<ActionResult<bool>> AddCar([FromBody] Car car)
        {
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.AddCarAsync(car);
            if (res)
                return Ok(res);
            return Problem("Error");
        }

        [HttpDelete("DeleteCar/{id}")]
        public async Task<ActionResult<int>> DeleteCar(int id)
        {
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.DeleteCarAsync(id);
            if (id == null)
            {
                return NotFound();

            }
            return Ok();
        }

        [HttpPut("PutCar/{id}")]
        public async Task<ActionResult<int>> UpdateCar(Car car)
        {
            
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.UpdateCarAsync(car);


            return Ok(res);
        }
    }
}
