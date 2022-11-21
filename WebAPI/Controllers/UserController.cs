using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsDap.Models.DTOS;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public CustomerDTO GetCustomer(string email)
        {

            return null;
        }
    }
}
