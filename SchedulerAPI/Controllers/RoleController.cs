using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace SchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RoleController : ControllerBase
    {


        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;

        



        public RoleController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        //GET запросы
        [HttpGet("~/GetOneRole")]

        public async Task<IActionResult> GetOneRole(string rolename)
        {

            var role = await _context.Roles.FirstOrDefaultAsync(p=>p.Rolename == rolename);
            if (role == null)
                return BadRequest("Указанной роли не существует");
            return Ok(role);
        }


        //Применён автомаппер, чтобы не показывать id у ролей 
        [HttpGet("~/GetRolesWithoutId")]
        public    ActionResult<List<Role>>  GetRolesWithoutId()
        {
            var allRoles = _context.Roles.Select(role => _mapper.Map<RoleDto>(role));
            var _roles = _mapper.Map<IEnumerable<RoleDto>>(allRoles);

            return Ok(_roles); 
        }


        [HttpGet("~/GetRolesWithId")]
        public async Task<IActionResult> GetRolesWithId()
        {
            return Ok(await _context.Roles.
                ToListAsync());
        }




        //POST Запросы
        [HttpPost("~/PostRole")]

        public async  Task<IActionResult> CreateOneRole(RoleForCreationDto data)
        {
                var _role =  _mapper.Map<Role>(data);    


                try
                {
                  await _context.Roles.AddAsync(_role);
                  await  _context.SaveChangesAsync(); 
                  return  CreatedAtAction("GetOneRole", routeValues: new { _role.Roleid }, value: _role);
                }
                catch
                {
                return  new JsonResult("Что-то пошло не так. Возможно, вы ввели уже существующую роль") { StatusCode = 500 } ;
                }

        }



        //DELETE запросы
        [HttpDelete("~/DeleteRole")]

        public async Task<IActionResult> DeleteRole(string rolename)
        {
            var role = await _context.Roles.FirstOrDefaultAsync
                (p => p.Rolename == rolename);

            if (role == null)
                return BadRequest("Введённой роли не существует.");

             _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return BadRequest($"Роль {role.Rolename} удалена!");
        }



        //PUT запросы
        [HttpPatch("~/EditRole")]

        public async Task<ActionResult> EditRole(string oldrolename, string newrolename)
        {
            var role = _context.Roles.FirstOrDefault(p => p.Rolename == oldrolename);
            if (role == null)
                return BadRequest("Указанной роли не существует.");

            role.Rolename = newrolename;

            await _context.SaveChangesAsync();
            return Ok(role);
        }
    }
}
