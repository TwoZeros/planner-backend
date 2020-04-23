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

        public virtual User User { get; set; }
        public virtual Position Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual List<EmployeeSkill> EmployeeSkill { get; set; }

        public Employee()
        {
            Position = new Position();
            User = new User();
            EmployeeSkill = new List<EmployeeSkill>();
        }

    }
}
