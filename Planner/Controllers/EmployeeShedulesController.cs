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
    public class EmployeeShedulesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IEmployeeSheduleService _employeeSheduleService;
        private readonly IMapper _mapper;
        public EmployeeShedulesController(PlannerDbContext context, IMapper mapper, IEmployeeSheduleService employeeSheduleService)
        {
            _context = context;
            _employeeSheduleService = employeeSheduleService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<EmployeeSheduleDto>> GetAlls()
        {
            return await _employeeSheduleService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employeeShedule = await _employeeSheduleService.GetById(id);

            if (employeeShedule == null)
            {
                return NotFound();
            }

            return new JsonResult(employeeShedule);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeShedule(int id, [FromBody]EmployeeSheduleModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var employeeShedule = _mapper.Map<EmployeeSheduleModel, EmployeeShedule>(model);
            _employeeSheduleService.Update(employeeShedule);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSheduleExists(id))
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
        public async Task<ActionResult<EmployeeShedule>> PostSkill([FromBody]EmployeeSheduleModel model)
        {
            var employeeShedule = _mapper.Map<EmployeeSheduleModel, EmployeeShedule>(model);
            await _employeeSheduleService.Add(employeeShedule);

            return CreatedAtAction("GetById", new { id = employeeShedule.Id }, employeeShedule);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeShedule>> DeleteEmployeeShedule(int id)
        {
            var status = await _employeeSheduleService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool EmployeeSheduleExists(int id)
        {
            return _context.EmployeeShedules.Any(e => e.Id == id);
        }
    }
}
