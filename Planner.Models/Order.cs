using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }
        public User User { get; set; }
        public Client Client { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public List<ProductInOrder> ProductInOrders { get; set; }
    }
}
