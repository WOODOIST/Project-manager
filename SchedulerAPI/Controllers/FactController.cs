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
    public class FactController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IMapper _mapper;





        public FactController(SchedulerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        //GET запросы
        [HttpGet("~/GetFactByName")]

        public async Task<IActionResult> GetFactByName(string fact_name)
        {
            
            var fact = await _context.Facts.FirstOrDefaultAsync(p => p.Factname == fact_name);

            if (fact == null)
                return BadRequest("Указанного факта не существует");

            return Ok(fact);
        }


        [HttpGet("~/GetFactsWithoutId")]
        public async Task<IActionResult> GetFactsWithoutId()
        {
            var allFactsAsync = await _context.Facts.ToListAsync();
            var allFacts = allFactsAsync.Select(p =>
            _mapper.Map<FactDto>(p));
            var facts = _mapper.Map<IEnumerable<FactDto>>(allFacts);

            return Ok(facts);
        }


        [HttpGet("~/GetFactsWithId")]
        public async Task<IActionResult> GetFactsWithId()
        {
            return Ok(await _context.Facts.
                ToListAsync());
        }




        //POST Запросы
        [HttpPost("~/PostFact")]

        public async Task<IActionResult> PostFact( FactForCreationDto data)
        {
            var _fact = _mapper.Map<Fact>(data);


            try
            {
                await _context.Facts.AddAsync(_fact);
                await _context.SaveChangesAsync();
                return Ok(await _context.Facts.FirstOrDefaultAsync(p=>p.Factname == _fact.Factname));
            }
            catch
            {
                return new JsonResult("Что-то пошло не так. Возможно, " +
                    "вы ввели уже существующий факт")
                { StatusCode = 500 };
            }

        }



        //DELETE запросы
        [HttpDelete("~/DeleteFact")]

        public async Task<IActionResult> DeleteFact(string fact_name)
        {
            var fact = await _context.Facts.FirstOrDefaultAsync
                (p => p.Factname == fact_name);

            if (fact == null)
                return BadRequest("Введённого факта не существует.");

            _context.Facts.Remove(fact);
            await _context.SaveChangesAsync();

            return BadRequest($"Факт - {fact.Factname} - удален(а)!");
        }



        //PUT запросы
        [HttpPatch("~/EditFact")]

        public async Task<IActionResult> EditFact(string oldname, string newname)
        {
            var fact = await _context.Facts.FirstOrDefaultAsync(p => p.Factname == oldname);
            if (fact == null)
                return BadRequest("Указанного факта не существует.");

            fact.Factname = newname;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(fact);
            }
            catch
            {
                return BadRequest("Что-то пошло не так. Возможно, вы ввели уже существующий факт!");
            }


        }
    }
}
