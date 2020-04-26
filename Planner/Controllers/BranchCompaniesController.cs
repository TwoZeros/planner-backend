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
    public class BranchCompaniesController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IBranchCompanyService _companyBranchService;
        private readonly IMapper _mapper;
        public BranchCompaniesController(PlannerDbContext context, IMapper mapper, IBranchCompanyService companyBranchService)
        {
            _context = context;
            _companyBranchService = companyBranchService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<List<BranchCompanyDto>> GetAlls()
        {
            return await _companyBranchService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var company = await _companyBranchService.GetById(id);

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
        public async Task<IActionResult> PutBranchCompany(int id, [FromBody]BranchCompanyModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var company = _mapper.Map<BranchCompanyModel, BranchCompany>(model);
            _companyBranchService.Update(company);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchCompanyExists(id))
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
        public async Task<ActionResult<BranchCompany>> PostBranchCompany([FromBody]BranchCompanyModel model)
        {
            var company = _mapper.Map<BranchCompanyModel, BranchCompany>(model);
            await _companyBranchService.Add(company);

            return CreatedAtAction("GetById", new { id = company.Id }, company);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BranchCompany>> DeleteBranchCompany(int id)
        {
            var status = await _companyBranchService.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        private bool BranchCompanyExists(int id)
        {
            return _context.BranchCompanys.Any(e => e.Id == id);
        }
    }
}
