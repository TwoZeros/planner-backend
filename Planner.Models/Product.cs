using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models.Interfaces;

namespace Planner.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<ProductInOrder> ProductInOrder { get; set; }
    }
}
