using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsDap.DB;
using ModelsDap.Models;

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
            var foundCustomer = await customerDB.GetCustomerByEmail(email);
            return foundCustomer;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateCustomer([FromBody] Customer customer)
        {
            CustomerDB customerDB = new(_conString);

            return true;
        }
    }
}
