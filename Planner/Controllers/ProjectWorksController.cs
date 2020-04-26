using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class ProjectWorksController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IProjectWorkService _projectWorkService;
        private readonly IMapper _mapper;

        public ProjectWorksController(PlannerDbContext context, IMapper mapper, IProjectWorkService projectWorkService)
        {
            _context = context;
            _projectWorkService = projectWorkService;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<List<ProjectWorkDto>> GetAlls()
        {
            return await _projectWorkService.GetAll();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var project = await _projectWorkService.GetById(id);

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
        public async Task<IActionResult> PutProjectWork(int id, [FromBody]ProjectWorkModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var project = _mapper.Map<ProjectWorkModel, ProjectWork>(model);
            _projectWorkService.Update(project);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectWorkExists(id))
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
        public async Task<ActionResult<ProjectWork>> PostProjectWork([FromBody]ProjectWorkModel model)
        {
            var project = _mapper.Map<ProjectWorkModel, ProjectWork>(model);
            await _projectWorkService.Add(project);

            return CreatedAtAction("GetById", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectWork>> DeleteProjectWork(int id)
        {
            var project = await _projectWorkService.Delete(id);
            if (project == null)
            {
                return NotFound();
            }

            return new JsonResult(project);
        }

        private bool ProjectWorkExists(int id)
        {
            return _context.ProjectWorks.Any(e => e.Id == id);
        }
    }
}
