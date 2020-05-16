using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Planner.Data.Contract.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Planner.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Planner.Models.Employee>, IEmployeeRepository
    {
        private readonly PlannerDbContext _context;
        public EmployeeRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Employee> GetEmployeeInfo(int id)
        {
            return await _context.Employees.Include(p => p.User).Include(p=>p.Depatamnet)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void PutEmployee(Employee employee)
        {
            _context.Entry(employee)
             .Property(i => i.FirstName).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.SecondName).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.MiddleName).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.BirthDay).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.PhoneNumber).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.Email).IsModified = true;
        }
        public void PutEmployeePhoto(Employee employee)
        {
            _context.Entry(employee)
             .Property(i => i.Photo).IsModified = true;
        }



        public List<Employee> GetListEmployee()
        {
            return  _context.Employees.Include(p => p.User).Include(p => p.Depatamnet).ToList();
        }

    }
}
