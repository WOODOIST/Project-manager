using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagerAPI.DtoObjects;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SchedulerContext _context = new SchedulerContext();
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public AuthenticationController(SchedulerContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("PostLoginDetails")]

        public async Task<IActionResult> PostLoginDetails(AuthUserDto _userData)
        {
            
            var _authUser = _mapper.Map<User>(_userData);
            if (_userData != null)
            {
                var resultLoginCheck = await  _context.Users.Where(
                    p => p.Userlogin == _userData.Login && 
                    p.Userpassword == _userData.Password ).FirstOrDefaultAsync();

                if (resultLoginCheck == null)
                {
                    return BadRequest("Пользователь не обнаружен!");
                }
                else
                {
                    _userData.UserMessage = "Данные верны.";
                    //var claims = new[]
                    //{

                    //    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    //    new Claim("AccessToken", _userModel.AccessToken),
                    //    new Claim("UserMessage", _userModel.UserMessage),
                    //    new Claim("Email", _userData.Useremail)

                    //};

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        //claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    
                    return Ok(_userData);
                }
            }
            else
            {
                return BadRequest("Данные отсутствуют");
            }

            
        }

        
    }
}
