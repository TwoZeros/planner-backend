using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class ClientListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Rating { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Created { get; set; }
    }

   
}
