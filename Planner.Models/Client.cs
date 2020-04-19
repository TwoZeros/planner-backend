using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }
    }
}
