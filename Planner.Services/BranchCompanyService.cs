using Planner.Data.Contract.Repositories;
using Planner.Data.Repositories;
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
    public class BranchCompanyService : IBranchCompanyService
    {
        public IBranchCompanyRepository _repo;

        private readonly IBranchCompanyDetailMapper _detailMapper;

        public BranchCompanyService(IBranchCompanyRepository repo, IBranchCompanyDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        
        public async Task<BranchCompanyDto> GetById(int id)
        {
            var branchCompany = await _repo.GetBranchCompanyInfo(id);
            var branchCompanyDto = _detailMapper.Map<BranchCompany, BranchCompanyDto>(branchCompany);

            return branchCompanyDto;
        }
        public async Task<List<BranchCompanyDto>> GetAll()
        {
            var branchCompanys = await _repo.GetAllBranchCompany();
            return _detailMapper.Map<List<BranchCompany>, List<BranchCompanyDto>>(branchCompanys);
        }

        public async Task<string> Delete(int id)
        {
            var branchCompany = await _repo.GetById(id);
            if (branchCompany != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(BranchCompany branchCompany)
        {
            _repo.Add(branchCompany);
            await _repo.SaveAsync();
        }

        public void Update(BranchCompany branchCompany)
        {
            _repo.Update(branchCompany);
        }
    }
}
