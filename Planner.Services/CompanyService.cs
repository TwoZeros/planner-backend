using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class CompanyService : ICompanyService
    {
        public ICompanyRepository _repo;

        private readonly ICompanyDetailMapper _detailMapper;

        public CompanyService(ICompanyRepository repo, ICompanyDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<CompanyDto> GetById(int id)
        {
            var company = await _repo.GetCompanyInfo(id);
            var companyDto = _detailMapper.Map<Company, CompanyDto>(company);

            return companyDto;
        }
        public async Task<List<CompanyDto>> GetAll()
        {
            var companys = await _repo.GetAllCompany();
            return _detailMapper.Map<List<Company>, List<CompanyDto>>(companys);
        }

        public async Task<string> Delete(int id)
        {
            var company = await _repo.GetById(id);
            if (company != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(Company company)
        {
            _repo.Add(company);
            await _repo.SaveAsync();
        }

        public void Update(Company company)
        {
            _repo.Update(company);
        }
    }
}
