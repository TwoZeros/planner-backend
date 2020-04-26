using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IBranchCompanyService
    {
        Task<BranchCompanyDto> GetById(int id);
        Task<List<BranchCompanyDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(BranchCompany branchCompany);
        void Update(BranchCompany branchCompany);
    }
}
