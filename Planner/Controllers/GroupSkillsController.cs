using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupSkillsController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IGroupSkillMapper _groupMapper;

        public GroupSkillsController(PlannerDbContext context, IGroupSkillMapper groupMapper)
        {
            _context = context;
            _groupMapper = groupMapper;
        }

        // GET: api/GroupSkills
        [HttpGet]
        public async Task<IActionResult> GetGroupSkills()
        {
            var groupskills=await  _context.GroupSkills.ToListAsync();
            return new JsonResult(_groupMapper.Map<List<GroupSkill>, List<GroupSkillDto>>(groupskills));
        }

        // GET: api/GroupSkills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupSkill(int id)
        {
            var groupSkill = await _context.GroupSkills.FindAsync(id);

            if (groupSkill == null)
            {
                return NotFound();
            }
           var groupSkillDto = _groupMapper.Map<GroupSkill, GroupSkillDto>(groupSkill);
           return new JsonResult(groupSkillDto);
        }

        // PUT: api/GroupSkills/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupSkill(int id, GroupSkill groupSkill)
        {
            if (id != groupSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupSkillExists(id))
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

        // POST: api/GroupSkills
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GroupSkill>> PostGroupSkill(GroupSkill groupSkill)
        {
            _context.GroupSkills.Add(groupSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupSkill", new { id = groupSkill.Id }, groupSkill);
        }

        // DELETE: api/GroupSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupSkill>> DeleteGroupSkill(int id)
        {
            var groupSkill = await _context.GroupSkills.FindAsync(id);
            if (groupSkill == null)
            {
                return NotFound();
            }

            _context.GroupSkills.Remove(groupSkill);
            await _context.SaveChangesAsync();

            return groupSkill;
        }

        private bool GroupSkillExists(int id)
        {
            return _context.GroupSkills.Any(e => e.Id == id);
        }
    }
}
