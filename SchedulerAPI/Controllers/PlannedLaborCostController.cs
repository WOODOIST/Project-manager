using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlannedLaborCostController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;

        public PlannedLaborCostController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //GET запросы
        [HttpGet("~/GetAllPlannedLaborCosts")]
        public async Task<IActionResult> GetAllPlannedLaborCosts()
        {
            




            var allPlAsyns = await _context.Plannedlaborcosts.ToListAsync();

            var allPl = allPlAsyns.Select(pd =>
            _mapper.Map<PlLaborCostDto>(pd));
            var _pl = _mapper.Map<IEnumerable<PlLaborCostDto>>(allPl);

            return Ok(_pl);



        }

        [HttpGet("~/GetAllPlannedLaborCostsWithId")]
        public async Task<ActionResult<PlLaborCostDto>> GetAllPlannedLaborCostsWithId()
        {
            var allPlAsync = await _context.Plannedlaborcosts
                .Include(p=>p.Fact)
                .Include(p=>p.Project)
                .Include(p=>p.User)
                .Include(p=>p.Laborcost)
                .Include(p=>p.Scenario)
                .ToListAsync();



            return Ok(allPlAsync);



        }

        [HttpGet("~/GetOnePlannedLaborCost")]
        public async Task<ActionResult<PlLaborCostDto>> GetOnePostDynamic(int id)
        {

            var pl = await _context.Plannedlaborcosts
                .Include(p => p.Fact)
                .Include(p => p.Project)
                .Include(p => p.User)
                .Include(p => p.Laborcost)
                .Include(p => p.Scenario)
                .FirstOrDefaultAsync(p=>p.Plannedlaborcostid == id);


            if (pl == null)
                return BadRequest("Запланированная трз не обнаружена.Убедитесь в правильности id.");

            return Ok(pl);

        }

        //POST запросы
        [HttpPost("~/AddPlannedLaborCost")]
        public async Task<IActionResult> AddPlannedLaborCost(PlLaborCostForCreationDto data)
        {
            var _data = _mapper.Map<Plannedlaborcost>(data);

            try
            {
                await _context.Plannedlaborcosts.AddAsync(_data);
                await _context.SaveChangesAsync();
                return new JsonResult($"  Запланированная трз добавлено успешно!. Её id  = {_data.Plannedlaborcostid}  ");
            }
            catch
            {
                return new JsonResult("Что-то пошло не так.")
                { StatusCode = 500 };
            }
        }


        //DELETE запросы
        [HttpDelete("~/DeletePlannedLaborCost")]

        public async Task<IActionResult> DeletePlannedLaborCost(int id)
        {
            var plaborcost = await _context.Plannedlaborcosts.FirstOrDefaultAsync
                (p => p.Plannedlaborcostid == id);

            if (plaborcost == null)
                return BadRequest("Запланированной трз с таким id не существует.");

            _context.Plannedlaborcosts.Remove(plaborcost);
            await _context.SaveChangesAsync();

            return BadRequest($"Запланированная трз с id = {plaborcost.Plannedlaborcostid}   удален(а)!");
        }


        //PUT запросы
        [HttpPatch("~/EditPlannedLaborCost")]
        public async Task<IActionResult> EditPlannedLaborCost(int plid,int scenarioid, int laborcostid, 
            int factid, decimal plpercent, DateOnly pldate, int projectid, int userid)
        {

            var pl = await _context.Plannedlaborcosts.FirstOrDefaultAsync(p => p.Plannedlaborcostid == plid);

            if (pl == null)
                return BadRequest("Указанного id не существует!");

            pl.Scenarioid = scenarioid;
            pl.Plannedlaborcostid = laborcostid;
            pl.Factid = factid;
            pl.Plannedlaborcostpercent = plpercent;
            pl.Plannedlaborcostfilldate = pldate;
            pl.Projectid = projectid;
            pl.Userid = userid;

            await _context.SaveChangesAsync();
            return Ok(pl);

        }
    }
}
