using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
namespace Planner.Services
{
    class CarmaUserService : ICarmaUser
    {
        public ICarmaRepository _repo;

        public CarmaUserService(ICarmaRepository repo)
        {

            _repo = repo;

        }

        public async Task CreateCarmaUser(CarmaUser carmaUser)
        {
            _repo.Add(carmaUser);
            await _repo.SaveAsync();
        }

        public async Task<string> GetByNumber(int number)
        {
            var carma = await _repo.GetStatusByNumber(number);
            return carma.Name;
        }

        public void PutCarmaUser(int number, CarmaUser carmaUser)
        {

            _repo.PutCarmaClient(carmaUser);

        }
        public async Task<string> Delete(int number)
        {
            var carma = await _repo.GetStatusByNumber(number);
            if (carma != null)
            {
                await _repo.Delete(number);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
    }
}
