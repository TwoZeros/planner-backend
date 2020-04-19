using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreate { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }
    }
}
