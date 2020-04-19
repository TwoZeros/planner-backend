
using Planner.Models.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
namespace Planner.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }
    }
}
