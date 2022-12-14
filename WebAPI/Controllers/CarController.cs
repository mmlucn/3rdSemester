using CarRentalLibrary.Models.DTOS;
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

        [HttpGet("GetCarById/{id}")]
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
            return Ok(res);
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
        public async Task<ActionResult<int>> AddCar([FromBody] Car car)
        {
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.AddCarAsync(car);
            return Ok(res);
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

        [HttpPost("UpdateCar")]
        public async Task<ActionResult<int>> UpdateCar([FromBody] Car car)
        {
            CarDB carDB = new CarDB(_conString);
            var res = await carDB.UpdateCarAsync(car);
            return Ok(res);
        }

        [HttpGet("GetPicturesByCarId/{carId}")]
        public async Task<IActionResult> GetPicturesByCarId(int carId)
        {
            var carDb = new CarDB(_conString);
            var res = await carDb.GetPictures(carId);
            if (res != null)
            {
                return Ok(res);
            }
            else return NotFound();
        }

        

        [HttpPost("UploadCarImages")]
        public async Task<IActionResult> UploadCarImages(CarImagesDTO carImagesDTO)
        {
            var carDb = new CarDB(_conString);
            var res = await carDb.UploadCarImages(carImagesDTO);
            if (res)
                return Ok();
            else
                return Problem("Couldn't upload the image(s)");
        }
    }
}
