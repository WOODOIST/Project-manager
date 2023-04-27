using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;





        public ProjectController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        //GET запросы
        [HttpGet("~/GetProjectByName")]

        public async Task<IActionResult> GetProjectByName(string projectname)
        {

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Projectname == projectname);
            if (project == null)
                return BadRequest("Указанного проекта не существует");
            return Ok(project);
        }


        [HttpGet("~/GetProjectsWithoutId")]
        public async Task<IActionResult> GetProjectsWithoutId()
        {
            var projectsNoMap = await _context.Projects.ToListAsync();
            var projectsMap = projectsNoMap.Select(project =>
            _mapper.Map<ProjectDto>(project));
            var _projects = _mapper.Map<IEnumerable<ProjectDto>>(projectsMap);

            return Ok(_projects);
        }


        [HttpGet("~/GetProjectsWithId")]
        public async Task<IActionResult> GetProjectsWithId()
        {
            return Ok(await _context.Projects.
                ToListAsync());
        }




        //POST Запросы
        [HttpPost("~/PostProject")]

        public async Task<IActionResult> PostProject(ProjectForCreationDto data)
        {
            var _project = _mapper.Map<Project>(data);


            try
            {
                await _context.Projects.AddAsync(_project);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProjectByName", routeValues: new { _project.Projectname }, value: _project);
            }
            catch
            {
                return new JsonResult("Что-то пошло не так. Возможно, вы ввели уже существующий проект.")
                { StatusCode = 500 };
            }

        }



        //DELETE запросы
        [HttpDelete("~/DeleteProject")]

        public async Task<IActionResult> DeleteProject(string name)
        {
            var project = await _context.Projects.FirstOrDefaultAsync
                (p => p.Projectname == name);

            if (project == null)
                return BadRequest("Введённого проекта не существует.");

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return BadRequest($"Проект под названием -  {project.Projectname} -  был  удалён!");
        }



        //PUT запросы  Пример даты - yyyy.mm.dd
        [HttpPatch("~/EditProject")]

        public async Task<IActionResult> EditRole(string oldprojectname, string newprojectname, DateOnly newfinishdate)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Projectname == oldprojectname);
            if (project == null)
                return BadRequest("Указанного проекта не существует.");

            project.Projectname = newprojectname;
            project.Projectfinishdate = newfinishdate;

            await _context.SaveChangesAsync();
            return Ok(project);
        }
    }
}
