using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class ProjectsController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(PlannerDbContext context, IMapper mapper, IProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<List<ProjectDto>> GetAlls()
        {
            return await _projectService.GetAll();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var project = await _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return new JsonResult(project);
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, [FromBody]ProjectModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var project = _mapper.Map<ProjectModel, Project>(model);
            _projectService.Update(project);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject([FromBody]ProjectModel model)
        {
            var project = _mapper.Map<ProjectModel, Project>(model);
            await _projectService.Add(project);

            return CreatedAtAction("GetById", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = await _projectService.Delete(id);
            if (project == null)
            {
                return NotFound();
            }

            return new JsonResult(project);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
