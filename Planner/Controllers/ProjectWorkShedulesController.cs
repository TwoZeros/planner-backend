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
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectWorkShedulesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IProjectWorkSheduleService _projectWorkSheduleService;
        private readonly IMapper _mapper;
        public ProjectWorkShedulesController(PlannerDbContext context, IMapper mapper, IProjectWorkSheduleService projectWorkSheduleService)
        {
            _context = context;
            _projectWorkSheduleService = projectWorkSheduleService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<ProjectWorkSheduleDto>> GetAlls()
        {
            return await _projectWorkSheduleService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var projectWorkShedule = await _projectWorkSheduleService.GetById(id);

            if (projectWorkShedule == null)
            {
                return NotFound();
            }

            return new JsonResult(projectWorkShedule);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectWorkShedule(int id, [FromBody]ProjectWorkSheduleModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var projectWorkShedule = _mapper.Map<ProjectWorkSheduleModel, ProjectWorkShedule>(model);
            _projectWorkSheduleService.Update(projectWorkShedule);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectWorkSheduleExists(id))
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
        public async Task<ActionResult<ProjectWorkShedule>> PostProjectWorkShedule([FromBody]ProjectWorkSheduleModel model)
        {
            var projectWorkShedule = _mapper.Map<ProjectWorkSheduleModel, ProjectWorkShedule>(model);
            await _projectWorkSheduleService.Add(projectWorkShedule);

            return CreatedAtAction("GetById", new { id = projectWorkShedule.Id }, projectWorkShedule);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectWorkShedule>> DeleteProjectWorkShedule(int id)
        {
            var status = await _projectWorkSheduleService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool ProjectWorkSheduleExists(int id)
        {
            return _context.ProjectWorkShedules.Any(e => e.Id == id);
        }
    }
}