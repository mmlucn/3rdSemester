using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsDap.DB;
using ModelsDap.Models;
using ModelsDap.Models.DTOS;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        private string _conString;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = _configuration.GetConnectionString("Hildur");
        }

        [HttpGet]
        public async Task<Customer> GetCustomer(string email)
        {
            CustomerDB customerDB = new(_conString);
            var foundCustomer = await customerDB.GetCustomerByEmailAsync(email);
            return foundCustomer;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateCustomer([FromBody] Customer customer)
        {
            CustomerDB customerDB = new(_conString);
            var result = await customerDB.AddCustomerAsync(customer);
            if (result)
                return Ok(result);
            return Problem("Error");
        }

        [HttpPost("UpdateProfilePicture")]
        public async Task<ActionResult<bool>> UpdateProfilePicture([FromBody] ProfilePictureDTO profilePictureDTO)
        {
            CustomerDB customerDB = new(_conString);
            var result = await customerDB.UpdateProfilePictureAsync(profilePictureDTO);
            if (result)
                return Ok();
            return Problem("Error");
        }
    }
}
