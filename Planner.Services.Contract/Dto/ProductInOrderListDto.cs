using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class ProductInOrderListDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public string StandartPrice { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
