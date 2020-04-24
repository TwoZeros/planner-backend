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
    public class SkillsController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;
        public SkillsController(PlannerDbContext context, IMapper mapper, ISkillService skillService)
        {
            _context = context;
            _skillService = skillService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<SkillDto>> GetAlls()
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
        public async Task<IActionResult> PutSkill(int id, [FromBody]SkillModel model)
        {
            if (id != model.Id )
            {
                return BadRequest();
            }
            var skill = _mapper.Map<SkillModel, Skill>(model);
            _skillService.Update(skill);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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
        public async Task<ActionResult<Skill>> PostSkill([FromBody]SkillModel model)
        {
            var skill = _mapper.Map<SkillModel, Skill>(model);
            await _skillService.Add(skill);

            return CreatedAtAction("GetById", new { id = skill.Id }, skill);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Skill>> DeleteSkill(int id)
        {
            var status = await _skillService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool SkillExists(int id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
