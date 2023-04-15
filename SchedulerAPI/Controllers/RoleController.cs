using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Models;

namespace SchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly SchedulerContext _context;

        public RoleController(SchedulerContext context)
        {
            _context = context;
        }


        //GET запросы
        [HttpGet("~/GetOneRole")]

        
        public async Task<ActionResult<List<Role>>> GetOneRole(int roleId)
        {
            return Ok(await _context.Roles.Where
                (p => p.Roleid == roleId).ToListAsync());

            
        }

        [HttpGet("~/GetRoles")]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            return Ok(await _context.Roles.
                ToListAsync());
        }




        //POST Запросы
        [HttpPost("~/PostRole")]

        public async Task<ActionResult<List<Role>>> CreateOneRole(Role role)
        {
            var newRole = new Role
            {
                Rolename = role.Rolename



            };

            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();


            return await GetOneRole(newRole.Roleid);


        }

        //DELETE запросы
        [HttpDelete("~/DeleteRole")]

        public async Task<ActionResult<List<Role>>> DeleteOneRole(Role request)
        {
            _context.Roles.Remove(request);
            await _context.SaveChangesAsync();

            return await GetOneRole(request.Roleid);
        }



        //PUT запросы
        [HttpPut("~/PutRole")]
        public async Task<ActionResult<List<Role>>> EditRole(Role request)
        {
            var role = await _context.Roles.FindAsync(request.Roleid);
            if (role == null)
                return BadRequest("Role not found! :(");
                
            role.Rolename = request.Rolename;
            await _context.SaveChangesAsync();
            return Ok(_context.Roles);
        }
    }
}
