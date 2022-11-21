using CarRentalService.BusinessLogicLayer;
using CarRentalService.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly LogicControl _logicControl;

        public CarsController(LogicControl logicControl)
        {
            _logicControl = logicControl;
        }



        // GET: api/<CarsController>
        [HttpGet, Route("cars")]
        public ActionResult<List<CarReadDto>> Get()
        {
            ActionResult<List<CarReadDto>>  foundReturn;

            List<CarReadDto>? publicCars = _logicControl.GetAllCars();
            if (publicCars?.Count > 0 )
            {
                foundReturn = Ok(publicCars);
            }
            else
            {
                foundReturn = NotFound();
            }

            return foundReturn;
        }

        // GET api/<CarsController>/5
        [HttpGet("cars/{id}")]
        public ActionResult<CarReadDto> Get(int id)
        {
            ActionResult<CarReadDto> foundReturn;

            CarReadDto? publicCar = _logicControl.GetCarById(id);
            if (publicCar != null)
            {
                if (publicCar.Id >= 0)
                {
                    foundReturn = Ok(publicCar);
                }
                else
                {
                    foundReturn = Ok();
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            // Return result
            return foundReturn;
        }

        // POST api/<CarsController>
        [HttpPost]
        public ActionResult PostNewCar(CarReadDto car)
        {
            ActionResult foundReturn;
            if (car.Id > 0)
            {
                bool wasOk = _logicControl.InsertCar(car);
                if (wasOk)
                {
                    foundReturn = Ok();
                }
                else
                {
                    foundReturn = new StatusCodeResult(500);    // Internal server error
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(400); ;      // Bad Request
            }
            return foundReturn;

        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
