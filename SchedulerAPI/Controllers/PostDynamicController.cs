using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostDynamicController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;

        public PostDynamicController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //GET запросы
        [HttpGet("~/GetAllPostsDynamic")]
        public async Task<IActionResult> GetAllPostsDynamic()
        {
            //var _postdynamics = await _context.PostDynamics
            //    .Include(p => p.User)
            //    .Include(p => p.Post)
            //    .ToListAsync();





            var allPostsAsyns = await _context.PostDynamics.ToListAsync();

            var allPosts = allPostsAsyns.Select(pd =>
            _mapper.Map<PostDynamicDto>(pd));
            var _pd = _mapper.Map<IEnumerable<PostDynamicDto>>(allPosts);

            return Ok(_pd);



        }

        [HttpGet("~/GetAllPostDynamicsWithId")]
        public async Task<IActionResult> GetAllPostDynamicsWithId()
        {
            var allPDAsync = await _context.PostDynamics.
                ToListAsync();



            return Ok(allPDAsync);



        }

        [HttpGet("~/GetOnePostDynamic")]
        public async Task<IActionResult> GetOnePostDynamic(int postdynamicid)
        {

            var pd = await _context.PostDynamics.FindAsync(postdynamicid);

            if (pd == null)
                return BadRequest("Некорректный id. Убедитесь, что id корректный.");

            return Ok(pd);

        }

        //POST запросы
        [HttpPost("~/AddPostDynamic")]
        public async Task<IActionResult> AddPostDynamic(PostDynamicForCreationDto data)
        {
            var _data = _mapper.Map<PostDynamic>(data);

            try
            {
                await _context.PostDynamics.AddAsync(_data);
                await _context.SaveChangesAsync();
                return new JsonResult($"  Изменение должности добавлено успешно!. Его id  = {_data.Postdynamicid}  ");
            }
            catch
            {
                return new JsonResult("Что-то пошло не так.")
                { StatusCode = 500 };
            }
        }


        //DELETE запросы
        [HttpDelete("~/DeletePostDynamic")]

        public async Task<IActionResult> DeletePostDynamic(int pd_id)
        {
            var pd = await _context.PostDynamics.FirstOrDefaultAsync
                (p => p.Postdynamicid ==  pd_id);

            if (pd == null)
                return BadRequest("Изменения должности с таким id не существует.");

            _context.PostDynamics.Remove(pd);
            await _context.SaveChangesAsync();

            return BadRequest($"Изменение должности с id = {pd.Postdynamicid}   удален(а)!");
        }


        //PUT запросы
        [HttpPatch("~/EditPostDynamic")]
        public async Task<IActionResult> EditPostDynamic(int pd_id, DateOnly new_pd_date, int new_post, int new_user)
        {
            var pd = await _context.PostDynamics.FirstOrDefaultAsync(p => p.Postdynamicid == pd_id);

            if (pd == null)
                return BadRequest("Указанного id не существует!");

            pd.Postdynamicstartdate = new_pd_date;
            pd.Postid = new_post;
            pd.Userid = new_user;

            await _context.SaveChangesAsync();
            return Ok(pd);
        }
    }
}
