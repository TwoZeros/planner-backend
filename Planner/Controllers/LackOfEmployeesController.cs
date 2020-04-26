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
    public class LackOfEmployeesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ILackOfEmployeeService _lackOfEmployeeService; 
        private readonly IMapper _mapper;
        public LackOfEmployeesController(PlannerDbContext context, IMapper mapper, ILackOfEmployeeService lackOfEmployeeService)
        {
            _context = context;
            _lackOfEmployeeService = lackOfEmployeeService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<LackOfEmployeeDto>> GetAlls()
        {
            return await _lackOfEmployeeService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var lackOfEmployee = await _lackOfEmployeeService.GetById(id);

            if (lackOfEmployee == null)
            {
                return NotFound();
            }

            return new JsonResult(lackOfEmployee);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLackOfEmployee(int id, [FromBody]LackOfEmployeeModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var lackOfEmployee = _mapper.Map<LackOfEmployeeModel, LackOfEmployee>(model);
            _lackOfEmployeeService.Update(lackOfEmployee);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LackOfEmployeeExists(id))
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
        public async Task<ActionResult<LackOfEmployee>> PostLackOfEmployee([FromBody]LackOfEmployeeModel model)
        {
            var lackOfEmployee = _mapper.Map<LackOfEmployeeModel, LackOfEmployee>(model);
            await _lackOfEmployeeService.Add(lackOfEmployee);

            return CreatedAtAction("GetById", new { id = lackOfEmployee.Id }, lackOfEmployee);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LackOfEmployee>> DeleteLackOfEmployee(int id)
        {
            var status = await _lackOfEmployeeService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool LackOfEmployeeExists(int id)
        {
            return _context.LackOfEmployees.Any(e => e.Id == id);
        }
    }
}
