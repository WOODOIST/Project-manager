using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace SchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;

        public UserController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET запросы
        [HttpGet("~/GetAllUsers")]
        public async  Task<IActionResult> GetUsers()
        {
            var allUsersAsync = await _context.Users.Include(i=>i.Role).ToListAsync();

            var allUsers = allUsersAsync.Select(user =>
            _mapper.Map<UserDto>(user));
            var _users = _mapper.Map<IEnumerable<UserDto>>(allUsers);

            return Ok(_users);



        }

    }
}
