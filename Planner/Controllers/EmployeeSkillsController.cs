﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly PlannerDbContext _context;

        public EmployeeSkillsController(PlannerDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSkill>>> GetEmployeeSkills()
        {
            return await _context.EmployeeSkills.ToListAsync();
        }

        // GET: api/EmployeeSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSkill>> GetEmployeeSkill(int id)
        {
            var employeeSkill = await _context.EmployeeSkills.FindAsync(id);

            if (employeeSkill == null)
            {
                return NotFound();
            }

            return employeeSkill;
        }

        // PUT: api/EmployeeSkills/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSkill(int id, EmployeeSkill employeeSkill)
        {
            if (id != employeeSkill.Id)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<EmployeeSkill>> PostEmployeeSkill(EmployeeSkill employeeSkill)
        {
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
