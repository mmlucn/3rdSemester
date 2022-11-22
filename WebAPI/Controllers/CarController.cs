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
        public ActionResult<Car> GetCarById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult AddCar()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteCar()
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCar(Car car)
        {
            return Ok();
        }
    }
}
