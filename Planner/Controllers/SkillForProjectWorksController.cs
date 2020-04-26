using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Dto;
using Planner.Dto.Models;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillForProjectWorksController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ISkillForProjectWorkService _skillForProjectWorkService;
        private readonly IMapper _mapper;
        public SkillForProjectWorksController(PlannerDbContext context, IMapper mapper, ISkillForProjectWorkService skillForProjectWorkService)
        {
            _context = context;
            _skillForProjectWorkService = skillForProjectWorkService;
            _mapper = mapper;
        }

        // GET: api/ForProjectWorks
        [HttpGet]
        public async Task<List<SkillForProjectWorkDto>> GetAlls()
        {
            return await _skillForProjectWorkService.GetAll();
        }

        // GET: api/ForProjectWorks/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var skill = await _skillForProjectWorkService.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            return new JsonResult(skill);
        }

        // PUT: api/ForProjectWorks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, [FromBody]SkillForProjectWorkModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var skill = _mapper.Map<SkillForProjectWorkModel, SkillForProjectWork>(model);
            _skillForProjectWorkService.Update(skill);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillForProjectWorkExists(id))
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

        // POST: api/ForProjectWorks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SkillForProjectWork>> PostSkillForProjectWork([FromBody]SkillForProjectWorkModel model)
        {
            var skill = _mapper.Map<SkillForProjectWorkModel, SkillForProjectWork>(model);
            await _skillForProjectWorkService.Add(skill);

            return CreatedAtAction("GetById", new { id = skill.Id }, skill);
        }

        // DELETE: api/ForProjectWorks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SkillForProjectWork>> DeleteSkillForProjectWork(int id)
        {
            var status = await _skillForProjectWorkService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool SkillForProjectWorkExists(int id)
        {
            return _context.SkillForProjectWorks.Any(e => e.Id == id);
        }
    }
}
