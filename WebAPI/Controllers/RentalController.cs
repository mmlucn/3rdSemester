using Microsoft.AspNetCore.Mvc;
using ModelsDap.DB;
using ModelsDap.Models;



namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {

        IConfiguration _Configuration;
        private string _conString;


        public RentalController(IConfiguration configuration)
        {
            _Configuration = configuration;
            _conString = _Configuration.GetConnectionString("Hildur");
        }

        // GET: api/<RentalController>
        [HttpGet]
        public async Task<ActionResult<Rental>> GetCarById(int id)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.GetRentalByIdAsync(id);
            if (res.Id > 0)
            {
                return Ok(res);
            }
            return Problem("Error");
        }

        // get api/<rentalcontroller>/5
        [HttpGet("GetAllUserRentals/{ownerid}")]
        [ProducesResponseType(typeof(List<Rental>), 200)]
        public async Task<ActionResult<List<Rental>>> GetAllRentals(int ownerid)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.GetAllRentalsAsync(ownerid);
            if (res.Count > 0)
                return Ok(res);
            

            return Problem("Error");
        }

        // POST api/<RentalController>
        [HttpPost("AddRental")]
        public async Task<ActionResult<bool>> AddRental([FromBody] Rental rental)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.AddRentalAsync(rental);
            if (res)
            {
                return Ok(res);
            }
            return Problem("Error");
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RentalController>/5
        [HttpDelete("DeleteRental/{id}")]
        public async Task<ActionResult<int>> DeleteRental(int id)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.DeleteRentalAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            else
                return Ok();

        }
    }
}
