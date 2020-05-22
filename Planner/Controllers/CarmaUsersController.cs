using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;
using Planner.Dto.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarmaUsersController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ICarmaUser _carmaUser;

        public CarmaUsersController(PlannerDbContext context, ICarmaUser carmaUser)
        {
            _context = context;
            _carmaUser = carmaUser;
        }

        // GET: api/CarmaUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarmaUser>>> GetCarmaUsers()
        {
            return await _context.CarmaUsers.OrderBy(p =>p.BeginCarma).ToListAsync();
        }

        // GET: api/CarmaUsers/5
        [HttpGet("GetCarmaByNumber/{number}")]
        public async Task<ActionResult> GetCarmaByNumber(int number)
        {
            var carma = await _carmaUser.GetByNumber(number);

            if (carma == null)
            {
                return NotFound();
            }

            return new JsonResult(carma);
        }

        // PUT: api/CarmaUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarmaUser(int id, CarmaUser carmaUser)
        {
            if (id != carmaUser.Id)
            {
                return BadRequest();
            }

            _carmaUser.PutCarmaUser(id, carmaUser);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarmaUserExists(id))
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

        // POST: api/CarmaUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CarmaUser>> PostCarmaUser(CarmaUser carmaUser)
        {
            await _carmaUser.CreateCarmaUser(carmaUser);
            return CreatedAtAction("GetCarmaUsers", new { id = carmaUser.Id }, carmaUser);
        }

        // DELETE: api/CarmaUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarmaUser(int id)
        {
            var carmaUser = await _carmaUser.Delete(id);
            if (carmaUser == "Not Found")
            {
                return NotFound();
            }


            return new JsonResult(carmaUser);
        }

        private bool CarmaUserExists(int id)
        {
            return _context.CarmaUsers.Any(e => e.Id == id);
        }
    }
}
