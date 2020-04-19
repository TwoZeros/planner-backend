using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int UserId { get; set; }
        public Client Client { get; set; }
        public virtual User User { get; set; }

        public DateTime CreateDate { get; set; }

        public string Text { get; set; }

        public int Karma { get; set; }

    }
}