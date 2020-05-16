using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class LackTimeDto
    {
        public int Id { get; set; }
       
        [Column(TypeName = "Date")]
        public string Day { get; set; }
        public int LackOfEmployeeId { get; set; }
        public string LackOfEmployeeName { get; set; }
    }
}
