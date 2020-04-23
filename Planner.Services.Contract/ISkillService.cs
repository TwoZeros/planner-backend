using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;
using Planner.Services.Contract.Base;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract
{
    public interface ISkillService 
    {
        Task<SkillDto> GetById(int id);
        Task<List<SkillDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(Skill skill);
        void Update(Skill skill);


    }
}
