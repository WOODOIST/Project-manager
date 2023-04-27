using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Interfaces;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Controllers
{
    [HiddenInput]
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllerRepo : Controller
    {
        private readonly IUserRepository _userRepository;
        
        public UserControllerRepo(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users =  _userRepository.GetUsers();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok( users);
        }
    }
}
