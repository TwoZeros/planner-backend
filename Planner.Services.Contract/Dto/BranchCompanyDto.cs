using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Contract.Dto
{
    public class BranchCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeZoneId { get; set; }
        public bool IsLocalBranch { get; set; }
        public string CompanyName { get; set; }
    }
}
