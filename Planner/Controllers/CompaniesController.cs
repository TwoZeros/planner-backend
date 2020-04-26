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
    public class CompaniesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompaniesController(PlannerDbContext context, IMapper mapper, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<CompanyDto>> GetAlls()
        {
            return await _companyService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var company = await _companyService.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            return new JsonResult(company);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, [FromBody]CompanyModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var company = _mapper.Map<CompanyModel, Company>(model);
            _companyService.Update(company);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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
        public async Task<ActionResult<Company>> PostCompany([FromBody]CompanyModel model)
        {
            var company = _mapper.Map<CompanyModel, Company>(model);
            await _companyService.Add(company);

            return CreatedAtAction("GetById", new { id = company.Id }, company);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(int id)
        {
            var status = await _companyService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool CompanyExists(int id)
        {
            return _context.Companys.Any(e => e.Id == id);
        }
    }
}
