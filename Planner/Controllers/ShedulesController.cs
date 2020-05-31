using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Dto.Models;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShedulesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ISheduleService _sheduleService;
        private readonly IMapper _mapper;
        private readonly IWorkTimeInCheduleService _workTimeService;
        public ShedulesController(PlannerDbContext context, IMapper mapper, ISheduleService sheduleService, IWorkTimeInCheduleService workTimeService)
        {
            _context = context;
            _sheduleService = sheduleService;
            _mapper = mapper;
            _workTimeService = workTimeService;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<SheduleDto>> GetAlls()
        {
            return await _sheduleService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var shedule = await _sheduleService.GetById(id);

            if (shedule == null)
            {
                return NotFound();
            }

            return new JsonResult(shedule);
        }

        [HttpGet("holidaysInShedule/{id}")]
        public async Task<ActionResult> GetHolidays(int id)
        {
            var holidays = await _sheduleService.GetHolidays(id);
            if (holidays == null)
            {
                return NotFound();
            }
            return new JsonResult(holidays);
        }
        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShedule(int id, [FromBody]SheduleModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var shedule = _mapper.Map<SheduleModel, Shedule>(model);
           
            await _sheduleService.Update(shedule, model.Holidays);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Shedule>> PostShedule([FromBody]SheduleModel model)
        {

            var shedule = _mapper.Map<SheduleModel, Shedule>(model);

            await _sheduleService.Add(shedule);

            await _workTimeService.AddDaysShedule(model.workHoursCount, shedule, model.Holidays);
      
            return CreatedAtAction("GetById", new { id = shedule.Id }, shedule);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shedule>> DeleteShedule(int id)
        {
            var status = await _sheduleService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }
            
            return new JsonResult(status);
        }

        private bool SheduleExists(int id)
        {
            return _context.Shedules.Any(e => e.Id == id);
        }
    }
}
