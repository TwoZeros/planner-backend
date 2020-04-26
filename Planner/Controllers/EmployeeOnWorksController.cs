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
    public class EmployeeOnWorksController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IEmployeeOnWorkService _skillService;
        private readonly IMapper _mapper;
        public EmployeeOnWorksController(PlannerDbContext context, IMapper mapper, IEmployeeOnWorkService skillService)
        {
            _context = context;
            _skillService = skillService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<EmployeeOnWorkDto>> GetAlls()
        {
            return await _skillService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var skill = await _skillService.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            return new JsonResult(skill);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeOnWork(int id, [FromBody]EmployeeOnWorkModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var skill = _mapper.Map<EmployeeOnWorkModel, EmployeeOnWork>(model);
            _skillService.Update(skill);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeOnWorkExists(id))
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
        public async Task<ActionResult<EmployeeOnWork>> PostEmployeeOnWork([FromBody]EmployeeOnWorkModel model)
        {
            var skill = _mapper.Map<EmployeeOnWorkModel, EmployeeOnWork>(model);
            await _skillService.Add(skill);

            return CreatedAtAction("GetById", new { id = skill.Id }, skill);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeOnWork>> DeleteEmployeeOnWork(int id)
        {
            var status = await _skillService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool EmployeeOnWorkExists(int id)
        {
            return _context.EmployeeOnWorks.Any(e => e.Id == id);
        }
    }
}
