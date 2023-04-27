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
    public class ScenarioController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;





        public ScenarioController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        //GET запросы
        [HttpGet("~/GetScenarioByName")]

        public async Task<IActionResult> GetScenarioByName(string scenario_name)
        {

            var scenario = await _context.Scenarios.FirstOrDefaultAsync(p => p.Scenarioname == scenario_name);

            if (scenario == null)
                return BadRequest("Указанного сценария не существует");

            return Ok(scenario);
        }


        [HttpGet("~/GetScenariosWithoutId")]
        public async Task<IActionResult> GetScenariosWithoutId()
        {
            var allScenariosAsync =  await _context.Scenarios.ToListAsync();
            var allScenarios = allScenariosAsync.Select(p =>
            _mapper.Map<ScenarioDto>(p));
            var _scnrs = _mapper.Map<IEnumerable<ScenarioDto>>(allScenarios);

            return Ok(_scnrs);
        }


        [HttpGet("~/GetScenariosWithId")]
        public async Task<IActionResult> GetScenariosWithId()
        {
            return Ok(await _context.Scenarios.
                ToListAsync());
        }




        //POST Запросы
        [HttpPost("~/PostScenario")]

        public async Task<IActionResult> PostScenario(ScenarioForCreationDto data)
        {
            var _scenario = _mapper.Map<Scenario>(data);


            try
            {
                await _context.Scenarios.AddAsync(_scenario);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetScenarioByName", routeValues: new { _scenario.Scenarioname }, value: _scenario);
            }
            catch
            {
                return new JsonResult("Что-то пошло не так. Возможно, " +
                    "вы ввели уже существующий сценарий")
                { StatusCode = 500 };
            }

        }



        //DELETE запросы
        [HttpDelete("~/DeleteScenario")]

        public async Task<IActionResult> DeleteScenario(string scenario_name)
        {
            var scenario = await _context.Scenarios.FirstOrDefaultAsync
                (p => p.Scenarioname == scenario_name);

            if (scenario == null)
                return BadRequest("Введённого сценария не существует.");

            _context.Scenarios.Remove(scenario);
            await _context.SaveChangesAsync();

            return BadRequest($"Сценарий - {  scenario.Scenarioname} - удален(а)!");
        }



        //PUT запросы
        [HttpPatch("~/EditScenario")]

        public async Task<IActionResult> EditScenario(string oldname, string newname)
        {
            var scenario = await _context.Scenarios.FirstOrDefaultAsync(p => p.Scenarioname == oldname);
            if (scenario == null)
                return BadRequest("Указанного сценария не существует.");

            scenario.Scenarioname = newname;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(scenario);
            }
            catch
            {
                return BadRequest("Что-то пошло не так. Возможно, вы ввели уже существующий сценарий!");
            }

            
        }
    }
}
