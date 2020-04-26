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
    public class HolidaysController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IHolidaysService _holidaysService;
        private readonly IMapper _mapper;
        public HolidaysController(PlannerDbContext context, IMapper mapper, IHolidaysService holidaysService)
        {
            _context = context;
            _holidaysService = holidaysService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<HolidaysDto>> GetAlls()
        {
            return await _holidaysService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var holidays = await _holidaysService.GetById(id);

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
        public async Task<IActionResult> PutHolidays(int id, [FromBody]HolidaysModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var holidays = _mapper.Map<HolidaysModel, Holidays>(model);
            _holidaysService.Update(holidays);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidaysExists(id))
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
        public async Task<ActionResult<Holidays>> PostHolidays([FromBody]HolidaysModel model)
        {
            var holidays = _mapper.Map<HolidaysModel, Holidays>(model);
            await _holidaysService.Add(holidays);

            return CreatedAtAction("GetById", new { id = holidays.Id }, holidays);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Holidays>> DeleteHolidays(int id)
        {
            var status = await _holidaysService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool HolidaysExists(int id)
        {
            return _context.Holidays.Any(e => e.Id == id);
        }
    }
}
