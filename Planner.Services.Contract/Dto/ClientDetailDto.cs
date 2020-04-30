using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract.Dto
{
    public class ClientDetailDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Created { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
