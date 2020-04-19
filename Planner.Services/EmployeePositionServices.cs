using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Base;

namespace Planner.Services
{
    class EmployeePositionServices : IEmployeePositionService
    {
        public IEmployeePositionRepository _repo;

        public EmployeePositionServices(IEmployeePositionRepository repo)
        {

            _repo = repo;

        }
        public async Task Add(Position position)
        {
            _repo.Add(position);
            await _repo.SaveAsync();
        }

        public async Task<string> Delete(int id)
        {
            var employee = await _repo.GetById(id);
            if (employee != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }

        public List<Position> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<Position> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(Position position)
        {
            _repo.Update(position);
          await  _repo.SaveAsync();
        }

        void IBaseServices<Position>.Update(Position entity)
        {
            throw new NotImplementedException();
        }
    }
}
