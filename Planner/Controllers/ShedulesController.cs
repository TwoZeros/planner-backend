using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Data.Repositories;
using Planner.Dto.Models;
using Planner.Models;
using Planner.Services;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShedulesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ISheduleService _sheduleService;
        private readonly IMapper _mapper;
        public ShedulesController(PlannerDbContext context, IMapper mapper, ISheduleService sheduleService)
        {
            _context = context;
            _sheduleService = sheduleService;
            _mapper = mapper;
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
            _sheduleService.Update(shedule);

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

            var _wtisService = new WorkTimeInCheduleService(new WorkTimeInCheduleRepository(_context), new WorkTimeInSheduleDetailMapper());

            await _wtisService.AddDaysShedule(model.workHoursCount, shedule);

            //var days = new List<WorkTimeInShedule>();

            //foreach (var it in model.workTimeInSheduleModels)
            //{
            //    it.SheduleId = shedule.Id;
            //    days.Add(_mapper.Map<WorkTimeInSheduleModel, WorkTimeInShedule>(it));
            //}

            //shedule.WorkTimeInShedules = days;
                    
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
