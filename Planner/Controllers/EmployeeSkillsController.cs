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
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IEmployeeSkillDetailMapper _employeeSkillMapper;
        private readonly IMapper _mapper;
        public EmployeeSkillsController(PlannerDbContext context, IMapper mapper,IEmployeeSkillDetailMapper employeeSkillMapper)
        {
            _employeeSkillMapper = employeeSkillMapper;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/EmployeeSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSkillDto>>> GetEmployeeSkills()
        {
            var emoloyeeSkills = await _context.EmployeeSkills.Include(p => p.Skill).ThenInclude(p=> p.GroupSkill).Include(p=>p.Employee).Include(p=>p.KnowledgeLevel).ToListAsync();
            var employeeSkillsDto = _employeeSkillMapper.Map<List<EmployeeSkill>, List<EmployeeSkillDto>>(emoloyeeSkills);
            return new JsonResult(employeeSkillsDto);
        }

        // GET: api/EmployeeSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSkillDto>> GetEmployeeSkill(int id)
        {
            var employeeSkill = await _context.EmployeeSkills.Include(p => p.Skill).ThenInclude(p => p.GroupSkill).Include(p => p.Employee).Include(p => p.KnowledgeLevel).Where(p=>p.Id==id).FirstOrDefaultAsync();
            
            if (employeeSkill == null)
            {
                return NotFound();
            }
            var employeeSkillsDto = _employeeSkillMapper.Map<EmployeeSkill, EmployeeSkillDto>(employeeSkill);
            return new JsonResult(employeeSkillsDto);
        }

        // GET: api/EmployeeSkills/employee/5
        [HttpGet("employee/{id}")]
        public async Task<ActionResult> GetSkillsByEmployeeId(int id)
        {
            var employeeSkills = await _context.EmployeeSkills
                                  .Include(p => p.Skill)
                                  .ThenInclude(p => p.GroupSkill)
                                  .Include(p => p.Employee)
                                  .Include(p => p.KnowledgeLevel)
                                  .Where(p=>p.EmployeeId==id)
                                    .ToListAsync();
            
            if (employeeSkills == null)
            {
                return NotFound();
            }
            var employeeSkillsDto = _employeeSkillMapper.Map<List<EmployeeSkill>, List<EmployeeSkillDto>>(employeeSkills);

            var employeeSkill = employeeSkillsDto.GroupBy(p => p.SkillGroupName)
                        .Select(g => new
                        {
                            Name = g.Key,
                            Skills = g.Select(p => p)
                        });
            return new JsonResult(employeeSkill);
        }

        // PUT: api/EmployeeSkills/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSkill(int id, [FromBody]EmployeeSkillModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var employeeSkill = _mapper.Map<EmployeeSkillModel, EmployeeSkill>(model);
            _context.Entry(employeeSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSkillExists(id))
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

        // POST: api/EmployeeSkills
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeSkill>> PostEmployeeSkill([FromBody]EmployeeSkillModel model)
        {
            var employeeSkill = _mapper.Map<EmployeeSkillModel, EmployeeSkill>(model);
            _context.EmployeeSkills.Add(employeeSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeSkill", new { id = employeeSkill.Id }, employeeSkill);
        }

        // DELETE: api/EmployeeSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeSkill>> DeleteEmployeeSkill(int id)
        {
            var employeeSkill = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null)
            {
                return NotFound();
            }

            _context.EmployeeSkills.Remove(employeeSkill);
            await _context.SaveChangesAsync();

            return employeeSkill;
        }

        private bool EmployeeSkillExists(int id)
        {
            return _context.EmployeeSkills.Any(e => e.Id == id);
        }
    }
}
