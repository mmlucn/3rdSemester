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

        
        [HttpGet("GetRentalById/{id}")]
        public async Task<ActionResult<Rental>> GetRentalById(int id)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.GetRentalByIdAsync(id);
            if (res.Id > 0)
            {
                return Ok(res);
            }
            return Problem("Error");
        }

        
        [HttpGet("GetAllOwnerRentals/{ownerid}")]
        [ProducesResponseType(typeof(List<Rental>), 200)]
        public async Task<ActionResult<List<Rental>>> GetAllOwnerRentals(int ownerid)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.GetAllOwnersRentalsAsync(ownerid);
            if (res.Count > 0)
                return Ok(res);
            

            return Problem("Error");
        }

        [HttpGet("GetAllCarsRentals/{carId}")]
        [ProducesResponseType(typeof(List<Rental>), 200)]
        public async Task<ActionResult<List<Rental>>> GetAllCarsRentals(int carId)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.GetAllCarsRentalsAsync(carId);
            if (res.Count > 0) 
                return Ok(res);


            return Problem("Error");
        }
        [HttpGet("GetAllLoanerRentals/{loanerId}")]
        [ProducesResponseType(typeof(List<Rental>), 200)]
        public async Task<ActionResult<List<Rental>>> GetAllLoanerRentals(int loanerId)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.GetAllLoanersRentalsAsync(loanerId);
            if (res.Count > 0)
                return Ok(res);


            return Problem("Error");
        }

        
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

        
        [HttpPost("UpdateRental")]
        public async Task<ActionResult<int>> UpdateRental([FromBody] Rental rental)
        {
            RentalDB rDB = new RentalDB(_conString);
            var res = await rDB.UpdateRentalAsync(rental);
            return Ok(res);
        }

        
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
