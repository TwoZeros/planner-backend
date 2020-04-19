using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models.Interfaces;
namespace Planner.Models
{
    public class CarmaUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BeginCarma { get; set; }
        public int EndCarma { get; set; }
    }
}
