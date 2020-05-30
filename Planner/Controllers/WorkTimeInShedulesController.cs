using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class WorkTimeInShedulesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IWorkTimeInCheduleService _workTimeInSheduleService;
        private readonly IMapper _mapper;

        public WorkTimeInShedulesController(PlannerDbContext context, IMapper mapper, IWorkTimeInCheduleService workTimeInSheduleService)
        {
            _context = context;
            _workTimeInSheduleService = workTimeInSheduleService;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<List<WorkTimeInSheduleDto>> GetAlls()
        {
            return await _workTimeInSheduleService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var workTimeInShedule = await _workTimeInSheduleService.GetById(id);

            if (workTimeInShedule == null)
            {
                return NotFound();
            }

            return new JsonResult(workTimeInShedule);
        }

        [HttpGet("getAllDaysInShedule/shedule/{id}")]
        public async Task<ActionResult> GetAllDaysInSheduleById(int id)
        {
            var workTimeInShedule = await _workTimeInSheduleService.GetDaysBySheduleId(id);

            if (workTimeInShedule == null)
            {
                return NotFound();
            }

            return new JsonResult(workTimeInShedule);
        }
        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkTimeInShedule(int id, [FromBody]WorkTimeInSheduleModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var workTimeInShedule = _mapper.Map<WorkTimeInSheduleModel, WorkTimeInShedule>(model);
            _workTimeInSheduleService.Update(workTimeInShedule);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkTimeInSheduleExists(id))
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
        public async Task<ActionResult<WorkTimeInShedule>> PostWorkTimeInShedule([FromBody]WorkTimeInSheduleModel model)
        {
            var skill = _mapper.Map<WorkTimeInSheduleModel, WorkTimeInShedule>(model);
            await _workTimeInSheduleService.Add(skill);

            return CreatedAtAction("GetById", new { id = skill.Id }, skill);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkTimeInShedule>> DeleteWorkTimeInShedule(int id)
        {
            var status = await _workTimeInSheduleService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }
        

        private bool WorkTimeInSheduleExists(int id)
        {
            return _context.WorkTimeInChedules.Any(e => e.Id == id);
        }
    }
}
