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
    public class PostController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;





        public PostController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        //GET запросы
        [HttpGet("~/GetPostByName")]

        public async Task<IActionResult> GetPostByName(string name)
        {

            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Postname == name);
            if (post == null)
                return BadRequest("Указанной должности не существует!");
            return Ok(post);
        }


        [HttpGet("~/GetPostsWithoutId")]
        public async Task<IActionResult> GetPostsWithoutId()
        {
            var postsNoMap = await _context.Posts.ToListAsync();
            var postsMap = postsNoMap.Select(post =>
            _mapper.Map<PostDto>(post));
            var _posts = _mapper.Map<IEnumerable<PostDto>>(postsMap);

            return Ok(_posts);
        }


        [HttpGet("~/GetPostsWithId")]
        public async Task<IActionResult> GetPostsWithId()
        {
            return Ok(await _context.Posts.
                ToListAsync());
        }




        //POST Запросы
        [HttpPost("~/AddPost")]

        public async Task<IActionResult> AddPost(PostForCreationDto data)
        {
            var _post = _mapper.Map<Post>(data);


            try
            {
                await _context.Posts.AddAsync(_post);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPostByName", routeValues: new { _post.Postname }, value: _post);
            }
            catch
            {
                return new JsonResult("Что-то пошло не так. Возможно, вы ввели уже существующую должность.")
                { StatusCode = 500 };
            }

        }



        //DELETE запросы
        [HttpDelete("~/DeletePost")]

        public async Task<IActionResult> DeletePost(string name)
        {
            var post = await _context.Posts.FirstOrDefaultAsync
                (p => p.Postname == name);

            if (post == null)
                return BadRequest("Введённой должности не существует.");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return BadRequest($"Должность  -  {post.Postname}  -  была  удалена!");
        }



        //PUT запросы  
        [HttpPatch("~/EditPost")]

        public async Task<IActionResult> EditPost(string oldname, string newname)
        {
            var _post = await _context.Posts.ToListAsync();
            var editing_post =  _post.FirstOrDefault(p => p.Postname == oldname);
            if (editing_post == null)
                return BadRequest("Указанной должности не существует.");

            editing_post.Postname = newname;

            await _context.SaveChangesAsync();
            return Ok(editing_post);
        }
    }
}
