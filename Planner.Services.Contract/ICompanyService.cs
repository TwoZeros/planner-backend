using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetById(int id);
        Task<List<CompanyDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(Company company);
        void Update(Company company);
    }
}
