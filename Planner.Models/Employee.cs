using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDay { get; set; }
        public int? UserId { get; set; }
        public int? BranchCompanyId { get; set; }
        public User User { get; set; }
        public Position Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public BranchCompany BranchCompany { get; set; }
        public List<EmployeeSkill> EmployeeSkill { get; set; }
        public List<Project> Projects { get; set; }
        public List<LackOfEmployee> LackOfEmployees{ get; set; }
        public List<EmployeeShedule> EmployeeShedules { get; set; }
        public List<EmployeeOnWork> EmployeeOnWorks { get; set; }

    }
}
