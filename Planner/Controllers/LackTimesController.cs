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
    public class LackTimesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ILackTimeService _lackTimeService;
        private readonly IMapper _mapper;
        public LackTimesController(PlannerDbContext context, IMapper mapper, ILackTimeService lackTimeService)
        {
            _context = context;
            _lackTimeService = lackTimeService;
            _mapper = mapper;
        }
        

       // GET: api/Skills
       [HttpGet]
        public async Task<List<LackTimeDto>> GetAlls()
        {
            return await _lackTimeService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var lackTime= await _lackTimeService.GetById(id);

            if (lackTime == null)
            {
                return NotFound();
            }

            return new JsonResult(lackTime);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLackTime(int id, [FromBody]LackTimeModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var lackTime = _mapper.Map<LackTimeModel, LackTime>(model);
            _lackTimeService.Update(lackTime);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LackTimeExists(id))
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
        public async Task<ActionResult<LackTime>> PostLackTime([FromBody]LackTimeModel model)
        {
            var lackTime = _mapper.Map<LackTimeModel, LackTime>(model);
            await _lackTimeService.Add(lackTime);

            return CreatedAtAction("GetById", new { id = lackTime.Id }, lackTime);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LackTime>> DeleteLackTime(int id)
        {
            var status = await _lackTimeService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool LackTimeExists(int id)
        {
            return _context.LackTimes.Any(e => e.Id == id);
        }
    }
}
