using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Dto.Models
{
    public class BranchCompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeZoneId { get; set; }
        public bool IsLocalBranch { get; set; }
        public int CompanyId { get; set; }
    }
}
