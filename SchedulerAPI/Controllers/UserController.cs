using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.DtoObjects.Incoming;
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

        [HttpGet("~/GetAllUsersWithId")]
        public async Task<IActionResult> GetUsersWithId()
        {
            var allUsersAsync = await _context.Users.Include(i => i.Role).ToListAsync();

           

            return Ok(allUsersAsync);



        }

        [HttpGet("~/GetOneUser")]
        public async Task<UserDto> GetOneUser(int userId) 
        {
            var allUsersAsync = await _context.Users.Include(i => i.Role).ToListAsync();

           
            var user = await _context.Users.FindAsync(userId);
            return _mapper.Map<UserDto>(user);

            //var userNoMap = await _context.Users.FirstOrDefaultAsync(p => p.Usersurname == usersurname 
            //&& p.Username == username);


            //if (userNoMap == null)
            //    return BadRequest("Указанного пользователя не существует.");
           

            //return (IActionResult)_mapper.Map<UserDto>(userNoMap);
        }

        //POST запросы
        [HttpPost("~/AddUser")]
        public async Task<IActionResult> CreateUser(UserForCreationDto user)
        {
            var _user  = _mapper.Map<User>(user);

            try
            {
                await _context.Users.AddAsync(_user);
                await _context.SaveChangesAsync();
                return new JsonResult($"Пользователь добавлен успешно!. Его id  = {_user.Userid}  ");
            }
            catch
            {
                return new JsonResult("Что-то пошло не так.Возможно, " +
                    "пользователь с такими данными уже существует") { StatusCode = 500 };
            }
        }


        //DELETE запросы
        [HttpDelete("~/DeleteUser")]

        public async Task<IActionResult> DeleteUser(string usersurname,string username, string userpatronymic)
        {
            var user = await _context.Users.FirstOrDefaultAsync
                (p => p.Username == username && p.Usersurname == usersurname && 
                p.Userpatronymic == userpatronymic);

            if (user == null)
                return BadRequest("Введённой роли не существует.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return BadRequest($"Пользователь:  {user.Usersurname}  {user.Username}  {user.Userpatronymic} удален(а)!");
        }


        //PUT запросы
        [HttpPatch("~/EditUser")]
        public async Task<IActionResult> EditUser(string oldsurname, 
            string oldname, string oldpatronymic, string oldemail, string newsurname,
            string newname, string newpatronymic, string newemail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p=>p.Usersurname == oldsurname &&
            p.Username == oldname && p.Userpatronymic ==  oldpatronymic && p.Useremail == oldemail);

            if (user == null)
                return BadRequest("Указанного пользователя не существует");

            user.Usersurname = newsurname;
            user.Username = newname;
            user.Userpatronymic = newpatronymic;
            user.Useremail = newemail;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

    }
}
