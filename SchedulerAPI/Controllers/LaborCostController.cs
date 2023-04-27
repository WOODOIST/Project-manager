using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaborCostController : ControllerBase
    {

        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;





        public LaborCostController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        //GET запросы
        [HttpGet("~/GetLaborCostByName")]

        public async Task<IActionResult> GetOneLaborCost(string laborcostname)
        {

            var laborcost = await _context.Laborcosts.FirstOrDefaultAsync(p => p.Laborcostname == laborcostname);
            if (laborcost == null)
                return BadRequest("Указанной трз не существует");
            return Ok(laborcost);
        }


        [HttpGet("~/GetLaborCostWithoutId")]
        public  async Task<IActionResult> GetLaborCostWithoutId()
        {
            var LbrCostsNoMap = await _context.Laborcosts.ToListAsync();
            var LbrCostsMap = LbrCostsNoMap.Select(lbrcost =>
            _mapper.Map<LaborCostDto>(lbrcost));
            var _lbrcosts = _mapper.Map<IEnumerable<LaborCostDto>>(LbrCostsMap);

            return Ok(_lbrcosts);
        }


        [HttpGet("~/GetLaborCostWithId")]
        public async Task<IActionResult> GetLaborCostWithId()
        {
            return Ok(await _context.Laborcosts.
                ToListAsync());
        }




        //POST Запросы
        [HttpPost("~/PostLaborCost")]

        public async Task<IActionResult> CreateLaborCost(LbrCostForCreationDto data)
        {
            var _LbrCost = _mapper.Map<Laborcost>(data);


            try
            {
                await _context.Laborcosts.AddAsync(_LbrCost);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetOneLaborCost", routeValues: new { _LbrCost.Laborcostid }, 
                    value: _LbrCost);
            }
            catch
            {
                return new JsonResult("Что-то пошло не так. Возможно, вы ввели уже существующую трз.")
                { StatusCode = 500 };
            }

        }



        //DELETE запросы
        [HttpDelete("~/DeleteLaborCost")]

        public async Task<IActionResult> DeleteLaborCost(string name)
        {
            var lbrCost = await _context.Laborcosts.FirstOrDefaultAsync
                (p => p.Laborcostname == name);

            if (lbrCost == null)
                return BadRequest("Введённой трз не существует.");

            _context.Laborcosts.Remove(lbrCost);
            await _context.SaveChangesAsync();

            return BadRequest($"ТРЗ - {lbrCost.Laborcostname} -  удалена!");
        }



        //PUT запросы
        [HttpPatch("~/EditLaborCost")]

        public async Task<IActionResult> EditLaborCost(string oldname, string newname)
        {
            var lbrCost = _context.Laborcosts.FirstOrDefault(p => p.Laborcostname == oldname);
            if (lbrCost == null)
                return BadRequest("Указанной ТРЗ не существует.");

            lbrCost.Laborcostname = newname;

            await _context.SaveChangesAsync();
            return Ok(lbrCost);
        }
    }
}
