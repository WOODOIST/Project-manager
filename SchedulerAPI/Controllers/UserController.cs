using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Models;

namespace SchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SchedulerContext _context;

        public UserController(SchedulerContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _context.Users.
                Include(p=>p.Role).ToListAsync());
                
        }

    }
}
